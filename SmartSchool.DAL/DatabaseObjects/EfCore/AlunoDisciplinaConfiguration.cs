using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartSchool.DAL.DatabaseObjects.EfCore
{
    public class AlunoDisciplinaConfiguration : IEntityTypeConfiguration<AlunoDisciplina>
    {
        public void Configure(EntityTypeBuilder<AlunoDisciplina> builder)
        {
            builder.HasKey(x => new { x.AlunoId, x.DisciplinaId });
        }
    }
}