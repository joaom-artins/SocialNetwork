using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dto.User
{
    public class CreatedUserDto
    {
        public string Username { get; set; }=string.Empty;
        public string Password { get; set; }=string.Empty;
        public DateTime Born { get; set; }
    }
}