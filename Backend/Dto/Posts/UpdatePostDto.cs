using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dto.Posts
{
    public class UpdatePostDto
    {
        public string Title { get; set; }=string.Empty;
        public string Content { get; set; }=string.Empty;
    }
}