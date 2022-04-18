using AutoMapper;
using BookStoreApp.API.Contracts;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStoreApp.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthManager> _logger;
        private ApiUser _user;

        private const string _loginProvider = "BookStoreApi";
        private const string _refreshToken = "RefreshToken";


        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager, IConfiguration configuration, ILogger<AuthManager> logger)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._configuration = configuration;
            this._logger = logger;
        }

        public async Task<string> CreateRefreshToken()
        {
            // store in the db that a token has been given to user
            // first remove old one
            await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);

            // create new one
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);

            // set new one in db
            var result = await _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newRefreshToken);

            return newRefreshToken;
        }

        public async Task<AuthResponseDto> Login(LoginUserDto loginDto)
        {
            _logger.LogInformation($"Looking for user with email {loginDto.Email}.");
            _user = await _userManager.FindByEmailAsync(loginDto.Email);

            // check if valid user
            bool validUser = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

            if (_user == null || validUser == false)
            {
                _logger.LogWarning($"User with email {loginDto.Email}, not found.");
                return null;
            }

            // get token string
            var token = await GenerateToken();
            _logger.LogInformation($"Token generated for user, {loginDto.Email}.");

            // return new instance of authReponseDTO
            return new AuthResponseDto
            {
                Token = token,
                UserId = _user.Id,
                RefreshToken = await CreateRefreshToken()
            };

        }

        public async Task<IEnumerable<IdentityError>> Register(UserDto userDto)
        {
            _user = _mapper.Map<ApiUser>(userDto);
            _user.UserName = userDto.Email;

            //create user, if successful at to roles
            var result = await _userManager.CreateAsync(_user, userDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(_user, "User");
            }

            //if successful there are no errors
            return result.Errors;
        }

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;
            _user = await _userManager.FindByNameAsync(username);

            if (_user == null || _user.Id != request.UserId)
            {
                return null;
            }

            // varify if valid(still in db) then generate new token
            // return new object of authresponseDTO with new properties
            var validRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, request.RefreshToken);
            if (validRefreshToken)
            {
                var token = await GenerateToken();
                return new AuthResponseDto
                {
                    Token = token,
                    UserId = _user.Id,
                    RefreshToken = await CreateRefreshToken()
                };

            }
            await _userManager.UpdateSecurityStampAsync(_user);
            return null;
        }

        private async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // add roles from db to the list of claims for user
            var roles = await _userManager.GetRolesAsync(_user);

            var roleClaims = roles.Select(q => new Claim(ClaimTypes.Role, q)).ToList();

            // fetch claims from user
            var userClaims = await _userManager.GetClaimsAsync(_user);

            // generate actual list of claims for token
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Email), //sub = subject to whom token has been issued
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //jti = if someone tries to reuse the token
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
            }
            .Union(userClaims).Union(roleClaims);

            // now create token and return it
            var token = new JwtSecurityToken(
                 issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
