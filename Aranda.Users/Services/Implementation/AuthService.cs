using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aranda.Users.BackEnd.Dtos;
using Aranda.Users.BackEnd.Helpers;
using Aranda.Users.BackEnd.Services.Definition;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Aranda.Users.BackEnd.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly AppSettings _appSettings;

        public AuthService(IOptions<AppSettings> appSettings, IUserService userService)
        {
            _appSettings = appSettings.Value;
            _userService = userService;
        }

        public UserDataDto Authenticate(string userName, string password)
        {
            var user = _userService.GetUser(userName, password);
            if (user == null) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKey = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature),

            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }
    }
}
