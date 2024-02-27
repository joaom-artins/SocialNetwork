using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dto.User;
using Backend.Model;

namespace Backend.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Id=user.Id,
                Username=user.Username,
                Born=user.Born,
                Posts=user.Posts,
                Comments=user.Comments
            };
        }
    }
}