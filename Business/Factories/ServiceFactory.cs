using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ServiceFactory
{
    public static ServiceRegistrationForm Create() => new();

    public static ServiceUpdateForm Update() => new();

    public static ServiceEntity Create(ServiceRegistrationForm form) => new()
    {
        ServiceName = form.ServiceName,
        Price = form.Price
    };
    
    public static ServiceEntity Create(ServiceUpdateForm form) => new()
    {
        Id = form.Id,
        ServiceName = form.ServiceName,
        Price = form.Price
    };

    public static Service Create(ServiceEntity entity) => new()
    {
        Id = entity.Id,
        ServiceName = entity.ServiceName,
        Price = entity.Price
    };

    public static ServiceEntity Create(Service service) => new()
    {
        Id = service.Id,
        ServiceName = service.ServiceName,
        Price = service.Price
    };
}
