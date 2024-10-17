using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskStream.BusinessLayer.Interfaces;
using TaskStream.DataAccessLayer.Interfaces;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userRepository)
        {
            _userService = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("teamId")]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetAllUsersByTeamId(Guid teamId)
        {
            var users = await _userService.GetUsersByTeamIdAsync(teamId);
            return Ok(users);
        }

        [HttpGet("userId")]
        public async Task<ActionResult<ApplicationUser>> GetUserById(string userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            return user;
        }
    }
}