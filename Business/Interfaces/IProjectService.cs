using Business.Dtos;

namespace Business.Interfaces;

public interface IProjectService
{
    Task CreateProjectAsync(ProjectRegistrationForm form);
}