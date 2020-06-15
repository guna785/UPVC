﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BL.Extention;
using BL.SchemaModel;
using BL.Services;
using DAL.Helper;
using DAL.Madals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using upvcDesign.Helper;
using upvcDesign.Models;

namespace upvcDesign.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IEmpRepo _repo;
        IClientRepo _client;
        ISuplierRepo _suplier;
        private JSchema schema;

        public HomeController(IEmpRepo repo,IClientRepo clt,ISuplierRepo sup)
        {
            _repo = repo;
            _client = clt;
            _suplier = sup;
        }        
        public async Task<IActionResult> Index()
        {
           return View();
        }

       [Authorize(Roles =Role.Admin)]
        public IActionResult Employees()
        {
            return View();
        }
       
        [Authorize(Roles=Role.Admin)]
        public IActionResult Supliers()
        {
            return View();
        }
        [Authorize(Roles = Role.Admin)]
        public IActionResult Clients()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> ModelPopUp(string ID)
        {
            JSchemaGenerator generator = new JSchemaGenerator();

            // types with no defined ID have their type name as the ID            
            generator.SchemaIdGenerationHandling = SchemaIdGenerationHandling.TypeName;
            if (ID.Contains("AddEmp"))
            {
                schema = generator.Generate(typeof(AddEmp));
                ViewBag.modalTitle = "Add Employee";
            }
            else if (ID.Contains("EditEmployee"))
            {
                string ids = ID.Split('-')[1];
                schema = generator.Generate(typeof(EditEmp));
                var users = new EditEmp(await _repo.GetEmployeeByUsername(ids));
                ViewBag.values = Newtonsoft.Json.JsonConvert.SerializeObject(users);
                ViewBag.modalTitle = "Edit Employee";
            }
            else if (ID.Contains("AddClient"))
            {
                schema = generator.Generate(typeof(AddClient));
                ViewBag.modalTitle = "Add Client";
            }
            else if (ID.Contains("EditClient"))
            {
                string ids = ID.Split('-')[1];
                schema = generator.Generate(typeof(EditClient));
                var clt = new EditClient(await _client.GetClientByPan(ids));
                ViewBag.values = Newtonsoft.Json.JsonConvert.SerializeObject(clt);
                ViewBag.modalTitle = "Edit Client";
            }
            else if (ID.Contains("AddSup"))
            {
                schema = generator.Generate(typeof(AddSuplier));
                ViewBag.modalTitle = "Add Suplier";
            }
            else if (ID.Contains("EditSup"))
            {
                string ids = ID.Split('-')[1];
                schema = generator.Generate(typeof(EditSuplier));
                var clt = new EditSuplier(await _suplier.GetSuplierByPan(ids));
                ViewBag.values = Newtonsoft.Json.JsonConvert.SerializeObject(clt);
                ViewBag.modalTitle = "Edit Suplier";
            }

            ViewBag.schema = Newtonsoft.Json.JsonConvert.SerializeObject(schema);

            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
