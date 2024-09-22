namespace SharedKernal;

public interface IBillCreated
{
    public Guid BillId { get; set; }
    
    public Guid UserId { get; set; }
    
    public Guid OrderId { get; set; }
    
    public int Status { get; set; }
}