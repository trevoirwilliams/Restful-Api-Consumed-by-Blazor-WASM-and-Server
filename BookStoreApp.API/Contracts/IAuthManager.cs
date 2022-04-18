using BookStoreApp.API.Models.User;
using Microsoft.AspNetCore.Identity;

namespace BookStoreApp.API.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(UserDto userDto);
        Task<AuthResponseDto> Login(LoginUserDto loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}