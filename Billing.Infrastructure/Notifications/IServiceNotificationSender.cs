namespace Billing.Infrastructure.Notifications;

public interface IServiceNotificationSender
{
    Task SendAsync(string message, CancellationToken cancellationToken);
    
}