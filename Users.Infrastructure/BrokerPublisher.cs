using MassTransit;
using SharedKernal;
using Users.Application.Interfaces;
using Users.Domain.Events;

namespace Users.Infrastructure;

public class BrokerPublisher: IBrokerPublisher
{
    private readonly IPublishEndpoint _publishEndpoint;
    
    /// <summary>
    /// Realization of all methods of IBrokPublisher
    /// </summary>
    /// <param name="publishEndpoint"></param>
    public BrokerPublisher(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    /// <summary>
    /// Publish message of created user
    /// </summary>
    public Task PublishUserCreatedAsync(UserCreated userCreated, CancellationToken cancellationToken)
    {
        return _publishEndpoint.Publish<IUserCreated>(new
        {
            userCreated.FirstName,
            userCreated.LastName,
            userCreated.Id
        }, cancellationToken);
    }

    /// <summary>
    /// Publish message of edited user
    /// </summary>
    public Task PublishUserEditedAsync(UserEdited userEdited, CancellationToken cancellationToken)
    {
        return _publishEndpoint.Publish<IUserEdited>(new
        {
            userEdited.FirstName,
            userEdited.LastName,
            userEdited.Id,
            userEdited.Email,
            userEdited.PhoneNumber
        }, cancellationToken);
    }
}