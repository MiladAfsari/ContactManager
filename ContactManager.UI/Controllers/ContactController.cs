using ContactManager.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.UI.Controllers
{
    public class ContactController : Controller
    {

        public async Task<IActionResult> Index()
        {
            var contentList = new Contact();
            var ImputJson = new Contact();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(ImputJson), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(Helper.Helper.ContactApiUrl + "/Get", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    contentList = JsonConvert.DeserializeObject<Contact>(apiResponse);
                }
            }

            return View(contentList);
        }
    }
}
