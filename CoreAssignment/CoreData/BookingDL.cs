using CoreEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreData
{
    public class BookingDL
    {
        MoviedbContext db = null;


        public BookingDL(MoviedbContext db)

        {
            this.db = db;
        }

        public BookingDL()
        {
        }
        public string AddBooking(Booking book)
        {

            //db = new MoviedbContext();
            db.books.Add(book);
            db.SaveChanges();
            return "added";
        }
        public string UpdateBooking(Booking book)
        {
            //db = new MoviedbContext();
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return "updated";
        }
        public string DeleteBooking(int Id)
        {
            //db = new MoviedbContext();
            Booking TObj = db.books.Find(Id);
            db.Entry(TObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "deleted";
        }
        public List<Booking> ShowAllB()
        {
            //db = new MoviedbContext();
            List<Booking> TList = db.books.ToList();
            return TList;
        }
    }
}
