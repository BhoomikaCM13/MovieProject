using CoreData.Repository;
using CoreEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreBL.Services
{
    public class UserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.AddUserI(user);
        }


        public void UpdateUser(User user)
        {
            _userRepository.UpdateUserI(user);
        }

        public void DeleteUser(int Id)
        {
            _userRepository.DeleteUserI(Id);
        }

        public User GetUById(int id)
        {
            return _userRepository.GetU(id);
        }
        public IEnumerable<User> GetUser()
        {
            return _userRepository.GetUser();
        }
    }
}
