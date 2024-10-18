using Billing.Application.Interfaces;
using Billing.Domain;
using Billing.Domain.Entities;
using Billing.Domain.Events;
using Billing.Domain.ValueObjects;
using Billing.Persistence.EntitiesDb;
using Microsoft.EntityFrameworkCore;

namespace Billing.Persistence.Repositories;

public class BillingRepository : IBillingRepository
{
    private readonly BillingContext _context;

    public BillingRepository(BillingContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Method to add bill
    /// </summary>
    public async Task AddBillingAsync(Bill bill, CancellationToken cancellationToken)
    {
        var billDb = await BillToBillDbAsync(bill, cancellationToken);

        var billCreated = new BillCreated
        {
            BillId = billDb.Id,
            UserId = billDb.User.Id,
            OrderId = billDb.OrderId,
            Status = billDb.Status,
            TotalPrice = billDb.TotalPrice
        };
        
        billDb.DomainEvents.Add(billCreated);
        await _context.Bills.AddAsync(billDb, cancellationToken);
    }

    /// <summary>
    /// Method to delete bill
    /// </summary>
    public async Task DeleteBillingAsync(BillId billId, CancellationToken cancellationToken)
    {
        var billDb = await _context.Bills.FirstOrDefaultAsync(b => b.Id == billId.SystemId, cancellationToken);
        if (billDb == null)
        {
            throw new InvalidOperationException("There is no bill with such system id");
        }

        billDb.IsDeleted = true;
    }

    /// <summary>
    /// Method to update bill
    /// </summary>
    public async Task UpdateBillingAsync(Bill bill, CancellationToken cancellationToken)
    {
        var billDb = await _context.Bills.FirstOrDefaultAsync(b => b.Id == bill.Id.SystemId, cancellationToken);
        if (billDb == null)
        {
            throw new InvalidOperationException("There is no bill with such id");
        }


        if (billDb.Status != bill.Status)
        {
            var billChanged = new BillUpdated
            {
                SystemId = billDb.Id,
                OldStatus = billDb.Status,
                NewStatus = bill.Status,
                OrderId = billDb.OrderId
            };
            billDb.DomainEvents.Add(billChanged);
        }

        billDb.Status = bill.Status;
        billDb.TotalPrice = bill.TotalPrice;
        _context.Bills.Update(billDb);
    }

    /// <summary>
    /// Method to get bills of one user
    /// </summary>
    public async Task<List<Bill>> GetBillsAsync(Guid userId, CancellationToken cancellationToken)
    {
        var billsDb = await _context.Bills
            .Where(b => b.User.Id == userId && !b.IsDeleted)
            .Include(b => b.User)
            .ToListAsync(cancellationToken);
        var bills = new List<Bill>();
        foreach (var billDb in billsDb)
        {
            bills.Add(BillDbToBill(billDb));
        }

        return bills;
    }

    /// <summary>
    /// Method to get bill by id
    /// </summary>
    public async Task<Bill> GetBillByIdAsync(Guid billId, CancellationToken cancellationToken)
    {
        var bill = await _context.Bills
            .Include(b=>b.User)
            .FirstOrDefaultAsync(b => b.Id == billId, cancellationToken);
        if (bill is null)
        {
            throw new InvalidOperationException("There is no bill with such ID");
        }
        return BillDbToBill(bill);
    }

    /// <summary>
    /// Method to get bill by order Id
    /// </summary>
    public async Task<Bill?> GetBillByOrderIdAsync(Guid orderId, CancellationToken cancellationToken)
    {
        var bill = await _context.Bills.FirstOrDefaultAsync(b => b.OrderId == orderId, cancellationToken);
        return bill != null ? BillDbToBill(bill) : null;
    }
    
    /// <summary>
    /// From BillDb to bill domain
    /// </summary>
    private Bill BillDbToBill(BillDb billDb)
    {
        return new Bill(
            new BillId(billDb.Id, billDb.PublicId),
            new UserId(billDb.User.Id, billDb.User.PublicId),
            billDb.OrderId,
            billDb.Status, billDb.TotalPrice);
    }

    /// <summary>
    /// Method to converse from bill to billDb
    /// </summary>
    private async Task<BillDb> BillToBillDbAsync(Bill bill, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == bill.UserId.SystemId, cancellationToken);
        if (user == null)
        {
            throw new InvalidOperationException("There is no user with such ID");
        }

        return new BillDb
        {
            Id = bill.Id.SystemId,
            PublicId = bill.Id.PublicId,
            OrderId = bill.OrderId,
            Status = bill.Status,
            User = user,
            TotalPrice = bill.TotalPrice
        };
    }


}