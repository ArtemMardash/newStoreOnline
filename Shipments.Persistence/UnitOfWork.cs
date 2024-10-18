using Shipments.Application.Interfaces;

namespace Shipments.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private readonly ShipmentsContext _context;

    public UnitOfWork(ShipmentsContext context)
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