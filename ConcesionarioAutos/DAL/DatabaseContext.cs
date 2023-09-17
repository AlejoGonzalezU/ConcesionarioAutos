using ConcesionarioAutos.DAL.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable // Para deshabilitar alerta no necesaria sobre variables nullables que aparece en Visual Studio Mac

namespace ConcesionarioAutos.DAL
{
    public class DatabaseContext : DbContext
    {
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<User>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Conversation>().HasIndex(c => c.Id).IsUnique();
            modelBuilder.Entity<Message>().HasIndex(c => c.Id).IsUnique();
        }
    }
}

#nullable restore // Para habilitar de nuevo alerta no necesaria sobre variables nullables
