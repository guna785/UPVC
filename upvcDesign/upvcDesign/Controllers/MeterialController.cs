using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.SchemaModel;
using BL.Services;
using DAL.Madals;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace upvcDesign.Controllers
{
    [Authorize]
    public class MeterialController : Controller
    {
        private readonly IMeterialTypeRepo _repo;
        public MeterialController(IMeterialTypeRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddMaterialType([FromBody] MaterialType emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Request Not Completed");
            }
            var mtype = new MeterialType();

            mtype.cdate = DateTime.Now;

            mtype.name = emp.name;

            var res = await _repo.InserMaterialType(mtype);

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
        [Authorize]
        public async Task<IActionResult> DeleteMaterialType([FromBody]string id)
        {
            var res = await _repo.DeleteMaterialType(id);
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