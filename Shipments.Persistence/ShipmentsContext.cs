using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Shipments.Persistence.TransactionalOutbox;

namespace Shipments.Persistence;

public class ShipmentsContext: DbContext
{
    public DbSet<Outbox> Outboxes { get; set; }

    public ShipmentsContext(DbContextOptions options): base(options)
    {
        //Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Outbox>().HasKey(e => e.Id);
        modelBuilder.Entity<Outbox>().Property(e => e.Id).ValueGeneratedNever();
    }
}

public class CustomerContextFactory : IDesignTimeDbContextFactory<ShipmentsContext>
{
    public ShipmentsContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ShipmentsContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Shipments;Username=postgres;Password=postgres",
            builder => builder.MigrationsAssembly(typeof(ShipmentsContext).Assembly.GetName().Name));

        return new ShipmentsContext(optionsBuilder.Options);
    }
}