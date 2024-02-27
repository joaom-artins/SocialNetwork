using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Repository.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment comment,int userId,int postId);
        Task<Comment> UpdateAsync(Comment comment,int id);
        Task<Comment> RemoveAsync(int id);
    }
}