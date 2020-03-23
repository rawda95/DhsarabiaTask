using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
                var employees = JsonConvert.DeserializeObject<EmployeeModel>(responseData);

                return View(employees);


            }


            else
            {
                return View();
            }


        }


        public async Task<IActionResult> Add(EmployeeModel employee)
        {
            if(employee.FirstName==null)
            {
                return Json(new { message = "Validation Failed",error="First name is requierd"});
                
            }
            else
            {
                var url = apiUrl + "/AddEmployee";
                StringContent content = new StringContent(JsonConvert.SerializeObject(employee));
                HttpResponseMessage responseMessage = await client.PostAsync(url,content);

                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                    return Json(responseData);

                }
                else
                {
                    return Json(responseMessage);
                }
            }
            

        }
        public async Task<IActionResult> test()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);

            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                return Json(responseData);

            }
            else
                return Json(new {error="erro" });
        }

    }
}