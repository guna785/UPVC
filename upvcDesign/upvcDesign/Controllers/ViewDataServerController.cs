using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.DataTableModel;
using BL.Extention;
using BL.Services;
using DAL.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace upvcDesign.Controllers
{
    public class ViewDataServerController : Controller
    {
        IEmpRepo _repo;
        public ViewDataServerController(IEmpRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        [Authorize(Roles =Role.Admin)]
        public async Task<IActionResult> LoadEmployeeTables([FromBody]DtParameters dtParameters)
        {
            var searchBy = dtParameters.Search?.Value;

            var orderCriteria = string.Empty;
            var orderAscendingDirection = true;

            if (dtParameters.Order != null)
            {
                // in this example we just default sort on the 1st column
                orderCriteria = dtParameters.Columns[dtParameters.Order[0].Column].Data;
                orderAscendingDirection = dtParameters.Order[0].Dir.ToString().ToLower() == "asc";
            }
            else
            {
                // if we have an empty search then just order the results by Id ascending
                orderCriteria = "Id";
                orderAscendingDirection = true;
            }

            var result = await _repo.GetEmployee();

            if (!string.IsNullOrEmpty(searchBy))
            {
                result = result.Where(r => r.uname != null && r.uname.ToUpper().Contains(searchBy.ToUpper()) ||
                                           r.name != null && r.name.ToUpper().Contains(searchBy.ToUpper()) ||
                                           r.phone != null && r.phone.ToUpper().Contains(searchBy.ToUpper()) ||
                                           r.email != null && r.email.ToUpper().Contains(searchBy.ToUpper()) ||
                                           r.address != null && r.address.ToUpper().Contains(searchBy.ToUpper()) ||
                                           r.role != null && r.role.ToUpper().Contains(searchBy.ToUpper()))
                    .ToList();
            }

            result = orderAscendingDirection ? result.AsQueryable().OrderByDynamic(orderCriteria, DtOrderDir.Asc).ToList() : result.AsQueryable().OrderByDynamic(orderCriteria, DtOrderDir.Desc).ToList();

            // now just get the count of items (without the skip and take) - eg how many could be returned with filtering
            var filteredResultsCount = result.Count();
            var cntdb = await _repo.GetEmployee();
            var totalResultsCount = cntdb.Count();

            return Json(new
            {
                draw = dtParameters.Draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = result
                    .Skip(dtParameters.Start)
                    .Take(dtParameters.Length)
                    .ToList()
            });
        }
    }
}