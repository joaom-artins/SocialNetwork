using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Repository;
using Backend.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly UserRepository _userRepo;
        public UserController(UserRepository userRepository)
        {
            _userRepo=userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users=await _userRepo.GetAllAsync();
            return Ok(users);
        }
    }
}