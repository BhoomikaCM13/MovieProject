using CoreBL.Services;
using CoreEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheaterController : ControllerBase
    {
        private TheaterService _theaterService;
        public TheaterController(TheaterService theaterService)
        {
            _theaterService = theaterService;
        }
        [HttpGet("GetTheaters")] //Attributes-the one above a method or property is called attribute
        public IEnumerable<Theater> GetTheaters()
        {
            return _theaterService.GetTheaters();
        }
        [HttpPost("AddTheater")]
        public IActionResult AddTheater([FromBody] Theater theater)
        {
            _theaterService.AddTheater(theater);
            return Ok("Theater created successfully!!");
        }
        [HttpDelete("DeleteTheater")]
        public IActionResult DeleteTheater(int id)
        {
            _theaterService.DeleteTheater(id);  
            return Ok("Theater deleted Successfully!!");
        }
        [HttpPut("UpdateTheater")]
        public IActionResult UpdateTheater([FromBody] Theater theater)
        {
            _theaterService.UpdateTheater(theater);
            return Ok("theater updated succesfully!!");
        }

        [HttpGet("GetTheaterById")]
        public Theater GetTheaterById(int id)
        {
            return _theaterService.GetTById(id);
        }

    }
}
