using CoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreData.Repository
{
    public interface IUserRepository
    {
        void AddUserI(User users);
        void UpdateUserI(User user);
        void DeleteUserI(int Id);
        User GetU(int Id);
        IEnumerable<User> GetUser();
    }
}
