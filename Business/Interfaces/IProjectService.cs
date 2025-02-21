using Business.Dtos;
using Business.Models;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<bool> CreateProjectAsync(ProjectRegistrationForm form);
    Task<IEnumerable<Project>> GetAllProjectsAsync();
}