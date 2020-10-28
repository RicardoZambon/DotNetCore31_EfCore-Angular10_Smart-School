using SmartSchool.WebApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebApi.Services
{
    public interface IDisciplinaService
    {
        IQueryable<DisciplinaListModel> GetAllDisciplinas();

        Task<DisciplinaEditModel> GetDisciplinaAsync(int disciplinaId);

        Task<bool> AddDisciplinaAsync(DisciplinaEditModel model);

        Task<bool> UpdateDisciplinaAsync(int disciplinaId, DisciplinaEditModel model);

        Task<bool> DeleteDisciplinaAsync(int disciplinaId);
    }
}