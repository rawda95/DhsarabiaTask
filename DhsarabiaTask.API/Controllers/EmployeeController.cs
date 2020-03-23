using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using AutoMapper;
using DhsarabiaTask.API.Models;
using DhsarabiaTask.Data.Models;
using DhsarabiaTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace DhsarabiaTask.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        private readonly IMapper mapper; 

        public EmployeeController(IEmployeeServices employeeServices, IMapper mapper)
        {
            this.employeeServices = employeeServices;
            this.mapper = mapper; 
        }

        [HttpGet]
        [Route("GetEmployees")]
        public List<DTOEmployee> GetEmployees()
        {
            var employees = this.employeeServices.GetEmployees();
            return mapper.Map<List<Employee>, List<DTOEmployee>>(employees);
        }

        [HttpPost]
        [ResponseType(typeof(DTOEmployee))]
        public ActionResult AddEmployee(DTOEmployee DTOEmployee)

        {
            if(DTOEmployee.FirstName==null )
            {
                return Json(new { message = "Validation Failed",error="First name is requierd"});
            }
            try
            {
                var employee = mapper.Map<DTOEmployee, Employee>(DTOEmployee);
                var InsertResult = this.employeeServices.Insert(employee);
                if(InsertResult)
                {
                    return Ok();

                }
                else
                {
                    return Json(new { error = "An error across while add employee please try again later." });

                }

            }
            catch(Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }


    }
}