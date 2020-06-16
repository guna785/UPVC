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
    [Authorize(Roles =Role.Admin)]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepo _repo;
        public CompanyController(ICompanyRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Authorize(Roles = Role.Admin)]
        public async Task<IActionResult> CompnayProfileUpdate([FromBody] CompanyProfile emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Request Not Completed");
            }
            var cmp = new companyprofile();
            cmp.address = emp.address;
            cmp.cdate = DateTime.Now;
            cmp.pan = emp.pan;
            cmp.gst = emp.gst;
            cmp.name = emp.name;
            cmp.email = emp.email;
            cmp.accountno = emp.accountno;
            cmp.bankname = emp.bankname;
            cmp.branch = emp.branch;
            cmp.ifsccode = emp.ifsccode;
            
            cmp.phone = emp.phone;
            var cm = await _repo.GetCompany();
            if (cm.Count() == 0)
            {
                var res = await _repo.InserCompany(cmp);
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
            else
            {
                var res = await _repo.UpdateCompany(cmp);
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
}