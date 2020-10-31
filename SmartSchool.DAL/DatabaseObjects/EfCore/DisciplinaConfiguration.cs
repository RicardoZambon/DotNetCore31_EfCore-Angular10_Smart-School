using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartSchool.DAL.DatabaseObjects.EfCore
{
    public class DisciplinaConfiguration : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(EntityTypeBuilder<Disciplina> builder)
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
                new Disciplina { Id = 1, Nome = "Matemática", ProfessorId = 1 },
                new Disciplina { Id = 2, Nome = "Física", ProfessorId = 2 },
                new Disciplina { Id = 3, Nome = "Português", ProfessorId = 3 },
                new Disciplina { Id = 4, Nome = "Inglês", ProfessorId = 4 },
                new Disciplina { Id = 5, Nome = "Programação", ProfessorId = 5 }
            });
        }
    }
}