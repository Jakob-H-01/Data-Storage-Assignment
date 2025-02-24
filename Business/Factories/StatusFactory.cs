using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class StatusFactory
{
    public static StatusRegistrationForm Create() => new();

    public static StatusUpdateForm Update() => new();

    public static StatusEntity Create(StatusRegistrationForm form) => new()
    {
        StatusName = form.StatusName
    };
    
    public static StatusEntity Create(StatusUpdateForm form) => new()
    {
        Id = form.Id,
        StatusName = form.StatusName
    };

    public static Status Create(StatusEntity entity) => new()
    {
        Id = entity.Id,
        StatusName = entity.StatusName
    };

    public static StatusEntity Create(Status status) => new()
    {
        Id = status.Id,
        StatusName = status.StatusName
    };
}
