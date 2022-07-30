using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace AFS_.NET_Developer_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // this is JQuery Controller to generate tables and display data with Calls().
    public class test : ControllerBase
    {
        private readonly ProjectContext _context;
        private readonly IJQueryService _jqueryServices;
        public test(ProjectContext context, IJQueryService jqueryserrvice)
        {
            _context = context;
            _jqueryServices = jqueryserrvice;

        }
        [HttpPost]
        public IActionResult Calls()
        {
            //for seaching-sorting 
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);
            var seachValue = Request.Form["search[value]"];
            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];


            // Getting All Records using delegate(GetAll) && provide filteration as lambda expression(optional)
            IQueryable<Contents> call = _jqueryServices.
                GetAll((m => m.text.Contains(seachValue)&&m.IsActive==true));//IQuerable is used to allow pagination before getting the data from database
            
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))//checking if there is sorting or not
            {
                call = call.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));
            }
            var data = call.Skip(skip).Take(pageSize).ToList();//getting data after using IQueryable 
            var recordsTotal = call.Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };

            return Ok(jsonData);
        }
    }


 
}
