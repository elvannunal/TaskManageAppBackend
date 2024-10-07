

using Microsoft.EntityFrameworkCore;
using TaskStream.DataAccessLayer.Data;
using TaskStream.DataAccessLayer.Interfaces;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.DataAccessLayer.Repositories;

public class UserTaskRepository: GenericRepository<UserTask>, IUserTaskRepository
{
    private readonly ApplicationDbContext _context;

    public UserTaskRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserTask>> GetTasksByTeamIdAsync(Guid teamId)
    {
        return await _context.UserTask.Where(t => t.TeamId == teamId).ToListAsync();
    }

    public async Task<IEnumerable<UserTask>> GetTasksUserIdAsync(Guid userId)
    {
        return await _context.UserTask.Where(u => u.AssigneeId == userId).ToListAsync();
    }
}