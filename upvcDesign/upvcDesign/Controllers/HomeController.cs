using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BL.Services;
using DAL.Madals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using upvcDesign.Models;

namespace upvcDesign.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IEmpRepo _repo;
        public HomeController(IEmpRepo repo)
        {
            _repo = repo;
        }        
        public async Task<IActionResult> Index()
        {
            var adm = new user()
            {
                cdate = DateTime.Now,
                email = "ashok@b2lsolution.in",
                password = "ashok@123",
                phone = "8124632756",
                name = "ashok",
                remarks = "none",
                role = "user",
                uname = "ashok"
            };
            var res = await _repo.InserEmployee(adm);
           return View();

        }

        public IActionResult Employees()
        {
            return View();
        }

      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
