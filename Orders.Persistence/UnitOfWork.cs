using MediatR;
using Orders.Application.Interfaces;
using Orders.Persistence.DbEntities;

namespace Orders.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private readonly OrderContext _context;
    private readonly Mediator _mediator;

    public UnitOfWork(OrderContext context, Mediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
        await DispatchDomainEventsAsync();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
    
    public async Task DispatchDomainEventsAsync()
    {
        var domainEventEntities = _context.ChangeTracker.Entries<EntityDb>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToList();
        var events = domainEventEntities.SelectMany(e => e.DomainEvents).ToList();
        domainEventEntities.ForEach(e=>e.DomainEvents.Clear());
        foreach (var domainEvent in events)
        {
            await _mediator.Publish(domainEvent);
        }
    }
}