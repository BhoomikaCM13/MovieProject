using CoreEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreData.Repository
{
   public class BookingRepository : IBookingRepository
    {
        MoviedbContext _bookdbContext;
        public BookingRepository(MoviedbContext bookDbContext)
        {
            _bookdbContext = bookDbContext;
        }

        public void AddBookingI(Booking book)
        {
            _bookdbContext.books.Add(book);
            _bookdbContext.SaveChanges();
        }

        public void DeleteBookingI(int id)
        {
            var book = _bookdbContext.books.Find(id);
            _bookdbContext.books.Remove(book);
            _bookdbContext.SaveChanges();
        }

        public Booking GetB(int id)
        {
            return _bookdbContext.books.Find(id);
        }

        public IEnumerable<Booking> GetBooking()
        {
            return _bookdbContext.books.ToList();
        }


        public void UpdateBookingI(Booking book)
        {
            _bookdbContext.Entry(book).State = EntityState.Modified;
            _bookdbContext.SaveChanges();
        }
    }
}
