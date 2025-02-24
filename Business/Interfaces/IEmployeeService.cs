using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IEmployeeService
{
    Task<bool> CreateEmployeeAsync(EmployeeRegistrationForm form);
    Task DeleteEmployee(Employee employee);
    Task<bool> EmployeeExistsAsync(Expression<Func<EmployeeEntity, bool>> expression);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee> GetEmployeeAsync(string email);
    Task UpdateEmployee(Employee employee);
}