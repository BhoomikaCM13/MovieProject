using CoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreData.Repository
{
    public interface IBookingRepository
    {
        void AddBookingI(Booking book);
        void UpdateBookingI(Booking book);
        void DeleteBookingI(int Id);
        Booking GetB(int Id);
        IEnumerable<Booking> GetBooking();
    }
}
