using CoreBL.Services;
using CoreEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet("GetUsers")] //Attributes-the one above a method or property is called attribute
        public IEnumerable<User> GetUsers()
        {
            return _userService.GetUser();
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] User user)
        {
            _userService.AddUser(user);
            return Ok("User created successfully!!");
        }
        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok("User deleted Successfully!!");
        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            _userService.UpdateUser(user);
            return Ok("user updated succesfully!!");
        }
        [HttpGet("GetUserById")]
        public User GetUserById(int id)
        {
            return _userService.GetUById(id);
        }
    }
}
