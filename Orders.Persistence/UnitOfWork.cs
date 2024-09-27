using Orders.Appliaction.Interfaces;

namespace Orders.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private readonly OrderContext _context;

    public UnitOfWork(OrderContext context)
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