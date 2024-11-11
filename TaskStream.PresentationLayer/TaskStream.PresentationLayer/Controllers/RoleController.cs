using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskStream.EntityLayer.Dtos;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.PresentationLayer.Controllers;

[Authorize]
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

    [HttpPost("create-role")]
    public async Task<IActionResult> CreateRole(string roleName)
    {
        if (await _roleManager.RoleExistsAsync(roleName))
        {
            return BadRequest("Role already exists.");
        }

        var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
        if (result.Succeeded)
        {
            return Ok(new { message = "Role created successfully." });
        }

        return BadRequest("Failed to create role.");
    }
    
    [Authorize(Policy = "AdminPolicy")]
    [HttpPost("assign-role")]
    public async Task<IActionResult> AssignRole([FromBody] RoleAssignmentRequestDto requestDto)
    {
        var user = await _userManager.FindByIdAsync(requestDto.UserId);
        if (user == null)
        {
            return NotFound("User not found!");
        }

        if (!await _roleManager.RoleExistsAsync(requestDto.RoleName))
        {
            return BadRequest("Role does not exist.");
        }

        var result = await _userManager.AddToRoleAsync(user, requestDto.RoleName);
        if (result.Succeeded)
        {
            return Ok(new { message = "Role assigned successfully!" });
        }

        return BadRequest("Failed to assign role.");
    }

    [HttpDelete("remove-role")]
    public async Task<IActionResult> RemoveUserRole(string userId, string userRole)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        if (!await _roleManager.RoleExistsAsync(userRole))
        {
            return BadRequest(new { message = "Role does not exist!" });
        }

        var result = await _userManager.RemoveFromRoleAsync(user, userRole);
        if (result.Succeeded)
        {
            return Ok(new { message = "User role deleted successfully!" });
        }

        return BadRequest("Failed to remove user role.");
    }
}
