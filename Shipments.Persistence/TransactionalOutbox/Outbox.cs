namespace Shipments.Persistence.TransactionalOutbox;

public class Outbox
{
    public Guid Id { get; set; }

    public OutboxStatus Status { get; set; }

    public string PayLoad { get; set; }
    
    public DateTime UpdatedAt { get; set; }
    
    
    public DateTime? CompletedAt { get; set; }
}