using MediatR;
using Users.Application.Interfaces;
using Users.Domain.Events;

namespace Users.Application.EventHandler;

/// <summary>
/// Class to handle userCreated
/// </summary>
public class UserCreatedHandler: INotificationHandler<UserCreated>
{
    private readonly IBrokerPublisher _publisher;

    /// <summary>
    /// Class to handle userCreated
    /// </summary>
    public UserCreatedHandler(IBrokerPublisher publisher)
    {
        _publisher = publisher;
    }
    
    /// <summary>
    /// Method to handle a notification about created user
    /// </summary>
    public Task Handle(UserCreated notification, CancellationToken cancellationToken)
    {
        return _publisher.PublishUserCreatedAsync(notification, cancellationToken);
    }
}