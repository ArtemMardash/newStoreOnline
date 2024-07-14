using Users.Application.Interfaces;

namespace Users.Persistence;

public class UnitOfWork: IUnitOfWork
{
    private readonly Context _context;

    public UnitOfWork(Context context)
    {
        _context = context;
    }
    public void Dispose()
    {
        _context.Dispose();
    }

    /// <summary>
    /// Method to save async 
    /// </summary>
    public Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Method to save
    /// </summary>
    public void SaveChanges()
    {
        _context.SaveChanges(); 
    }
}