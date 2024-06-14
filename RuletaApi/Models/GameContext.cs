using Microsoft.EntityFrameworkCore;

namespace RuletaApi.Models
{
    public class GameContext: DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        { 
        }

        public DbSet<Game> Games { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<Game>(entity =>
            {

                entity.ToTable("Game");
                entity.HasKey(p => p.UserName).HasName("PK_GAme");

                entity.Property(p => p.UserName)

                .HasColumnName("UserName");

                entity.Property(p => p.Balance)

                .HasColumnName("Balance");

            });

        }
    }
}
