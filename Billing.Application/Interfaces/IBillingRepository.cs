using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;

namespace Billing.Application.Interfaces;

public interface IBillingRepository
{
    /// <summary>
    /// Create bill
    /// </summary>
    Task AddBilingAsync(Bill bill,CancellationToken cancellationToken);

    /// <summary>
    /// Delete bill
    /// </summary>
    Task DeleteBillingAsync(BillId billId, CancellationToken cancellationToken);

    /// <summary>
    /// Update bill
    /// </summary>
    Task UpdateBillingAsync(Bill bill, CancellationToken cancellationToken);

    /// <summary>
    /// Get all bills of one user
    /// </summary>
    Task<List<Bill>> GetBillsAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Method to get bill by system id
    /// </summary>
    Task<Bill> GetBillByIdAsync(Guid systemId, CancellationToken cancellationToken);
}