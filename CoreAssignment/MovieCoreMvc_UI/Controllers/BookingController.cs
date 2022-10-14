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
    public class BookingController : Controller
    {
        private IConfiguration _configuration;
        public BookingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Booking> bookresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Book/GetBookings";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        bookresult = JsonConvert.DeserializeObject<IEnumerable<Booking>>(result);
                    }
                }
            }
            return View(bookresult);
        }
        public IActionResult BookingEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BookingEntry(Booking book)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Book/AddBooking";
                using (var response = await client.PostAsync(endPoint, content))
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

        public async Task<IActionResult> EditBooking(int Bid)
        {
            Booking booking = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Book/GetBookingById?Id=" + Bid;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        booking = JsonConvert.DeserializeObject<Booking>(result);
                    }
                }
            }
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> EditBooking(Booking booking)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "Book/UpdateBooking";
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


        public async Task<IActionResult> DeleteBooking(int Id)
        {
            Booking book = null;
            using (HttpClient client = new HttpClient())
            {
                
                string endPoint = _configuration["WebApiBaseUrl"] + "Book/GetBookingById?Id=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        book = JsonConvert.DeserializeObject<Booking>(result);
                    }

                }

            }
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBooking(Booking book)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "Book/DeleteBooking?id=" + book.Bid;
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
