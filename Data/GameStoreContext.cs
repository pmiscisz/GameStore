using GameStore.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().HasData(new Game { Id = 1, Title = "Witcher 3", Developer = "CDRedStudio", Price = 29.99 },
            new Game { Id = 2, Title = "Cyberpunk", Developer = "CDRedStudio", Price = 39.99 },
            new Game { Id = 3, Title = "The Legend of Zelda", Developer = "IDK", Price = 19.99 },
            new Game { Id = 4, Title = "Skyrim", Developer = "Bethesda", Price = 15.99 });

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "FirstUser", Email = "firstuser@email.com", Password = "Admin", UserPermission = User.Permission.User });
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
