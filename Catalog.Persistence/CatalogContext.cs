using Catalog.Persistence.EntitiesDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Catalog.Persistence;

public class CatalogContext : DbContext
{
    public DbSet<ProductDb> Products { get; set; }

    public CatalogContext(DbContextOptions options): base(options)
    {
        //Database.EnsureCreated();
    }

    /// <summary>
    /// Data to db
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDb>().HasKey(p => p.SystemId);
        modelBuilder.Entity<ProductDb>().Property(p => p.SystemId).ValueGeneratedNever();
    }

    /// <summary>
    /// Configuring info for db
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Catalog;Username=postgres;Password=postgres");
    }
}

public class UserContextFactory : IDesignTimeDbContextFactory<CatalogContext>
{
    public CatalogContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Catalog;Username=postgres;Password=postgres",
            builder => builder.MigrationsAssembly(typeof(CatalogContext).Assembly.GetName().Name));

        return new CatalogContext(optionsBuilder.Options);
    }
}

