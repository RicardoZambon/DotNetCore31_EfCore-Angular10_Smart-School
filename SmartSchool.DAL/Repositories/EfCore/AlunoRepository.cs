using SmartSchool.DAL.DatabaseObjects;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.DAL.Repositories.EfCore
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly DataContext context;

        public AlunoRepository(DataContext context)
        {
            this.context = context;
        }


        public async Task AddAsync(Aluno aluno)
            => await context.AddAsync(aluno);

        public async Task DeleteAsync(Aluno aluno)
            => await Task.Run(() => context.Remove(aluno));

        public IQueryable<Aluno> GetAllAlunos()
            => context.Set<Aluno>().AsQueryable();

        public async Task<Aluno> GetAlunoByIdAsync(int alunoId)
            => await context.FindAsync<Aluno>(alunoId);

        public IQueryable<Aluno> GetAlunosByDisciplinaId(int disciplinaId)
            => GetAllAlunos().Where(x => x.Disciplinas.Any(y => y.DisciplinaId == disciplinaId));

        public async Task UpdateAsync(Aluno aluno)
            => await Task.Run(() => context.Update(aluno));
    }
}