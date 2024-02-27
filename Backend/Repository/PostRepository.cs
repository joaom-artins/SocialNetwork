using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dto.Posts;
using Backend.Model;
using Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _context;
        public PostRepository(AppDbContext context)
        {
            _context=context;
        }
        public async Task<List<Post>> GetAllAsync()
        {
            var posts= await _context.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            var postId=await _context.Posts.FindAsync(id);
            if(postId is null) return null;
            return postId;
        }
        public async Task<Post> CreateAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }
        public async Task<Post?> UpdateAsync(UpdatePostDto updatePost, int id)
        {
            var authorModel=await _context.Posts.FindAsync(id);
            if(authorModel is null) return null;
            authorModel.Title=updatePost.Title;
            authorModel.Content=updatePost.Content;
            await _context.SaveChangesAsync();
            return authorModel;
        }
        public async Task<Post?> RemoveAsync(int id)
        {
            var authorModel=await _context.Posts.FindAsync(id);
            if(authorModel is null) return null;
            return authorModel;
        }
    }
}