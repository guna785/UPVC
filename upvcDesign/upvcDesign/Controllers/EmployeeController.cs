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
using MongoDB.Driver;

namespace upvcDesign.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmpRepo _repo;
        public EmployeeController(IEmpRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Authorize(Roles =Role.Admin)]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmp emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Request Not Completed");
            }
            var employee = new user();
            employee.address = emp.address;
            employee.cdate = DateTime.Now;
            employee.dob = DateTime.Now;
            employee.joindate = DateTime.Now;
            employee.name = emp.name;
            employee.email = emp.email;
            employee.password = emp.password;
            employee.phone = emp.phone;
            employee.remarks = "none";
            employee.role = emp.role;
            employee.uname = emp.uname;
            
            var res =await _repo.InserEmployee(employee);
            
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
        public async Task<IActionResult> EditEmployee([FromBody] EditEmp emp)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Request Not Completed");
            }
            var employee = new user();
            employee.address = emp.address;
            employee.cdate = DateTime.Now;
            employee.dob = DateTime.Now;
            employee.joindate = DateTime.Now;
            employee.name = emp.name;
            employee.email = emp.email;
            employee.password = emp.password;
            employee.phone = emp.phone;
            employee.remarks = "none";
            employee.role = emp.role;
            employee.uname = emp.uname;

            var res = await _repo.UpdateEmployee(employee);

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
        public async Task<IActionResult> DeleteEmployee([FromBody]string id)
        {
            var res =await _repo.DeleteEmployee(id);
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