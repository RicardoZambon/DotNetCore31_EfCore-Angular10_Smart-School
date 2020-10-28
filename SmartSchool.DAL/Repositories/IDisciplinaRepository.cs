using SmartSchool.DAL.DatabaseObjects;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.DAL.Repositories
{
    public interface IDisciplinaRepository
    {
        IQueryable<Disciplina> GetAllDisciplinas();

        Task<Disciplina> GetDisciplinaByIdAsync(int disciplinaId);


        Task AddAsync(Disciplina disciplina);

        Task UpdateAsync(Disciplina disciplina);

        Task DeleteAsync(Disciplina disciplina);


        Task<bool> SaveChangesAsync();
    }
}