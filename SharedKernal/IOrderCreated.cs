namespace SharedKernal;

public interface IOrderCreated
{
    public Guid SystemId { get; set; }

    public string PublicId { get; set; }

    public List<ProductInfo> Products { get; set; }

    public int DeliveryType { get; set; }

    /// <summary>
    /// Status of order 
    /// </summary>
    public int Status { get; set; }

    public Guid SystemUserId { get; set; }

    public string PublicUserId { get; set; }
}