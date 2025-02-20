﻿using System.Linq.Expressions;
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

    public async Task<Employee> GetEmployeeAsync(Expression<Func<EmployeeEntity, bool>> expression)
    {
        var entity = await _employeeRepository.GetAsync(expression);
        var employee = EmployeeFactory.Create(entity);
        return employee ?? null!;
    }

    public bool UpdateEmployee(Employee employee)
    {
        return _employeeRepository.Update(EmployeeFactory.Create(employee));
    }

    public bool DeleteEmployee(Employee employee)
    {
        return _employeeRepository.Delete(EmployeeFactory.Create(employee));
    }

    public async Task<bool> EmployeeExistsAsync(Expression<Func<EmployeeEntity, bool>> expression)
    {
        var result = await _employeeRepository.ExistsAsync(expression);
        return result;
    }
}
