using SmartSchool.WebApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebApi.Services
{
    public interface IProfessorService
    {
        IQueryable<ProfessorListModel> GetAllProfessores();

        Task<ProfessorEditModel> GetProfessorAsync(int professorId);

        Task<bool> AddProfessorAsync(ProfessorEditModel model);

        Task<bool> UpdateProfessorAsync(int professorId, ProfessorEditModel model);

        Task<bool> DeleteProfessorAsync(int professorId);
    }
}