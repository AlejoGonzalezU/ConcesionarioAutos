using ConcesionarioAutos.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#nullable disable // Para deshabilitar alerta no necesaria sobre variables nullables que aparece en Visual Studio Mac

namespace ConcesionarioAutos.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<User> ApplicationUsers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Conversation> Conversations { get; set; }
    public DbSet<Message> Messages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Se sobreescriben los nombres de las tablas de Identity Framework para que sean más amigables
        modelBuilder.Entity<IdentityUser>().ToTable("Users").Property(p => p.Id).HasColumnName("Id");

        // Se crean los índices de las tablas
        modelBuilder.Entity<Client>().HasIndex(c => c.Id).IsUnique();
        modelBuilder.Entity<User>().HasIndex(c => c.Id).IsUnique();
        modelBuilder.Entity<Vehicle>().HasIndex(c => c.Id).IsUnique();
        modelBuilder.Entity<Conversation>().HasIndex(c => c.Id).IsUnique();
        modelBuilder.Entity<Message>().HasIndex(c => c.Id).IsUnique();

        // Se añade precisión de la propiedad Price para que no de error al crear la entidad
        modelBuilder.Entity<Vehicle>().Property(v => v.Price).HasColumnType("decimal(18,2)");
    }
}

#nullable restore // Para habilitar de nuevo alerta no necesaria sobre variables nullables
