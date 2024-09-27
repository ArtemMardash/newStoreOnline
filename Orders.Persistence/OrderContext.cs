using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Orders.Persistence.DbEntities;

namespace Orders.Persistence;

public class OrderContext: DbContext
{
    private readonly IMediator _mediator;
    
    public DbSet<OrderDb> Orders { get; set; }

    public DbSet<ProductDb> Products { get; set; }
    
    public OrderContext(DbContextOptions options, IMediator mediator)
    {
        _mediator = mediator;
         Database.EnsureCreated();
    }
    
    /// <summary>
    /// Data to db
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDb>().HasKey(o => o.SystemId);
        modelBuilder.Entity<OrderDb>().HasMany<ProductDb>(o => o.Products)
            .WithMany(p => p.Orders)
            .UsingEntity(j => j.ToTable("OrdersProducts"));
        modelBuilder.Entity<OrderDb>().Property(o => o.SystemId).ValueGeneratedNever();
        
        
        modelBuilder.Entity<ProductDb>().HasKey(p => p.PublicId);
        modelBuilder.Entity<ProductDb>().Property(p => p.PublicId).ValueGeneratedNever();
    }
    
    /// <summary>
    /// Configuring info for db
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Orders;Username=postgres;Password=postgres");
    }
}

public class UserContextFactory : IDesignTimeDbContextFactory<OrderContext>
{
    public OrderContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Orders;Username=postgres;Password=postgres",
            builder => builder.MigrationsAssembly(typeof(OrderContext).Assembly.GetName().Name));

        return new OrderContext(optionsBuilder.Options, null);
    }
}
