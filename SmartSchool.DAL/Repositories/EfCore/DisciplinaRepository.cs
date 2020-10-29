using SmartSchool.DAL.DatabaseObjects;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.DAL.Repositories.EfCore
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly DataContext context;

        public DisciplinaRepository(DataContext context)
        {
            this.context = context;
        }


        public async Task AddAsync(Disciplina disciplina)
            => await context.AddAsync(disciplina);

        public async Task DeleteAsync(Disciplina disciplina)
            => await Task.Run(() => context.Remove(disciplina)).ConfigureAwait(false);

        public IQueryable<Disciplina> GetAllDisciplinas()
            => context.Set<Disciplina>().AsQueryable();

        public async Task<Disciplina> GetDisciplinaByIdAsync(int disciplinaId)
            => await context.FindAsync<Disciplina>(disciplinaId);

        public async Task UpdateAsync(Disciplina disciplina)
            => await Task.Run(() => context.Update(disciplina)).ConfigureAwait(false);
    }
}