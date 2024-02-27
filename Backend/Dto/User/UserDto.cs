using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }=string.Empty;
        public DateTime Born { get; set; }
        public List<Post> Posts { get; set; }=new List<Post>();
        public List<Comment> Comments { get; set; }=new List<Comment>();
    }
}