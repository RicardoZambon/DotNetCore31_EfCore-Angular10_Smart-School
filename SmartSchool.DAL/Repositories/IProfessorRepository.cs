using SmartSchool.DAL.DatabaseObjects;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.DAL.Repositories
{
    public interface IProfessorRepository
    {
        IQueryable<Professor> GetAllProfessores();

        Task<Professor> GetProfessorByIdAsync(int professorId);


        Task AddAsync(Professor professor);

        Task UpdateAsync(Professor professor);

        Task DeleteAsync(Professor professor);


        Task<bool> SaveChangesAsync();
    }
}