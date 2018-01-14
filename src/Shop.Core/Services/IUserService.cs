using Shop.Core.Domain;
using Shop.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.Services
{
    public interface IUserService
    {
        void Login(string email, string password);
        void Register(string email, string password, RoleDto role);
    }
}
