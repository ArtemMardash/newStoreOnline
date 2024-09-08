using Billing.Application.Interfaces;
using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using Billing.Persistence.EntitiesDb;

namespace Billing.Persistence.Repositories;

public class BillingRepository: IBillingRepository
{
    private readonly BillingContext _context;
    
    public BillingRepository(BillingContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Method to add bill
    /// </summary>
    public Task AddBiling(Bill bill, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Method to delete bill
    /// </summary>
    public Task DeleteBilling(BillId billId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Method to update bill
    /// </summary>
    public Task UpdateBilling(Bill bill, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Method to get bills of one user
    /// </summary>
    /// <returns></returns>
    public Task<List<Bill>>  GetBills(Guid userId, CancellationToken cancellationToken)
    {
        var bills = _context.Bills.Where(b => b.User.Id == userId).ToList();
        return null;
    }

    private Bill BillDbToBill(BillDb billDb)
    {
        throw new NotImplementedException();
    }
}