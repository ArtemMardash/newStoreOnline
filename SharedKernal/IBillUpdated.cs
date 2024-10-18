namespace SharedKernal;

public interface IBillUpdated
{
    /// <summary>
    /// System id of bill
    /// </summary>
    public Guid SystemId { get; set; }
    
    /// <summary>
    /// Old status of bill
    /// </summary>
    public int OldStatus { get; set; }
    
    /// <summary>
    /// New bill status to change
    /// </summary>
    public int NewStatus { get; set; }
    
    /// <summary>
    /// Id of order
    /// </summary>
    public Guid OrderId { get; set; }
}