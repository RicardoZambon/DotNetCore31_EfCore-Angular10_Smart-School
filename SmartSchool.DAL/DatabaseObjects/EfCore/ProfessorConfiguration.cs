using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartSchool.DAL.DatabaseObjects.EfCore
{
    class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> builder)
        {
            builder.HasData(new[]
            {
                new Professor() { Id = 1, Nome = "Lauro" },
                new Professor() { Id = 2, Nome = "Roberto" },
                new Professor() { Id = 3, Nome = "Ronaldo" },
                new Professor() { Id = 4, Nome = "Rodrigo" },
                new Professor() { Id = 5, Nome = "Alexandre" },
            });
        }
    }
}