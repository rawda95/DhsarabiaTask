using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DhsarabiaTask.Web.Controllers
{
    public class EmployeeController : Controller
    {
        string apiUrl = "https://localhost:44348" + "/Employee/tryUrl/";
        HttpClient client;

        public EmployeeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IActionResult EmployeeList()
        {
            return View();
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