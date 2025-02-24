using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public async Task<bool> CreateEmployeeAsync(EmployeeRegistrationForm form)
    {
        if (await _employeeRepository.ExistsAsync(x => x.Email == form.Email))
            return false;

        await _employeeRepository.BeginTransactionAsync();

        try
        {
            await _employeeRepository.CreateAsync(EmployeeFactory.Create(form));
            await _employeeRepository.SaveAsync();
            await _employeeRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _employeeRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        var entities = await _employeeRepository.GetAllAsync();
        var employees = entities.Select(EmployeeFactory.Create);
        return employees ?? [];
    }

    public async Task<Employee> GetEmployeeAsync(string email)
    {
        var entity = await _employeeRepository.GetAsync(x => x.Email == email);
        if (entity == null)
            return null!;

        var employee = EmployeeFactory.Create(entity);
        return employee ?? null!;
    }

    public async Task UpdateEmployee(EmployeeUpdateForm form)
    {
        _employeeRepository.Update(EmployeeFactory.Create(form));
        await _employeeRepository.SaveAsync();
    }

    public async Task DeleteEmployee(Employee employee)
    {
        _employeeRepository.Delete(EmployeeFactory.Create(employee));
        await _employeeRepository.SaveAsync();
    }

    public async Task<bool> EmployeeExistsAsync(Expression<Func<EmployeeEntity, bool>> expression)
    {
        var result = await _employeeRepository.ExistsAsync(expression);
        return result;
    }
}
