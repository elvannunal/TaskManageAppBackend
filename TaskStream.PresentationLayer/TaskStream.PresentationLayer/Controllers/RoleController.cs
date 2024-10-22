using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskStream.EntityLayer.Dtos;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.PresentationLayer.Controllers;



[Route("api/[controller]")]
public class RoleController : Controller
{
    private readonly RoleManager<IdentityRole> _roleManager;

    private readonly UserManager<ApplicationUser> _userManager;

    public RoleController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var roles = await _roleManager.Roles.ToListAsync();  
        return Ok(roles);
    }
    [HttpPost("create-role")]
    public async Task<IActionResult> CreateRole([FromQuery] string roleName)
    {
        if (string.IsNullOrEmpty(roleName))
        {
            return BadRequest("Role name cannot be empty.");
        }

        if (await _roleManager.RoleExistsAsync(roleName))
        {
            return Conflict("Role already exists.");
        }

        var role = new IdentityRole(roleName);
        await _roleManager.CreateAsync(role);
    
        return Ok(new { message = "Role created successfully!" });
    }


    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignRole([FromBody] RoleAssignmentRequestDto requestDto)
    {
        var user=await _userManager.FindByIdAsync(requestDto.UserId);
        if (user == null)
            return NotFound("User not found!");

        if (!await _roleManager.RoleExistsAsync(requestDto.RoleName))
            return BadRequest("Role does not exist.");

        await _userManager.AddToRoleAsync(user, requestDto.RoleName);
        return Ok(new { mesagge = "Role assigned successfully!" });
        
    }

    [HttpDelete("remove-role")]
    public async Task<IActionResult> RemoveUserRole(string userId, string userRole)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return NotFound("User not found");

        if (!await _roleManager.RoleExistsAsync(userRole))
            return BadRequest(new { message = "Role does not exist!" });

        await _userManager.RemoveFromRoleAsync(user, userRole);
        return Ok(new { message = "User role deleted successfully!" });
    }
}