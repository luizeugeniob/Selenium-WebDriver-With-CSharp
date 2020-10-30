using EAuction.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAuction.WebApp.Data
{
    internal class FavoriteConfig : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder
                .HasKey(f => new { f.AuctionId, f.InterestedId });

            builder
                .HasOne(f => f.FavoriteAuction)
                .WithMany(l => l.Followers)
                .HasForeignKey(f => f.AuctionId);

            builder
                .HasOne(f => f.Follower)
                .WithMany(i => i.Favorites)
                .HasForeignKey(f => f.InterestedId);
        }
    }
}