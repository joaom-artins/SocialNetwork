using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dto.Posts;
using Backend.Model;

namespace Backend.Mapper
{
    public static class PostMapper
    {
        public static PostDto ToPostDto(this Post post)
        {
            return new PostDto
            {
                Id=post.Id,
                Title=post.Title,
                Content=post.Content,
                CreatedAt=post.CreatedAt,
                UserId=post.UserId,
                Comments=[]
            };
        }
    }
}