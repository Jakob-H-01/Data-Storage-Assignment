using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectRegistrationForm Create() => new();

    public static ProjectEntity Create(ProjectRegistrationForm form) => new()
    {
        ProjectName = form.ProjectName,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        Price = form.Price
    };

    public static Project Create(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        ProjectName = entity.ProjectName,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Price = entity.Price,
        StatusId = entity.StatusId,
        StatusName = entity.Status.StatusName,
        ServiceId = entity.ServiceId,
        ServiceName = entity.Service.ServiceName,
        ServicePrice = entity.Service.Price,
        EmployeeId = entity.EmployeeId,
        EmployeeFirstName = entity.Employee.FirstName,
        EmployeeLastName = entity.Employee.LastName,
        EmployeeEmail = entity.Employee.Email,
        CustomerId = entity.CustomerId,
        CustomerName = entity.Customer.CustomerName
    };

    public static ProjectEntity Create(Project project) => new()
    {
        Id = project.Id,
        ProjectName = project.ProjectName,
        Description = project.Description,
        StartDate = project.StartDate,
        EndDate = project.EndDate,
        Price = project.Price,
        StatusId = project.StatusId,
        ServiceId = project.ServiceId,
        CustomerId = project.CustomerId,
        EmployeeId = project.EmployeeId
    };
}
