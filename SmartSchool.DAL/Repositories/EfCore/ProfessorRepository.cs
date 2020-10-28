using SmartSchool.DAL.DatabaseObjects;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.DAL.Repositories.EfCore
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly DataContext context;

        public ProfessorRepository(DataContext context)
        {
            this.context = context;
        }


        public async Task AddAsync(Professor professor)
            => await context.AddAsync(professor);

        public async Task DeleteAsync(Professor professor)
            => await Task.Run(() => context.Remove(professor));

        public IQueryable<Professor> GetAllProfessores()
            => context.Set<Professor>().AsQueryable();

        public async Task<Professor> GetProfessorByIdAsync(int professorId)
            => await context.FindAsync<Professor>(professorId);

        public async Task<bool> SaveChangesAsync()
            => await context.SaveChangesAsync() > 0;

        public async Task UpdateAsync(Professor professor)
            => await Task.Run(() => context.Update(professor));
    }
}