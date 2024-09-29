namespace SharedKernal;

public interface IOrderStatusChanged
{
    public Guid OrderId { get; set; }
    
    public int NewStatus { get; set; }
    
}