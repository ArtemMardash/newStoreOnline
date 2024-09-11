namespace Billing.Domain;

public enum BillStatus
{
    Unknown, // может меняться только в New
    New,    // может менять в Payed and canceled
    Payed,  // не модет меняться
    Canceled // не может меняться 
}