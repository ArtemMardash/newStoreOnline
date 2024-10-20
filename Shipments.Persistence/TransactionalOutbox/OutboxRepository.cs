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

    public async Task<List<Outbox>> GetUnprocessedOutboxes(CancellationToken cancellationToken)
    {
        return await _context.Outboxes
                .Where(o => o.Status == OutboxStatus.Pending)
                .ToListAsync(cancellationToken);
    }

    public Task AddOutboxAsync(Outbox outbox, CancellationToken cancellationToken)
    {
        return _context.Outboxes.AddAsync(outbox, cancellationToken).AsTask();
    }
}