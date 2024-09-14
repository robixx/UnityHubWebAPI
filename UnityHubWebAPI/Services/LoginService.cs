using System.IdentityModel.Tokens.Jwt;
using UnityHubWebAPI.Common;
using UnityHubWebAPI.Helpers;

namespace UnityHubWebAPI.Services
{
    public class LoginService
    {
        private readonly LoginRepository _loginRepository;

        public LoginService(LoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<object> Login(string username, string password)
        {


            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var response = new TokenResponse();

                var jwtSecurityToken = await _loginRepository.GenerateJWToken(username, password);

                response.UserName = username;
                response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                response.ExpiresOn = DateTime.Now.AddYears(1);
                response.IssuedOn = DateTime.Now;

                return response;
            }
            else
            {
                return new { Error = "Invalid username or password" };
            }
        }
    }
}
