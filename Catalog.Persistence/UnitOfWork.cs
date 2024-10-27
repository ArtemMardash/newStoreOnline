using Catalog.Application.Interfaces;

namespace Catalog.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private readonly CatalogContext _context;

    public UnitOfWork(CatalogContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Method to dispoce
    /// </summary>
    public void Dispose()
    {
        _context.Dispose();
    }

    /// <summary>
    /// Method to save changes async
    /// </summary>
    /// <param name="cancellationToken"></param>
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Method to save changes sync
    /// </summary>
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}