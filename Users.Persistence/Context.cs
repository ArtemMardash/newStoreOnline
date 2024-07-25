using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Users.Persistence;

public class Context: DbContext
{
    private readonly IMediator _mediator;
    
    /// <summary>
    /// Database for users
    /// </summary>
    public DbSet<UserDb> Users { get; set; }

    public Context(DbContextOptions options, IMediator mediator)
    {
        _mediator = mediator;
        //Database.EnsureCreated()
    }

    /// <summary>
    /// Data to db
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserDb>().HasKey(u => u.Id);
        modelBuilder.Entity<UserDb>().Property(u => u.Id).ValueGeneratedNever();
    }
    
    
    /// <summary>
    /// Configuring info for db
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Users;Username=postgres;Password=postgres");
    }
}

public class UserContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Context>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Users;Username=postgres;Password=postgres",
            builder => builder.MigrationsAssembly(typeof(Context).Assembly.GetName().Name));

        return new Context(optionsBuilder.Options, null);
    }
}