using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IServiceService
{
    Task<bool> CreateServiceAsync(ServiceRegistrationForm form);
    Task DeleteService(Service service);
    Task<IEnumerable<Service>> GetAllServicesAsync();
    Task<Service> GetServiceAsync(string serviceName);
    Task<bool> ServiceExistsAsync(Expression<Func<ServiceEntity, bool>> expression);
    Task UpdateService(Service service);
}