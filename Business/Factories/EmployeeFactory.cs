using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class EmployeeFactory
{
    public static EmployeeRegistrationForm Create() => new();

    public static EmployeeUpdateForm Update() => new();

    public static EmployeeEntity Create(EmployeeRegistrationForm form) => new()
    {
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email
    };
    
    public static EmployeeEntity Create(EmployeeUpdateForm form) => new()
    {
        Id = form.Id,
        FirstName = form.FirstName,
        LastName = form.LastName,
        Email = form.Email
    };

    public static Employee Create(EmployeeEntity entity) => new()
    {
        Id = entity.Id,
        FirstName = entity.FirstName,
        LastName = entity.LastName,
        Email = entity.Email
    };

    public static EmployeeEntity Create(Employee employee) => new()
    {
        Id = employee.Id,
        FirstName = employee.FirstName,
        LastName = employee.LastName,
        Email = employee.Email
    };
}
