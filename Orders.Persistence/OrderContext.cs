using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Orders.Persistence.DbEntities;

namespace Orders.Persistence;

public class OrderContext : DbContext
{
    private readonly IMediator _mediator;

    public DbSet<OrderDb> Orders { get; set; }

    public DbSet<ProductDb> Products { get; set; }

    public OrderContext(DbContextOptions options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
        //Database.EnsureCreated();
    }

    /// <summary>
    /// Data to db
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDb>().HasKey(o => o.SystemId);
        modelBuilder.Entity<OrderDb>().HasMany<ProductDb>(o => o.Products)
            .WithOne(p => p.Order);
        modelBuilder.Entity<OrderDb>().Property(o => o.SystemId).ValueGeneratedNever();


        modelBuilder.Entity<ProductDb>().HasKey(p => new {OrderId = p.OrderId, ProductId = p.SystemId});
        modelBuilder.Entity<ProductDb>().Property(p => p.SystemId).ValueGeneratedNever();
    }
}

public class UserContextFactory : IDesignTimeDbContextFactory<OrderContext>
{
    public OrderContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OrderContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Order;Username=postgres;Password=postgres",
            builder => builder.MigrationsAssembly(typeof(OrderContext).Assembly.GetName().Name));

        return new OrderContext(optionsBuilder.Options, null);
    }
}