using Microsoft.EntityFrameworkCore.Storage;
using Ugoki.Application.Interfaces;

namespace Ugoki.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly UgokiDbContext _context;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(UgokiDbContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }
    public async Task CommitAsync()
    {
        if (_transaction != null)
        {
            await _context.SaveChangesAsync();
            await _transaction.CommitAsync();

            _transaction.Dispose();
            _transaction = null;
        }
    }
    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();

            _transaction.Dispose();
            _transaction = null;
        }
    }
    public void Dispose()
    {
        _transaction?.Dispose();
        _transaction = null;
    }
}
