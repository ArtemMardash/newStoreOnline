using Billing.Application.Interfaces;

namespace Billing.Persistence;

public class UnitOfWork: IUnitOfWork 
{
    private readonly BillingContext _context;

    public UnitOfWork(BillingContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Method to dispose
    /// </summary>
    public void Dispose()
    {
        _context.Dispose();
    }

    /// <summary>
    /// Method to save async
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
       return _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Method to save
    /// </summary>
    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}