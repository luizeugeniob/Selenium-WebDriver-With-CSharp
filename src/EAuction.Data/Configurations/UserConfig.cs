using EAuction.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAuction.WebApp.Data
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new { Id = 1, Email = "johndoe@example.org", Password = "123", InterestedId = 1 });
            builder.HasData(new { Id = 2, Email = "janedoe@example.org", Password = "456", InterestedId = 2 });
            builder.HasData(new { Id = 3, Email = "smithjohn@example.org", Password = "123" });
        }
    }
}