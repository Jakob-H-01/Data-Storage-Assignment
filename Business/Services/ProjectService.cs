using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Data.Interfaces;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, IStatusService statusService, IServiceService serviceService, IEmployeeService employeeService, ICustomerService customerService) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IStatusService _statusService = statusService;
    private readonly IServiceService _serviceService = serviceService;
    private readonly IEmployeeService _employeeService = employeeService;
    private readonly ICustomerService _customerService = customerService;

    public async Task CreateProjectAsync(ProjectRegistrationForm form)
    {
        var customer = await _customerService.GetCustomerAsync(form.Customer.CustomerName);
        if (customer == null)
        {
            var result = await _customerService.CreateCustomerAsync(form.Customer);
            if (result)
                customer = await _customerService.GetCustomerAsync(form.Customer.CustomerName);
        }

        if (customer != null)
        {
            await _projectRepository.BeginTransactionAsync();

            try
            {
                var entity = ProjectFactory.Create(form);
                entity.CustomerId = customer.Id;

                await _projectRepository.CreateAsync(entity);
                await _projectRepository.SaveAsync();
                await _projectRepository.CommitTransactionAsync();
            }
            catch
            {
                await _projectRepository.RollbackTransactionAsync();
            }
        }
    }
}
