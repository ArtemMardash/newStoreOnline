using Billing.Application.Interfaces;
using Billing.Persistence.EntitiesDb;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Billing.Persistence;

public class UnitOfWork: IUnitOfWork 
{
    private readonly BillingContext _context;
    private readonly IMediator _mediator;

    public UnitOfWork(BillingContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
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
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
        await DispatchDomainEventsAsync();
    }

    /// <summary>
    /// Method to save
    /// </summary>
    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    /// <summary>
    /// Method to dispatch domain events
    /// </summary>
    public async Task DispatchDomainEventsAsync()
    {
        var domainEventEntities = _context.ChangeTracker.Entries<BaseEntity>()
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