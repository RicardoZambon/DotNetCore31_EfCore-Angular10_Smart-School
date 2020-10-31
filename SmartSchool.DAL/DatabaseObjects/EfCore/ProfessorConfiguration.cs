using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartSchool.DAL.DatabaseObjects.EfCore
{
    class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd()
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(x => x.IsDeleted)
                .HasDefaultValueSql("0")
                .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            builder.HasData(new[]
            {
                new Professor { Id = 1, Nome = "Lauro" },
                new Professor { Id = 2, Nome = "Roberto" },
                new Professor { Id = 3, Nome = "Ronaldo" },
                new Professor { Id = 4, Nome = "Rodrigo" },
                new Professor { Id = 5, Nome = "Alexandre" },
            });
        }
    }
}