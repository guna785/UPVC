using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.SchemaModel;
using BL.Services;
using DAL.Helper;
using DAL.Madals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace upvcDesign.Controllers
{
    public class SuplierController : Controller
    {
        private readonly ISuplierRepo _repo;
        public SuplierController(ISuplierRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> AddSuplier([FromBody] AddSuplier emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Request Not Completed");
            }
            var Suplier = new suplier();
            Suplier.address = emp.address;
            Suplier.cdate = DateTime.Now;
            Suplier.pan = emp.pan;
            Suplier.gst = emp.gst;
            Suplier.name = emp.name;
            Suplier.email = emp.email;
            Suplier.status = "active";
            Suplier.phone = emp.phone;

            var res = await _repo.InserSuplier(Suplier);

            if (res.Contains("successfull"))
            {
                var result = new { status = res };
                return Ok(result);
            }
            else
            {
                return BadRequest("Request Not Completed");
            }

        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> EditSuplier([FromBody] EditSuplier emp)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Request Not Completed");
            }
            var Suplier = new suplier();
            Suplier.address = emp.address;
            Suplier.cdate = DateTime.Now;
            Suplier.pan = emp.pan;
            Suplier.gst = emp.gst;
            Suplier.name = emp.name;
            Suplier.email = emp.email;
            Suplier.status = "active";
            Suplier.phone = emp.phone;

            var res = await _repo.UpdateSuplier(Suplier);

            if (res.Contains("successfull"))
            {
                var result = new { status = res };
                return Ok(result);
            }
            else
            {
                return BadRequest("Request Not Completed");
            }

        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> DeleteSuplier([FromBody]string id)
        {
            var res = await _repo.DeleteSuplier(id);
            if (res.Contains("successfull"))
            {
                var result = new { status = res };
                return Ok(result);
            }
            else
            {
                return BadRequest("Request Not Completed");
            }

        }
    }
}