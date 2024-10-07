using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskStream.DataAccessLayer.Data;
using TaskStream.DataAccessLayer.Interfaces;
using TaskStream.EntityLayer.Dtos;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.DataAccessLayer.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        private readonly ApplicationDbContext _context;

        public TeamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
        // public async Task<IEnumerable<TeamUsersWithTasksDto>> GetUsersAndTasksByTeamIdAsync(Guid teamId)
        // {
        //     var users = await _context.Users
        //         .Where(u => u.TeamId == teamId)  // Bu satır düzeltildi
        //         .ToListAsync();
        //
        //     var tasks = await _context.UserTask
        //         .Where(t => t.TeamId == teamId)
        //         .ToListAsync();
        //
        //     var result = users.Select(user => new TeamUsersWithTasksDto
        //     {
        //         User = user,
        //         Tasks = tasks.Where(t => t.AssigneeId == user.UserId).ToList()
        //     });
        //
        //     return result.ToList();
        // }

        public async Task<Team> GetTeamByIdAsync(Guid teamId)
        {
            return await _context.Teams.FindAsync(teamId);
        }

        public async Task<Team> AddTeamAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team> UpdateTeamAsync(Team team)
        {
            _context.Teams.Update(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<bool> DeleteTeamAsync(Guid teamId)
        {
            var team = await _context.Teams.FindAsync(teamId);
            if (team == null)
            {
                return false; // Eğer takım bulunamazsa false döndür
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return true; // Silme başarılıysa true döndür
        }
    }
}
