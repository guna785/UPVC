using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using upvcDesign.Models;
using upvcDesign.Services;

namespace upvcDesign.Controllers
{
    public class LoginController : Controller
    {
        IAuthenticateService _authenticate;
        public LoginController(IAuthenticateService authenticate)
        {
            _authenticate = authenticate;
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
            var res = await Authenticate(new AuthenticateModel() {  Username=uname, Password=pass});
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
            var user = await _authenticate.Authenticate(model.Username, model.Password);

            if (user == null)
                return "Username or password is incorrect";

            return "success";
        }
    }
}