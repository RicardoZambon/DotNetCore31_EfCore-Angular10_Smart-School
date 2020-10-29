using SmartSchool.WebApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebApi.Services
{
    public interface IDisciplinaService
    {
        IQueryable<DisciplinaListModel> GetAllDisciplinas();

        Task<DisciplinaEditModel> GetDisciplinaAsync(int disciplinaId);

        Task<DisciplinaEditModelReturn> AddDisciplinaAsync(DisciplinaEditModel model);

        Task<DisciplinaEditModelReturn> UpdateDisciplinaAsync(int disciplinaId, DisciplinaEditModel model);

        Task<bool> DeleteDisciplinaAsync(int disciplinaId);
    }
}