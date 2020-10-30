using EAuction.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAuction.WebApp.Data
{
    internal class BidConfig : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder
                .HasOne(bid => bid.Auction)
                .WithMany(auction => auction.Bids);

            builder
                .HasOne(bid => bid.Interested)
                .WithMany(i => i.Bids);
        }
    }
}