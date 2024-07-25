
using Billing.Domain.ValueObjects;
using SharedKernal;

namespace Billing.Domain.Entities;

public class Bill
{
    /// <summary>
    /// Id of billing
    /// </summary>
    public BillId Id { get; set; }

    /// <summary>
    /// System Id of user
    /// </summary>
    public UserId UserId { get; set; }

    /// <summary>
    /// Constructor with id
    /// </summary>
    public Bill(BillId id, UserId userId)
    {
        Id = id;
        UserId = userId;
    }

    /// <summary>
    /// Constructor without id
    /// </summary>
    public Bill(UserId userId)
    {
        Id = new BillId(Guid.NewGuid(),
            PublicIdGenerator.Generate("bil", int.Parse(DateTime.UtcNow.Millisecond.ToString().Substring(0, 4))));
        UserId = userId;
    }


}