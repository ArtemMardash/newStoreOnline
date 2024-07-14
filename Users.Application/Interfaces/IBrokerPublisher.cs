using Users.Domain.Events;

namespace Users.Application.Interfaces;

public interface IBrokerPublisher
{
    /// <summary>
    /// Method to publish a notification about created user
    /// </summary>
    Task PublishUserCreatedAsync(UserCreated userCreated, CancellationToken cancellationToken);

    
    /// <summary>
    /// Method to publish a notification about edited user
    /// </summary>
    Task PublishUserEditedAsync(UserEdited userEdited, CancellationToken cancellationToken);
}