using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DAL.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using upvcDesign.Models;
using upvcDesign.Services;

namespace upvcDesign.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthenticateService _authenticate;
        private readonly IUserRefreshTokenRepository _userRefreshToken;
        private readonly IConfiguration _configuration;

        public LoginController(IAuthenticateService authenticate, IUserRefreshTokenRepository userRefreshToken, IConfiguration configuration)
        {
            _authenticate = authenticate;
            _userRefreshToken = userRefreshToken;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginSubmit()
        {
            var uname = HttpContext.Request.Form["Username"];
            var pass = HttpContext.Request.Form["Password"];
            var res = await Authenticate(new AuthenticateModel() { Username = uname, Password = pass });
            if (res.Equals("success"))
            {
                return Redirect("/Home/");
            }
            else
            {
                return Unauthorized(res);
            }

        }

        [AllowAnonymous]
        public async Task<string> Authenticate(AuthenticateModel model)
        {
            if (!ModelState.IsValid)
            {
                return "Required Fields not Filled";
            }
            var usr = await _authenticate.Authenticate(model.Username, model.Password);

            if (usr == null)
                return "Username or password is incorrect";

            HttpContext.Session.SetString("JWToken", usr.Token.Token);
            _userRefreshToken.SaveOrUpdateUserRefreshToken(new Helper.UserRefreshToken() { RefreshToken = usr.Token.RefreshToken, UserName = usr.uname });

            return "success";
        }
        [HttpPost]
        [Route("refreshtoken")]
        public async Task<IActionResult> UserRefreshToken([FromBody] JwtToken jwtToken)
        {
            if (jwtToken == null)
            {
                return BadRequest("Invalid request");
            }
            var handler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            IPrincipal principal = handler.ValidateToken(jwtToken.Token, GetTokenValidationparameter(), out validatedToken);
            var userName = principal.Identity.Name;
            if (_userRefreshToken.CheckIfRefreshTokenIsValid(userName, jwtToken.RefreshToken))
            {
                var role = principal.IsInRole(Role.Admin) ? Role.Admin : Role.User;
                var token = _authenticate.GenerateJwtToken(userName, role);
                HttpContext.Session.SetString("JWToken", token);
                var newjwtToken = new JwtToken() { RefreshToken = new RefreshTokenGenerator().GenerateRefreshToken(32), Token = token };
                _userRefreshToken.SaveOrUpdateUserRefreshToken(new Helper.UserRefreshToken() { RefreshToken = newjwtToken.RefreshToken, UserName = userName });
                return Ok(newjwtToken);

            }
            return BadRequest("Invalid Request");
        }

        private TokenValidationParameters GetTokenValidationparameter()
        {

            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWToken");
            return Redirect("/Login/");
        }
    }
}