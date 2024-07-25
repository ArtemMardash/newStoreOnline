using Billing.Application.Interfaces;

namespace Billing.Persistence;

public class UnitOfWork: IUnitOfWork 
{
    private readonly BillingContext _context;

    public UnitOfWork(BillingContext context)
    {
        _context = context;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
       return _context.SaveChangesAsync(cancellationToken);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}