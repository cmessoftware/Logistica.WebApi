using Logistica.WebApi.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logistica.WebApi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RouteNode> RouteNodes { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Vehicule> Vehicules { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RouteNode>()
                        .Property(e => e.Location)
                        .HasColumnType("geometry");

            modelBuilder.Entity<Route>()
                       .HasOne(r => r.SourceNodeNavigation)
                       .WithMany()
                       .HasForeignKey(r => r.SourceNodeId)
                       .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE NO ACTION

            modelBuilder.Entity<Route>()
                        .HasOne(r => r.DestinationNodeNavigation)
                        .WithMany()
                        .HasForeignKey(r => r.DestinationNodeId)
                        .OnDelete(DeleteBehavior.NoAction); // Specify ON DELETE NO ACTION

        }
    }
}
