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
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientRepo _repo;
        public ClientController(IClientRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> AddClient([FromBody] AddClient emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Request Not Completed");
            }
            var Client = new client();
            Client.address = emp.address;
            Client.cdate = DateTime.Now;
            Client.pan =emp.pan;
            Client.gst = emp.gst;
            Client.name = emp.name;
            Client.email = emp.email;
            Client.status = "active";
            Client.phone = emp.phone;

            var res = await _repo.InserClient(Client);

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
        public async Task<IActionResult> EditClient([FromBody] EditClient emp)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Request Not Completed");
            }
            var Client = new client();
            Client.address = emp.address;
            Client.cdate = DateTime.Now;
            Client.pan = emp.pan;
            Client.gst = emp.gst;
            Client.name = emp.name;
            Client.email = emp.email;
            Client.status = "active";
            Client.phone = emp.phone;

            var res = await _repo.UpdateClient(Client);

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
        public async Task<IActionResult> DeleteClient([FromBody]string id)
        {
            var res = await _repo.DeleteClient(id);
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