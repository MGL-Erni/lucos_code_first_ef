using lucos_code_first_ef.Models;
using Microsoft.EntityFrameworkCore;

namespace lucos_code_first_ef.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Opening> Openings { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
              .HasOne(g => g.PlayerW)
              .WithMany()
              .HasForeignKey("PlayerWId")
              .OnDelete(DeleteBehavior.NoAction);  // or DeleteBehavior.Restrict

            modelBuilder.Entity<Game>()
                .HasOne(g => g.PlayerB)
                .WithMany()
                .HasForeignKey("PlayerBId")
                .OnDelete(DeleteBehavior.NoAction);  // or DeleteBehavior.Restrict

            modelBuilder.Entity<Game>()
                .HasOne(g => g.Opening)
                .WithMany()
                .HasForeignKey("OpeningId")
                .OnDelete(DeleteBehavior.NoAction);  // or DeleteBehavior.Restrict
        }
    }
}
