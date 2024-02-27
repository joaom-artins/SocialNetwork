using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Dto.User;
using Backend.Mapper;
using Backend.Model;
using Backend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context=context;
        }

         public async Task<List<User>> GetAllAsync()
        {
            var users= await _context.Users.Include(p=>p.Posts).Include(c=>c.Comments).ToListAsync();
            return users;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var userId=await _context.Users.Include(p=>p.Posts).Include(c=>c.Comments).FirstOrDefaultAsync(x=>x.Id==id);
            if(userId is null) return null;
            return userId;
        }
        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
        
        public async Task<User?> UpdateAsync(UpdateUserRequestDto userRequestDto, int id)
        {
           var userId=await _context.Users.FindAsync(id);
           if(userId is null) return null;
           userId.Username=userRequestDto.Username;
           userId.Password=userRequestDto.Password;
           userId.Born=userRequestDto.Born;
           await _context.SaveChangesAsync();
           return userId;
        }

        public async Task<User?> RemoveAsync(int id)
        {
            var userId=await _context.Users.FindAsync(id);
            if(userId is null) return null;
            _context.Users.Remove(userId);
            await _context.SaveChangesAsync();
            return userId;
        }

        public async Task<bool> UserExists(int id)
        {
            var userModel= await _context.Users.FindAsync(id);
            if(userModel is null) return false;
            return true;
        }
    }
}