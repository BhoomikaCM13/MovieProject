using CoreEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreData
{
    public class TheaterDAL
    {
        MoviedbContext db = null;


        public TheaterDAL(MoviedbContext db)

        {
            this.db = db;
        }

        public TheaterDAL()
        {
        }
        public string AddTheater(Theater theaters)
        {

            //db = new MoviedbContext();
            db.theaters.Add(theaters);
            db.SaveChanges();
            return "added";
        }
        public string UpdateTheater(Theater theaters)
        {
            //db = new MoviedbContext();
            db.Entry(theaters).State = EntityState.Modified;
            db.SaveChanges();
            return "updated";
        }
        public string DeleteTheater(int Id)
        {
            //db = new MoviedbContext();
            Theater TObj = db.theaters.Find(Id);
            db.Entry(TObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "deleted";
        }
        public List<Theater> ShowAllT()
        {
            //db = new MoviedbContext();
            List<Theater> TList = db.theaters.ToList();
            return TList;
        }
    }   
}
