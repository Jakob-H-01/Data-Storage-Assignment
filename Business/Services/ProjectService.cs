using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, IStatusService statusService, IServiceService serviceService, IEmployeeService employeeService, ICustomerService customerService) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IStatusService _statusService = statusService;
    private readonly IServiceService _serviceService = serviceService;
    private readonly IEmployeeService _employeeService = employeeService;
    private readonly ICustomerService _customerService = customerService;

    public async Task<bool> CreateProjectAsync(ProjectRegistrationForm form)
    {
        var status = await _statusService.GetStatusAsync(form.Status.StatusName);
        if (status == null)
        {
            var result = await _statusService.CreateStatusAsync(form.Status);
            if (result)
                status = await _statusService.GetStatusAsync(form.Status.StatusName);
        }

        var service = await _serviceService.GetServiceAsync(form.Service.ServiceName);
        if (service == null)
        {
            var result = await _serviceService.CreateServiceAsync(form.Service);
            if (result)
                service = await _serviceService.GetServiceAsync(form.Service.ServiceName);
        }

        var employee = await _employeeService.GetEmployeeAsync(form.Employee.Email);
        if (employee == null)
        {
            var result = await _employeeService.CreateEmployeeAsync(form.Employee);
            if (result)
                employee = await _employeeService.GetEmployeeAsync(form.Employee.Email);
        }

        var customer = await _customerService.GetCustomerAsync(form.Customer.CustomerName);
        if (customer == null)
        {
            var result = await _customerService.CreateCustomerAsync(form.Customer);
            if (result)
                customer = await _customerService.GetCustomerAsync(form.Customer.CustomerName);
        }

        if (status != null && service != null && employee != null && customer != null)
        {
            await _projectRepository.BeginTransactionAsync();

            try
            {
                var entity = ProjectFactory.Create(form);

                entity.StatusId = status.Id;
                entity.ServiceId = service.Id;
                entity.EmployeeId = employee.Id;
                entity.CustomerId = customer.Id;

                await _projectRepository.CreateAsync(entity);
                await _projectRepository.SaveAsync();
                await _projectRepository.CommitTransactionAsync();
                return true;
            }
            catch
            {
                await _projectRepository.RollbackTransactionAsync();
                return false;
            }
        }

        else
            return false;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        var entities = await _projectRepository.GetAllAsync();
        var projects = entities.Select(ProjectFactory.Create);
        return projects ?? [];
    }
}
