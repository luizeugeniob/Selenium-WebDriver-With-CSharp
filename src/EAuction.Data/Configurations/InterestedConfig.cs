using EAuction.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAuction.WebApp.Data
{
    internal class InterestedConfig : IEntityTypeConfiguration<Interested>
    {
        public void Configure(EntityTypeBuilder<Interested> builder)
        {
            builder.HasData(
                new Interested("John Doe") { Id = 1 },
                new Interested("Jane Doe") { Id = 2 },
                new Interested("John Smith") { Id = 3 });
        }
    }
}