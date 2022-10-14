using CoreEntity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.InteropServices;

namespace CoreData
{
    public class ShowTimingDL
    {

        MoviedbContext db = null;


        public ShowTimingDL(MoviedbContext db)

        {
            this.db = db;
        }

        public ShowTimingDL()
        {
        }
        public string AddShowtiming(ShowTiming showTiming)
        {

            //db = new MoviedbContext();
            db.showTimings.Add(showTiming);
            db.SaveChanges();
            return "added";
        }
        public string UpdateTiming(ShowTiming showtiming)
        {
            //db = new MoviedbContext();
            db.Entry(showtiming).State = EntityState.Modified;
            db.SaveChanges();
            return "updated";
        }
        public string DeleteTiming(int Id)
        {
            //db = new MoviedbContext();
            ShowTiming Obj = db.showTimings.Find(Id);
            db.Entry(Obj).State = EntityState.Deleted;
            db.SaveChanges();
            return "deleted";
        }
        public List<ShowTiming> ShowAllT()
        {
            //db = new MoviedbContext();
            List<ShowTiming> SList = db.showTimings.ToList();
            return SList;
        }
    }
}
