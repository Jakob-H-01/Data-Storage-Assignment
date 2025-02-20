﻿using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectRegistrationForm Create() => new();

    public static ProjectEntity Create(ProjectRegistrationForm form) => new()
    {
        ProjectName = form.ProjectName,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        Price = form.Price,
        StatusId = form.StatusId,
        ServiceId = form.ServiceId,
        CustomerId = form.CustomerId,
        EmployeeId = form.EmployeeId
    };

    public static Project Create(ProjectEntity entity) => new()
    {
        Id = entity.Id,
        ProjectName = entity.ProjectName,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Price = entity.Price,
        StatusId = entity.StatusId,
        ServiceId = entity.ServiceId,
        CustomerId = entity.CustomerId,
        EmployeeId = entity.EmployeeId
    };

    public static ProjectEntity Create(Project project) => new()
    {
        Id = project.Id,
        ProjectName = project.ProjectName,
        Description = project.Description,
        StartDate = project.StartDate,
        EndDate = project.EndDate,
        Price = project.Price,
        StatusId = project.StatusId,
        ServiceId = project.ServiceId,
        CustomerId = project.CustomerId,
        EmployeeId = project.EmployeeId
    };
}
