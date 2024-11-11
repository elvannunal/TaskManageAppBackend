using Microsoft.AspNetCore.Mvc;
using TaskStream.BusinessLayer.Interfaces;
using TaskStream.EntityLayer.Dtos;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IUserTaskService _service;
        private readonly IUserService _userService;

        public TaskController(IUserTaskService service, IUserService userService)
        {
            _service = service;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("teamId/{teamId}")]
        public async Task<IActionResult> GetTasksByTeamId(Guid teamId)
        {
            try
            {
                var tasks = await _service.GetTasksByTeamIdAsync(teamId);
                if (tasks == null || !tasks.Any())
                {
                    return NotFound(new { message = "No tasks found for this team." });
                }
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        
        [HttpGet("userTasks")]
        public async Task<IActionResult> GetTasksByUserId(Guid userId)
        {
            try
            {
                var tasks = await _service.GetTasksUserIdAsync(userId);
                if (tasks == null || !tasks.Any())
                {
                    return NotFound(new { message = "No tasks found for this user." });
                }
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(Guid id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null)
                {
                    return NotFound(new { message = "Task not found." });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            try
            {
                if (createTaskDto == null)
                {
                    return BadRequest("Task is null!");
                }

                var userTask = new UserTask
                {
                    UserTaskName = createTaskDto.UserTaskName,
                    Description = createTaskDto.Description,
                    Status = (TaskStatus)createTaskDto.Status,
                    AssigneeId = createTaskDto.AssigneeId,
                    TeamId = createTaskDto.TeamId
                };
                var result = await _service.AddAsync(userTask);
                if (result == null)
                {
                    return StatusCode(500, "Failed to create task");
                }
                return Ok(new { message = "Task created successfully", userTask });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTask updateTask, Guid id)
        {
            try
            {
                if (updateTask == null || id == Guid.Empty)
                {
                    return BadRequest("Invalid input.");
                }

                var existingTask = await _service.GetByIdAsync(id);
                if (existingTask == null)
                {
                    return NotFound(new { message = "Task not found." });
                }

                existingTask.UserTaskName = updateTask.UserTaskName;
                existingTask.Description = updateTask.Description;
                existingTask.Status = updateTask.Status;
                existingTask.AssigneeId = updateTask.AssigneeId;
                existingTask.TeamId = updateTask.TeamId;

                var result = await _service.UpdateAsync(existingTask);
                if (result == null)
                {
                    return StatusCode(500, "Failed to update task");
                }
                return Ok(new { message = "Task updated successfully", result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            try
            {
                var existingItem = await _service.GetByIdAsync(id);
                if (existingItem == null)
                {
                    return NotFound(new { message = "Task not found." });
                }

                bool isDeleted = await _service.DeleteAsync(id);
                if (!isDeleted)
                {
                    return StatusCode(500, new { message = "An error occurred while deleting the task." });
                }

                return Ok(new { message = "Task deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
