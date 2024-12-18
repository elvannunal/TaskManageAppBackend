using Microsoft.AspNetCore.Mvc;
using TaskStream.BusinessLayer.Interfaces;
using TaskStream.DataAccessLayer.Interfaces;
using TaskStream.EntityLayer.Dtos;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]

public class TeamController:ControllerBase
{
    private readonly ITeamService _teamService;
    private readonly ILogger<TeamController> _logger;

    
    public TeamController(ITeamService teamService, ILogger<TeamController> logger)
    {
        _teamService = teamService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTeam()
    {
        try
        {
            var result =await _teamService.GetAllAsync();
            return Ok(result);
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeamById(Guid id)
    {
        try
        {
          var result = await _teamService.GetByIdAsync(id);
                if (result ==  null)
                {
                    return NotFound();
                } 
                return Ok(result);
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpPost("Create")]
    public async Task<IActionResult> AddTeam([FromBody]AddTeamDto addTeamDto)
    
    {
        try
        {
            if (addTeamDto == null)
            {
                return BadRequest("Team is null.");
            }

            var newTeam = new Team
            {
                Id = new Guid(),
                TeamLeadId = addTeamDto.TeamLeadId,
                TeamName = addTeamDto.TeamName
            };
            
            var result = _teamService.AddAsync(newTeam);
            
            if(result==null)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            
            return Ok(new { message = "Team added successfully" });
        }
        catch(Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
      
    }
    [HttpPut("Update")]
    public async Task<IActionResult> UpdateTeam(Guid id, Team team)
    {
        try
        {
            if (team == null || id == null)
            {
                return BadRequest();
            }

            var existingTeam =await _teamService.GetByIdAsync(id);
            if (existingTeam == null)
            {
                return NotFound();
            }

            var result = _teamService.UpdateAsync(team);
            if (result==null)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            
            if (result != null)
            {
                return Ok(new { message = "Team updated successfully" });

            }
            else
            {
                return NoContent();
            }
        }catch(Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteTeam(Guid id)
    {
        try
        {
            var existingItem = await _teamService.GetByIdAsync(id);
        
            if (existingItem == null)
            {
                return NotFound(new { message = "Team not found." });
            }
        
            var isDeleted = await _teamService.DeleteAsync(id);
        
            if (isDeleted)
            {
                return Ok(new { message = "Team deleted successfully" });

            }
            return StatusCode(500, new { message = "An error occurred while deleting the team." });

        }
        catch (Exception ex)
        {
           
            _logger.LogError(ex, "An error occurred while deleting the team with ID {id}", id);

            return StatusCode(500, new { message = $"Internal server error: {ex.Message}" });
        }
    }


}