using EAuction.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EAuction.WebApp.Data
{
    internal class AuctionConfig : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder
                .HasOne(l => l.Winner);

            builder
                .Property(l => l.State)
                .HasConversion(e => e.ToString(), e => Enum.Parse<AuctionState>(e));
        }
    }
}