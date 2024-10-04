using Catalog.Application.Interfaces;

namespace Catalog.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private readonly CatalogContext _context;

    public UnitOfWork(CatalogContext context)
    {
        _context = context;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}