using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;

namespace Billing.Application.Interfaces;

public interface IBillingRepository
{
    /// <summary>
    /// Create bill
    /// </summary>
    Task AddBiling(Bill bill,CancellationToken cancellationToken);

    /// <summary>
    /// Delete bill
    /// </summary>
    Task DeleteBilling(BillId billId, CancellationToken cancellationToken);

    /// <summary>
    /// Update bill
    /// </summary>
    Task UpdateBilling(Bill bill, CancellationToken cancellationToken);

    /// <summary>
    /// Get all bills of one user
    /// </summary>
    Task<List<Bill>> GetBills(Guid userId, CancellationToken cancellationToken);
}