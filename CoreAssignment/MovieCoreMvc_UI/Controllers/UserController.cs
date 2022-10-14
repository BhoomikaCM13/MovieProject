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
    public class UserController : Controller
    {
        private IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            IEnumerable<User> userresult = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "User/GetUsers";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        userresult = JsonConvert.DeserializeObject<IEnumerable<User>>(result);
                    }
                }
            }
            return View(userresult);
        }
        
        public IActionResult UserEntry()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserEntry(User user)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "User/AddUser";
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

        public async Task<IActionResult> EditUser(int Id)
        {
            User user = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "User/GetUserById?Id=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<User>(result);
                    }
                }
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(User user)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "User/UpdateUser";
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

        public async Task<IActionResult> DeleteUser(int Id)
        {
            User user = null;
            using (HttpClient client = new HttpClient())
            {
                
                string endPoint = _configuration["WebApiBaseUrl"] + "User/GetUserById?id=" + Id;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<User>(result);
                    }

                }

            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(User user)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "User/DeleteUser?id=" + user.Id;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "user details saved successfully";
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
