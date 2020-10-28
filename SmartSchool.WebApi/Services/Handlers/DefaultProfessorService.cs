using AutoMapper;
using AutoMapper.QueryableExtensions;
using SmartSchool.DAL;
using SmartSchool.DAL.DatabaseObjects;
using SmartSchool.DAL.Repositories;
using SmartSchool.WebApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.WebApi.Services.Handlers
{
    public class DefaultProfessorService : IProfessorService
    {
        private readonly IProfessorRepository professorRepository;
        private readonly DataContext context;
        private readonly IMapper mapper;

        public DefaultProfessorService(IProfessorRepository professorRepository, DataContext context, IMapper mapper)
        {
            this.professorRepository = professorRepository;
            this.context = context;
            this.mapper = mapper;
        }


        public IQueryable<ProfessorListModel> GetAllProfessores()
            => professorRepository.GetAllProfessores().ProjectTo<ProfessorListModel>(mapper.ConfigurationProvider);

        public async Task<ProfessorEditModel> GetProfessorAsync(int alunoId)
            => mapper.Map(await professorRepository.GetProfessorByIdAsync(alunoId), new ProfessorEditModel());

        public async Task SaveProfessorAsync(ProfessorEditModel model)
        {
            var disciplina = model.Id > 0 ? (await professorRepository.GetProfessorByIdAsync(model.Id)) : new Professor();

            mapper.Map(model, disciplina);

            if (model.Id <= 0)
            {
                await professorRepository.AddAsync(disciplina);
            }
            else
            {
                await professorRepository.UpdateAsync(disciplina);
            }

            await context.SaveChangesAsync();
        }
    }
}