using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DhsarabiaTask.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult EmployeeList()
        {
            return View();
        }
    }
}