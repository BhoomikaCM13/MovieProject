using CoreBL.Services;
using CoreEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookingService _bookService;
        public BookController(BookingService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("GetBookings")] //Attributes-the one above a method or property is called attribute
        public IEnumerable<Booking> GetBookings()
        {
            return _bookService.GetBooking();
        }
        [HttpPost("AddBooking")]
        public IActionResult AddBooking([FromBody] Booking book)
        {
            _bookService.AddBooking(book);
            return Ok("booking created successfully!!");
        }
        [HttpDelete("DeleteBooking")]
        public IActionResult DeleteBooking(int id)
        {
            _bookService.DeleteBooking(id);
            return Ok("booking deleted Successfully!!");
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking([FromBody] Booking book)
        {
            _bookService.UpdateBooking(book);
            return Ok("booking updated succesfully!!");
        }
        [HttpGet("GetBookingById")]
        public Booking GetBookingById(int id)
        {
            return _bookService.GetBById(id);
        }
    }
}
