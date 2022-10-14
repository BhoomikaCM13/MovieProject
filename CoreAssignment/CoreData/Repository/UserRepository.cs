using CoreEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreData.Repository
{
    public class UserRepository : IUserRepository
    {
        MoviedbContext _userdbContext;
        public UserRepository(MoviedbContext userDbContext)
        {
            _userdbContext = userDbContext;
        }
        public void AddUserI(User users)
        {
            _userdbContext.users.Add(users);
            _userdbContext.SaveChanges();
        }

        public void DeleteUserI(int Id)
        {
            var user = _userdbContext.users.Find(Id);
            _userdbContext.users.Remove(user);
            _userdbContext.SaveChanges();

        }

        public User GetU(int Id)
        {
            return _userdbContext.users.Find(Id);
        }

        public IEnumerable<User> GetUser()
        {
            return _userdbContext.users.ToList();
        }

        public void UpdateUserI(User user)
        {
            _userdbContext.Entry(user).State = EntityState.Modified;
            _userdbContext.SaveChanges();
        }
      

    }
}
