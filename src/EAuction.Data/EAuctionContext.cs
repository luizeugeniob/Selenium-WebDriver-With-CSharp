using Microsoft.EntityFrameworkCore;
using EAuction.Core;

namespace EAuction.WebApp.Data
{
    public class EAuctionContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Interested> Interesteds { get; set; }
        public DbSet<User> Users { get; set; }

        public EAuctionContext(DbContextOptions<EAuctionContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AuctionConfig());
            modelBuilder.ApplyConfiguration(new BidConfig());
            modelBuilder.ApplyConfiguration(new FavoriteConfig());
            modelBuilder.ApplyConfiguration(new InterestedConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
        }
    }
}
