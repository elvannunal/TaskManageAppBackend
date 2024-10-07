using TaskStream.BusinessLayer.Interfaces;
using TaskStream.EntityLayer.Dtos;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.DataAccessLayer.Interfaces;

public interface ITeamRepository:IGenericRepository<Team>
{
 //   Task<IEnumerable<TeamUsersWithTasksDto>> GetUsersAndTasksByTeamIdAsync(Guid teamId);

}