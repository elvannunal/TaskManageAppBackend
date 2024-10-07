using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TaskStream.BusinessLayer.Interfaces;
using TaskStream.BusinessLayer.Services;
using TaskStream.DataAccessLayer.Data;
using TaskStream.DataAccessLayer.Interfaces;
using TaskStream.DataAccessLayer.Repositories;
using TaskStream.EntityLayer.Entity;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
   
        // Register User services
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();


        // Register Team services
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<ITeamService, TeamService>();

        // Register TaskTeam services
        services.AddScoped<IUserTaskRepository, UserTaskRepository>();
        services.AddScoped<IUserTaskService, UserTaskService>();

        // Register the generic repository
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); 

    }
}