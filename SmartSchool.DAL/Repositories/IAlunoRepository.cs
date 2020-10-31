using SmartSchool.DAL.DatabaseObjects;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.DAL.Repositories
{
    public interface IAlunoRepository
    {
        IQueryable<Aluno> GetAllAlunos();

        IQueryable<Aluno> GetAlunosByDisciplinaId(int disciplinaId);

        Task<Aluno> GetAlunoByIdAsync(int alunoId);


        Task AddAsync(Aluno aluno);

        Task UpdateAsync(Aluno aluno);

        Task DeleteAsync(Aluno aluno);
    }
}