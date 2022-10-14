using CoreEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreData
{
    public class UserDL
    {
        MoviedbContext db = null;


        public UserDL(MoviedbContext db)

        {
            this.db = db;
        }

        public UserDL()
        {
        }
        public string AddUser(User user)
        {

            //db = new MoviedbContext();
            db.users.Add(user);
            db.SaveChanges();
            return "added";
        }
        public string UpdateUser(User user)
        {
            //db = new MoviedbContext();
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return "updated";
        }
        public string DeleteUser(int Id)
        {
            //db = new MoviedbContext();
            User TObj = db.users.Find(Id);
            db.Entry(TObj).State = EntityState.Deleted;
            db.SaveChanges();
            return "deleted";
        }
        public List<User> ShowAllU()
        {
            //db = new MoviedbContext();
            List<User> TList = db.users.ToList();
            return TList;
        }
    }
}
