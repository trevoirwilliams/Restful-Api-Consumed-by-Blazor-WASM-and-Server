using AutoMapper;
using BookStoreApp.API.Contracts;
using BookStoreApp.API.Data;
using BookStoreApp.API.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthManager _authManager;

        public AuthenticationController(IAuthManager authManager)
        {
            this._authManager = authManager;
        }

        //api/account/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] UserDto userDto)
        {
            var errors = await _authManager.Register(userDto);
            if (errors.Any())
            {
                foreach (var e in errors)
                {
                    ModelState.AddModelError(e.Code, e.Description);
                }
                return BadRequest(ModelState);

            }
            return Ok();
        }


        //api/account/login
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginUserDto loginDto)
        {

            //what you get when you log in
            var authResponse = await _authManager.Login(loginDto);

            // if null, then user is unauthorised
            if (authResponse == null)
            {
                return Unauthorized();
            }
            return Ok(authResponse);

        }

        //api/account/refreshtoken
        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto request)
        {

            var authResponse = await _authManager.VerifyRefreshToken(request);

            if (authResponse == null)
            {
                return Unauthorized();
            }
            return Ok(authResponse);
        }



    }
}
