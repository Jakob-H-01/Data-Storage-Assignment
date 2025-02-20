using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IServiceService
{
    Task<bool> CreateServiceAsync(ServiceRegistrationForm form);
    bool DeleteService(Service service);
    Task<IEnumerable<Service>> GetAllServicesAsync();
    Task<Service> GetServiceAsync(Expression<Func<ServiceEntity, bool>> expression);
    Task<bool> ServiceExistsAsync(Expression<Func<ServiceEntity, bool>> expression);
    bool UpdateService(Service service);
}