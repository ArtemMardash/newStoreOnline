using Billing.Persistence.EntitiesDb;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Billing.Persistence;

public class BillingContext: DbContext
{
    private readonly IMediator _mediator;
    
    public DbSet<BillDb> Bills { get; set; }

    public DbSet<UserDb> Users { get; set; }
    
    public BillingContext(DbContextOptions options, IMediator mediator)
    {
        _mediator = mediator;
        //Database.EnsureCreated();
    }
    
    /// <summary>
    /// Data to db
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BillDb>().HasKey(b => b.Id);
        modelBuilder.Entity<BillDb>().Property(b => b.Id).ValueGeneratedNever();
        
        
        modelBuilder.Entity<UserDb>().HasKey(u => u.Id);
        modelBuilder.Entity<UserDb>().HasMany<BillDb>(u => u.Bills).WithOne(b => b.User);
        modelBuilder.Entity<UserDb>().Property(b => b.Id).ValueGeneratedNever();
    }
    
    /// <summary>
    /// Configuring info for db
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Bill;Username=postgres;Password=postgres");
    }
}

public class UserContextFactory : IDesignTimeDbContextFactory<BillingContext>
{
    public BillingContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BillingContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Bill;Username=postgres;Password=postgres",
            builder => builder.MigrationsAssembly(typeof(BillingContext).Assembly.GetName().Name));

        return new BillingContext(optionsBuilder.Options, null);
    }
}