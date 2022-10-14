using CoreEntity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieCoreMvc_UI.Controllers
{
    public class ShowTimingController : Controller
    {
        private IConfiguration _configuration;
        public ShowTimingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            IEnumerable<ShowTiming> showresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Timing/GetShowTiming";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        showresult = JsonConvert.DeserializeObject<IEnumerable<ShowTiming>>(result);
                    }
                }
            }
            return View(showresult);
        
    }
        public IActionResult ShowTimingEntry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShowTimingEntry(ShowTiming show)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(show), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Timing/AddTiming";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Show details saved successfully";
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

        public async Task<IActionResult> EditShow(int Id)
        {
            ShowTiming show = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Timing/GetTimingById?Id=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        show = JsonConvert.DeserializeObject<ShowTiming>(result);
                    }
                }
            }
            return View(show);
        }

        [HttpPost]
        public async Task<IActionResult> EditShow(ShowTiming show)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(show), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Timing/UpdateTiming";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Movie details saved successfully";
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

        public async Task<IActionResult> DeleteShow(int Id)
        {
            ShowTiming show = null;
            using (HttpClient client = new HttpClient())
            {

                string endPoint = _configuration["WebApiBaseUrl"] + "Timing/GetTimingById?Id=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        show = JsonConvert.DeserializeObject<ShowTiming>(result);
                    }

                }

            }
            return View(show);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteShow(ShowTiming show)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Timing/DeleteTiming?id=" + show.Id;
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
