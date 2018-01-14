using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public RoleDto Role { get; set; }
    }
}
