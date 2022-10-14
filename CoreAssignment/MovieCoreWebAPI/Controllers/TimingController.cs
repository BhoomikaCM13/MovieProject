using CoreBL.Services;
using CoreEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimingController : ControllerBase
    {
        private TimingService _timingService;
        public TimingController(TimingService timingService)
        {
            _timingService = timingService;
        }
        [HttpGet("GetShowTiming")] //Attributes-the one above a method or property is called attribute
        public IEnumerable<ShowTiming> GetShowTiming()
        {
            return _timingService.GetTiming();
        }
        [HttpPost("AddTiming")]
        public IActionResult AddTiming([FromBody] ShowTiming show)
        {
            _timingService.AddTiming(show);
            return Ok("Timing created successfully!!");
        }
        [HttpDelete("DeleteTiming")]
        public IActionResult DeleteTiming(int id)
        {
            _timingService.DeleteTiming(id);
            return Ok("show deleted Successfully!!");
        }
        [HttpPut("UpdateTiming")]
        public IActionResult UpdateTiming([FromBody] ShowTiming show)
        {
            _timingService.UpdateTiming(show);
            return Ok("timing updated succesfully!!");
        }
        [HttpGet("GetTimingById")]
        public ShowTiming GetTimingById(int id)
        {
            return _timingService.GetSById(id);
        }

    }
}
