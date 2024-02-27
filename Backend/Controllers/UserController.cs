using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dto.User;
using Backend.Mapper;
using Backend.Model;
using Backend.Repository;
using Backend.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepository)
        {
            _userRepo=userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users=await _userRepo.GetAllAsync();
            var userDtos=users.Select(a=>a.ToUserDto());
            return Ok(userDtos);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBydId([FromRoute]int id)
        {
            var userId= await _userRepo.GetByIdAsync(id);
            if(userId is null) return NotFound();
            return Ok(userId.ToUserDto());
        } 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatedUserDto createdUserDto)
        {
           var userModel=createdUserDto.ToCreatedFromUser();
           await _userRepo.CreateAsync(userModel);
           return CreatedAtAction(nameof(GetBydId),new{id=userModel.Id},userModel.ToUserDto());
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromRoute]int id,[FromBody] UpdateUserRequestDto update)
        {
            var userModel=await _userRepo.UpdateAsync(update,id);
            if(userModel is null) return NotFound();
            return Ok(userModel.ToUserDto());
        }  
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var userModel=await _userRepo.RemoveAsync(id);
             if(userModel is null) return NotFound();
            return NoContent();
        }
    }
}