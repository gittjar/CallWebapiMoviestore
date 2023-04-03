using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using call_webapi_aspnet.Models;
using Newtonsoft.Json;

namespace call_webapi_aspnet.Controllers;

public class HomeController : Controller
{


        public async Task<IActionResult> Index()
        {
            List<Burger> boatList = new List<Burger>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://raw.githubusercontent.com/gittjar/products/main/db_burger.json"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    boatList = JsonConvert.DeserializeObject<List<Burger>>(apiResponse);
                }
            }
            return View(boatList);
        }
    }


