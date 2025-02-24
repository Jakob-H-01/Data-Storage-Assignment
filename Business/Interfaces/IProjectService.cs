using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(ProjectRegistrationForm form);
    Task DeleteProject(Project project);
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectAsync(Expression<Func<ProjectEntity, bool>> expression);
    Task<bool> ProjectExistsAsync(Expression<Func<ProjectEntity, bool>> expression);
    Task UpdateProject(ProjectUpdateForm form);
}