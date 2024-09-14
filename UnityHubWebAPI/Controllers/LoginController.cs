using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UnityHubWebAPI.Common;
using UnityHubWebAPI.IServices;
using UnityHubWebAPI.Services;

namespace UnityHubWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly ILoginUserService _loginUserService;
        private readonly ICommonService _commonService;
        public LoginController(LoginService login, ILoginUserService loginUser, ICommonService commonService)
        {
            _loginService = login;
            _loginUserService = loginUser;
            _commonService = commonService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserModel login)
        {
            if (login == null)
                throw new ArgumentNullException(nameof(login));

            string password = login.Password;
            var (hashedPassword, salt) = _commonService.HashPassword(password);

            var ExistingUser = await _loginUserService.GetByIdAsync(login.Username);

            if (ExistingUser == null)
                return NotFound();

            bool isPasswordValid = _commonService.VerifyPassword(password, ExistingUser.PasswordHash, ExistingUser.PasswordSalt);


            if (isPasswordValid)
            {
                var tokenResponse = await _loginService.Login(login.Username, hashedPassword);
                return Ok(tokenResponse);
            }
            else
            {
                return Unauthorized(new { Error = "Invalid username or password" });
            }
        }
    }
}
