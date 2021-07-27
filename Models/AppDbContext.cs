using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LinkAggregator.Models
{
    public class AppDbContext : IdentityDbContext<UserEntity>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<LinkEntity> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LinkEntity>().HasData(new LinkEntity
            {
                LinkId = 1,
                Url = "https://www.wp.pl",
                Points = 11,
                Title = "Strona internetowa wp"
            });
            modelBuilder.Entity<LinkEntity>().HasData(new LinkEntity
            {
                LinkId = 2,
                Url = "https://www.onet.pl",
                Points = -1,
                Title = "Strona internetowa onet"
            });
            modelBuilder.Entity<LinkEntity>().HasData(new LinkEntity
            {
                LinkId = 3,
                Url = "https://www.youtube.pl",
                Points = 0,
                Title = "Strona internetowa yt"
            });
            modelBuilder.Entity<LinkEntity>().HasData(new LinkEntity
            {
                LinkId = 4,
                Url = "https://www.fb.pl",
                Points = 1123,
                Title = "Strona internetowa fb"
            });
        }
    }
}