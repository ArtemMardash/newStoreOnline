using Telegram.Bot;

namespace Billing.Infrastructure.Notifications;

public class ServiceNotificationSender: IServiceNotificationSender
{
    private TelegramBotClient _telegramBotClient;
    private const long Id = 5192272445;
    
    public ServiceNotificationSender()
    {
        _telegramBotClient= new TelegramBotClient("7840753685:AAHGi_aA28Uh3SDLDj8PgvSuPA2If3Ii71M");
        _telegramBotClient.OnMessage += (message, type) => 
        {
            Console.WriteLine(message.From?.Id);
            Console.WriteLine(message.From?.Username);
            return Task.CompletedTask;
        };
    }
    
    public Task SendAsync(string message, CancellationToken cancellationToken)
    {
        return _telegramBotClient.SendTextMessageAsync(Id, message, cancellationToken: cancellationToken);
    }
}