using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }=string.Empty;
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public int UserId { get; set; }
        public int PostId { get; set; }
        public User? User { get; set; }
        public Post? Post { get; set; }
    }
}