using System;
using System.Collections.Generic;
using System.Text;
using Shop.Core.DTO;
using Shop.Core.Repositories;
using Shop.Core.Domain;

namespace Shop.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Login(string email, string password)
        {
            var user = _userRepository.Get(email);
            if (user == null)
            {
                throw new Exception($"User '{email}' was not found");
            }
            if(user.Password != password)
            {
                throw new Exception($"Inwalid password");
            }
        }

            public void Register(string email, string password, RoleDto role)
        {
            var user = _userRepository.Get(email);
            if(user != null)
            {
                throw new Exception($"User '{email}' already exist");
            }
            var userRole = Enum.Parse(typeof(Role), role.ToString(), true);
            user = new Domain.User(email, password);
            _userRepository.Add(user);
        }
    }
}
