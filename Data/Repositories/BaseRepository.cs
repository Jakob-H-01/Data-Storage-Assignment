using System.Diagnostics;
using System.Linq.Expressions;
using Data.Contexts;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(DataContext context) : IBaseRepository<TEntity> where TEntity : class
{
    private readonly DataContext _context = context;
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();
    private IDbContextTransaction _transaction = null!;

    public virtual async Task BeginTransactionAsync()
    {
        _transaction ??= await _context.Database.BeginTransactionAsync();
    }

    public virtual async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }

    public virtual async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null!;
        }
    }

    public virtual async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public virtual async Task CreateAsync(TEntity entity)
    {
        if (entity == null) return;

        try
        {
            await _dbSet.AddAsync(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Could not create {nameof(TEntity)} entity | {ex.Message}");
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null) return null!;

        return await _dbSet.FirstOrDefaultAsync(expression) ?? null!;
    }

    public virtual void Update(TEntity updatedEntity)
    {
        if (updatedEntity == null) return;

        try
        {
            _dbSet.Update(updatedEntity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Could not update {nameof(TEntity)} entity | {ex.Message}");
        }
    }

    public virtual void Delete(TEntity entity)
    {
        if (entity == null) return;

        try
        {
            _dbSet.Remove(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Could not delete {nameof(TEntity)} entity | {ex.Message}");
        }
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }
}
