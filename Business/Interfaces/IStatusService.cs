﻿using System.Linq.Expressions;
using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces;

public interface IStatusService
{
    Task<bool> CreateStatusAsync(StatusRegistrationForm form);
    bool DeleteStatus(Status status);
    Task<IEnumerable<Status>> GetAllStatusAsync();
    Task<Status> GetStatusAsync(Expression<Func<StatusEntity, bool>> expression);
    Task<bool> StatusExistsAsync(Expression<Func<StatusEntity, bool>> expression);
    bool UpdateStatus(Status status);
}