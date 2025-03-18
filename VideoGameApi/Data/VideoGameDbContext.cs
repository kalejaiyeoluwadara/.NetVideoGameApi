using Microsoft.EntityFrameworkCore;
using VideoGameApi.Models;

namespace VideoGameApi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        public DbSet<VideoGameDetails> VideoGameDetails => Set<VideoGameDetails>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define foreign key relationship explicitly
            modelBuilder.Entity<VideoGameDetails>()
                .HasOne(vd => vd.VideoGame) // Navigation property
                .WithMany() // A video game can have multiple details
                .HasForeignKey(vd => vd.VideoGameId) // Foreign key
                .OnDelete(DeleteBehavior.Cascade); // If a game is deleted, its details are also deleted

            // Seed data (if needed)
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "The Legend of Zelda: Breath of the Wild",
                    Platform = "Nintendo Switch",
                    Developer = "Nintendo EPD",
                    Publisher = "Nintendo"
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "The Legend of Zelda 2: Breath of the Wild",
                    Platform = "Nintendo Switch",
                    Developer = "Nintendo EPD",
                    Publisher = "Nintendo"
                }
            );
        }


    }



}