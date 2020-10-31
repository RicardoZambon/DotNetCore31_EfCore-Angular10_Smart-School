using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartSchool.DAL.DatabaseObjects.EfCore
{
    public class AlunoDisciplinaConfiguration : IEntityTypeConfiguration<AlunoDisciplina>
    {
        public void Configure(EntityTypeBuilder<AlunoDisciplina> builder)
        {
            builder.HasKey(x => new { x.AlunoId, x.DisciplinaId });

            builder.HasData(new[]
            {
                new AlunoDisciplina { AlunoId = 1, DisciplinaId = 2 },
                new AlunoDisciplina { AlunoId = 1, DisciplinaId = 4 },
                new AlunoDisciplina { AlunoId = 1, DisciplinaId = 5 },
                new AlunoDisciplina { AlunoId = 2, DisciplinaId = 1 },
                new AlunoDisciplina { AlunoId = 2, DisciplinaId = 2 },
                new AlunoDisciplina { AlunoId = 2, DisciplinaId = 5 },
                new AlunoDisciplina { AlunoId = 3, DisciplinaId = 1 },
                new AlunoDisciplina { AlunoId = 3, DisciplinaId = 2 },
                new AlunoDisciplina { AlunoId = 3, DisciplinaId = 3 },
                new AlunoDisciplina { AlunoId = 4, DisciplinaId = 1 },
                new AlunoDisciplina { AlunoId = 4, DisciplinaId = 4 },
                new AlunoDisciplina { AlunoId = 4, DisciplinaId = 5 },
                new AlunoDisciplina { AlunoId = 5, DisciplinaId = 4 },
                new AlunoDisciplina { AlunoId = 5, DisciplinaId = 5 },
                new AlunoDisciplina { AlunoId = 6, DisciplinaId = 1 },
                new AlunoDisciplina { AlunoId = 6, DisciplinaId = 2 },
                new AlunoDisciplina { AlunoId = 6, DisciplinaId = 3 },
                new AlunoDisciplina { AlunoId = 6, DisciplinaId = 4 },
                new AlunoDisciplina { AlunoId = 7, DisciplinaId = 1 },
                new AlunoDisciplina { AlunoId = 7, DisciplinaId = 2 },
                new AlunoDisciplina { AlunoId = 7, DisciplinaId = 3 },
                new AlunoDisciplina { AlunoId = 7, DisciplinaId = 4 },
                new AlunoDisciplina { AlunoId = 7, DisciplinaId = 5 }
            });
        }
    }
}