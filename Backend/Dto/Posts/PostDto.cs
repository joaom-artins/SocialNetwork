using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Dto.Posts
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }=string.Empty;
        public string Content { get; set; }=string.Empty;
        public DateTime CreatedAt { get; set; }=DateTime.Now;
        public int UserId { get; set; }
        public List<Comment> Comments { get; set; }=new List<Comment>();
    }
}