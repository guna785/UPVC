using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BL.Repository;
using BL.Services;
using DAL.DbContexts;
using DAL.Madals;
using DAL.Repositories;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using upvcDesign.Models;

namespace upvcDesign.Controllers
{
    public class HomeController : Controller
    {
        IAdminRepo _repo;
        public HomeController(IAdminRepo repo)
        {
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var adm = new admin()
            {
                cdate = DateTime.Now,
                email = "guna@b2lsolution.in",
                password = "guna",
                phone = "8124632756",
                name = "guna",
                remarks = "none",
                role = "admin",
                uname = "guna"
            };
            var res = await _repo.InserAdmin(adm);
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
