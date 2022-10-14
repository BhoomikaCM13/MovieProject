using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CoreEntity;
using System.Collections.Generic;

namespace MovieCoreMvc_UI.Controllers
{
    public class TheaterController : Controller
    {
        private IConfiguration _configuration;
        public TheaterController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Theater> theaterresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Theater/GetTheaters";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theaterresult = JsonConvert.DeserializeObject<IEnumerable<Theater>>(result);
                    }
                }
            }
            return View(theaterresult);
        }
        public IActionResult TheaterEntry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TheaterEntry(Theater theater)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theater), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Theater/AddTheater";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Theater details saved successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "wrong entries";
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> EditTheater(int Id)
        {
            Theater theater = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Theater/GetTheaterById?Id=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theater = JsonConvert.DeserializeObject<Theater>(result);
                    }
                }
            }
            return View(theater);
        }

        [HttpPost]
        public async Task<IActionResult> EditTheater(Theater theater)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(theater), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Theater/UpdateTheater";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Theater details saved successfully";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "wrong entries";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteTheater(int Id)
        {
            Theater theater = null;
            using (HttpClient client = new HttpClient())
            {
                
                string endPoint = _configuration["WebApiBaseUrl"] + "Theater/GetTheaterById?Id=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        theater = JsonConvert.DeserializeObject<Theater>(result);
                    }

                }

            }
            return View(theater);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTheater(Theater theater)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Theater/DeleteTheater?id=" + theater.Id;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Sayonara <3";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "wrong entries";
                    }
                }
            }
            return View();
        }
    }
}
