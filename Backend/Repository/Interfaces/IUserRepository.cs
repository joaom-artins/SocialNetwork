using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dto.User;
using Backend.Model;

namespace Backend.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<User?> UpdateAsync(UpdateUserRequestDto updateUserRequestDto,int id);
        Task<User?> RemoveAsync(int id);
        Task<bool> UserExists(int id);
    }
}