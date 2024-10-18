using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace Shipments.Persistence.TransactionalOutbox;

public class OutboxRepository
{
    private readonly ShipmentsContext _context;

    public OutboxRepository(ShipmentsContext context)
    {
        _context = context;
    }

    public Task<List<Outbox>> GetUnprocessedOutboxes(CancellationToken cancellationToken)
    {
        var outboxes =  _context.Outboxes
                .Where(o => o.Status == OutboxStatus.Pending)
                .AsEnumerable()
                .Where(o => DateTime.UtcNow.Subtract(o.UpdatedAt).TotalSeconds <= 30)
                .ToList();
        return Task.FromResult<List<Outbox>>(outboxes);
    }

    public Task AddOutboxAsync(Outbox outbox, CancellationToken cancellationToken)
    {
        return _context.Outboxes.AddAsync(outbox, cancellationToken).AsTask();
    }
}