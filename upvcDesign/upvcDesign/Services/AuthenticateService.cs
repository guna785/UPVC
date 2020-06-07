using DAL.Helper;
using DAL.Madals;
using DAL.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using upvcDesign.Helper;

namespace upvcDesign.Services
{
    public interface IAuthenticateService
    {
        Task<AunthenticatedModel> Authenticate(string username, string password);
        string GenerateJwtToken(string username, string role);
    }
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;
        private readonly IAthenticate _athenticate;

        public AuthenticateService(IOptions<AppSettings> appSettings, IAthenticate athenticate)
        {
            _appSettings = appSettings.Value;
            _athenticate = athenticate;
        }
        public async Task<AunthenticatedModel> Authenticate(string username, string password)
        {
            var user =await _athenticate.authenticateuser(username,password);

            // return null if user not found
            if (user == null)
                return null;


            var token = GenerateJwtToken(user.uname, user.role);
            var jwtToken = new JwtToken() { RefreshToken = new RefreshTokenGenerator().GenerateRefreshToken(32), Token =  token};
            user.Token = jwtToken;
            return user;
        }
        public string GenerateJwtToken(string username,string role)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),               
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
