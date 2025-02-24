using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using System.Linq.Expressions;

namespace Business.Services;

public class ServiceService(IServiceRepository serviceRepository) : IServiceService
{
    private readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<bool> CreateServiceAsync(ServiceRegistrationForm form)
    {
        if (await _serviceRepository.ExistsAsync(x => x.ServiceName == form.ServiceName))
            return false;

        await _serviceRepository.BeginTransactionAsync();

        try
        {
            await _serviceRepository.CreateAsync(ServiceFactory.Create(form));
            await _serviceRepository.SaveAsync();
            await _serviceRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _serviceRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<IEnumerable<Service>> GetAllServicesAsync()
    {
        var entities = await _serviceRepository.GetAllAsync();
        var services = entities.Select(ServiceFactory.Create);
        return services ?? [];
    }

    public async Task<Service> GetServiceAsync(string serviceName)
    {
        var entity = await _serviceRepository.GetAsync(x => x.ServiceName == serviceName);
        if (entity == null)
            return null!;

        var service = ServiceFactory.Create(entity);
        return service ?? null!;
    }

    public async Task UpdateService(Service service)
    {
        _serviceRepository.Update(ServiceFactory.Create(service));
        await _serviceRepository.SaveAsync();
    }

    public async Task DeleteService(Service service)
    {
        _serviceRepository.Delete(ServiceFactory.Create(service));
        await _serviceRepository.SaveAsync();
    }

    public async Task<bool> ServiceExistsAsync(Expression<Func<ServiceEntity, bool>> expression)
    {
        var result = await _serviceRepository.ExistsAsync(expression);
        return result;
    }
}
