using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .UseLazyLoadingProxies() // permet l'utilisation du chargement difere Lazy de toute les propriete virtual des models
        .UseMySql("Server=localhost;Database=dbdotnet;User=admin;Password=root;", new MySqlServerVersion(new Version(8, 0, 21)));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.TodoItems)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired(false);
    }

    // Remplace par la version de ton serveur MySQL
    public DbSet<TodoItem> TodoItems { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

}