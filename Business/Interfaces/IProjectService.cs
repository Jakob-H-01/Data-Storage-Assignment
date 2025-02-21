using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(ProjectRegistrationForm form);
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectAsync(Expression<Func<ProjectEntity, bool>> expression);
}