using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DhsarabiaTask.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DhsarabiaTask.Web.Controllers
{
    public class EmployeeController : Controller
    {
        string apiUrl = "https://localhost:44348" + "/Employee";
        HttpClient client;

        public EmployeeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        }

        public async Task<IActionResult> EmployeeList()
        {
            var url = apiUrl+"/GetEmployees";
            HttpResponseMessage responseMessage = await client.GetAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                var employees = JsonConvert.DeserializeObject<List<EmployeeModel>>(responseData);

                return View(employees);


            }


            else
            {
                return View();
            }


        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeModel employee)
        {
            if(employee.FirstName==null)
            {
                return Json(new { message = "Validation Failed",error="First name is requierd"});
                
            }
            else
            {
                var url = apiUrl + "/AddEmployee";
                StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(url,content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var employeeResult = JsonConvert.DeserializeObject<EmployeeModel>(responseData);

                    return Json(  employeeResult);

                }
                else
                {
                    return Json(new { message = "Api error", error = "An error across while add employee please try again later." });

                    }
            }
            

        }



        [HttpPut]
        public async Task<IActionResult> Update(EmployeeModel employee)
        {
            if (employee.FirstName == null)
            {
                return Json(new { message = "Validation Failed", error = "First name is requierd" });

            }
            else
            {
                var url = apiUrl + "/EditEmployee";
                StringContent content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = await client.PutAsync(url, content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    return Json(responseData);

                }
                else
                {
                    return Json(new { message = "Api error", error = "An error across while add employee please try again later." });
                }
            }


        }

        [HttpDelete]
        public async Task<IActionResult>Delete(int EmployeeId)
        {
            var url = apiUrl + $"/DeleteEmployee/?EmployeeId={EmployeeId}";
            HttpResponseMessage responseMessage = await client.DeleteAsync(url);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                return Ok();

            }
            else
            {
                return Json(new { message = "Api error", error = "An error across while add employee please try again later." });
            }
        }


    }
}