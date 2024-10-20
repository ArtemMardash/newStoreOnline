namespace Shipments.Persistence.TransactionalOutbox;

public enum OutboxStatus
{
    Unknown = 0,
    Pending, 
    Processed
}