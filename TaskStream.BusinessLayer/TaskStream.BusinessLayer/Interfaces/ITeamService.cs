using TaskStream.EntityLayer.Dtos;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.BusinessLayer.Interfaces;

public interface ITeamService:IGenericService<Team>
{
  //  Task<IEnumerable<TeamUsersWithTasksDto>> GetUsersAndTasksByTeamIdAsync(Guid teamId);

}