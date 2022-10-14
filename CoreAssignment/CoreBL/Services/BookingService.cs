using CoreData.Repository;
using CoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBL.Services
{
    public class BookingService
    {
        IBookingRepository _bookRepository;
        public BookingService(IBookingRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBooking(Booking book)
        {
            _bookRepository.AddBookingI(book);
        }


        public void UpdateBooking(Booking book)
        {
            _bookRepository.UpdateBookingI(book);
        }

        public void DeleteBooking(int Id)
        {
            _bookRepository.DeleteBookingI(Id);
        }

        public Booking GetBById(int id)
        {
          return  _bookRepository.GetB(id);
        }
        public IEnumerable<Booking> GetBooking()
        {
            return _bookRepository.GetBooking();
        }
    }
}
