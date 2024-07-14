using MediatR;
using Users.Application.Interfaces;
using Users.Domain.Events;

namespace Users.Application.EventHandler;

/// <summary>
/// Class to handle userEdited
/// </summary>
public class UserEditedHandler: INotificationHandler<UserEdited>
{
    private readonly IBrokerPublisher _publisher;

    /// <summary>
    /// Class to Handle userEdited
    /// </summary>
    public UserEditedHandler(IBrokerPublisher publisher)
    {
        _publisher = publisher;
    }
    
    /// <summary>
    /// Method to handle a notification about edited user
    /// </summary>
    public Task Handle(UserEdited notification, CancellationToken cancellationToken)
    {
        return _publisher.PublishUserEditedAsync(notification, cancellationToken);
    }
}