using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Comments
    {
        public int Id { get; set; }
        public string Content { get; set; }=string.Empty;
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}