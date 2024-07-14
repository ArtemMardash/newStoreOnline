namespace Users.SharedKarne;

public interface IUserCreated
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public Guid Id { get; set; }
}