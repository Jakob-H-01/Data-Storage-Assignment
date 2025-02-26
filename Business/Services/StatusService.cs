﻿using System.Linq.Expressions;
using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;

namespace Business.Services;

public class StatusService(IStatusRepository statusRepository) : IStatusService
{
    private readonly IStatusRepository _statusRepository = statusRepository;

    public async Task<bool> CreateStatusAsync(StatusRegistrationForm form)
    {
        if (await _statusRepository.ExistsAsync(x => x.StatusName == form.StatusName))
            return false;

        await _statusRepository.BeginTransactionAsync();

        try
        {
            await _statusRepository.CreateAsync(StatusFactory.Create(form));
            await _statusRepository.SaveAsync();
            await _statusRepository.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _statusRepository.RollbackTransactionAsync();
            return false;
        }
    }

    public async Task<IEnumerable<Status>> GetAllStatusAsync()
    {
        var entities = await _statusRepository.GetAllAsync();
        var status = entities.Select(StatusFactory.Create);
        return status ?? [];
    }

    public async Task<Status> GetStatusAsync(string statusName)
    {
        var entity = await _statusRepository.GetAsync(x => x.StatusName == statusName);
        if (entity == null)
            return null!;

        var status = StatusFactory.Create(entity);
        return status ?? null!;
    }

    public async Task UpdateStatus(StatusUpdateForm form)
    {
        _statusRepository.Update(StatusFactory.Create(form));
        await _statusRepository.SaveAsync();
    }

    public async Task DeleteStatus(Status status)
    {
        _statusRepository.Delete(StatusFactory.Create(status));
        await _statusRepository.SaveAsync();
    }

    public async Task<bool> StatusExistsAsync(Expression<Func<StatusEntity, bool>> expression)
    {
        var result = await _statusRepository.ExistsAsync(expression);
        return result;
    }
}
