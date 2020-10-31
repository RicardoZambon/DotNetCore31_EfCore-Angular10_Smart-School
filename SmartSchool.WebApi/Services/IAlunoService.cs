using SmartSchool.WebApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebApi.Services
{
    public interface IAlunoService
    {
        IQueryable<AlunoListModel> GetAllAlunos();

        IQueryable<AlunoDisciplinaListModel> GetAlunosByDisciplinaId(int disciplinaId);

        Task<AlunoEditModel> GetAlunoAsync(int alunoId);

        Task<AlunoEditModelReturn> AddAlunoAsync(AlunoEditModel model);

        Task<AlunoEditModelReturn> UpdateAlunoAsync(int alunoId, AlunoEditModel model);

        Task<bool> DeleteAlunoAsync(int alunoId);
    }
}