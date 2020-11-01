using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartSchool.DAL.Security;

namespace SmartSchool.DAL.DatabaseObjects.EfCore
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.Username)
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValueSql("0")
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            builder.HasIndex(x => x.Username).IsUnique().IncludeProperties(x => new { x.Id, x.PasswordHash });

            builder.HasData(new[]
            {
                new User { Id = 1, Username = "demo", PasswordHash = PasswordHash.Create(1, "demo") }
            });
        }
    }
}