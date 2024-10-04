using MediatR;
using Users.Application.Interfaces;

namespace Users.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private readonly UserContext _userContext;
    private readonly IMediator _mediator;

    public UnitOfWork(UserContext userContext, IMediator mediator)
    {
        _userContext = userContext;
        _mediator = mediator;
    }
    public void Dispose()
    {
        _userContext.Dispose();
    }

    /// <summary>
    /// Method to save async 
    /// </summary>
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        var entities = _userContext.ChangeTracker
            .Entries<EntityDb>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToList();
        
        var domainEvents = entities.SelectMany(e => e.DomainEvents).ToList();
        
        entities.ForEach(e => e.DomainEvents.Clear());
        
        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }
        
        await _userContext.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Method to save
    /// </summary>
    public void SaveChanges()
    {
        _userContext.SaveChanges(); 
        var entities = _userContext.ChangeTracker
            .Entries<EntityDb>()
            .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToList();
        var domainEvents = entities.SelectMany(e => e.DomainEvents);
        entities.ForEach(e => e.DomainEvents.Clear());
        foreach (var domainEvent in domainEvents)
        {
            _mediator.Publish(domainEvent).GetAwaiter().GetResult();
        }
    }
    
     
}