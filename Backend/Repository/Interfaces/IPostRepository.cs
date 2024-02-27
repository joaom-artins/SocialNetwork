using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Repository.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAllAsync();
        Task<Post> GetByIdAsync(int id);
        Task<Post> CreateAsync(Post post);
        Task<Post> UpdateAsync(Post psot,int id);
        Task<Post> RemoveAsync(int id);
    }
}