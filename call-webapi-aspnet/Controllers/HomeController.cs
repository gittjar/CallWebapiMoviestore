using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using call_webapi_aspnet.Models;
using Newtonsoft.Json;

namespace call_webapi_aspnet.Controllers;

public class HomeController : Controller
{


        public async Task<IActionResult> Index()
        {
            List<Movie> movieList = new List<Movie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://movieapi2023.azurewebsites.net/api/Movies"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    movieList = JsonConvert.DeserializeObject<List<Movie>>(apiResponse);
                }
            }
            return View(movieList);
        }
    }


