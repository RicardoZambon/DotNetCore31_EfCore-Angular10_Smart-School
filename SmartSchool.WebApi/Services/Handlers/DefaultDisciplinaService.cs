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
    public class DefaultDisciplinaService : IDisciplinaService
    {
        private readonly IDisciplinaRepository disciplinaRepository;
        private readonly DataContext context;
        private readonly IMapper mapper;

        public DefaultDisciplinaService(IDisciplinaRepository disciplinaRepository, DataContext context, IMapper mapper)
        {
            this.disciplinaRepository = disciplinaRepository;
            this.context = context;
            this.mapper = mapper;
        }


        public IQueryable<DisciplinaListModel> GetAllDisciplinas()
            => disciplinaRepository.GetAllDisciplinas().ProjectTo<DisciplinaListModel>(mapper.ConfigurationProvider);

        public async Task<DisciplinaEditModel> GetDisciplinaAsync(int alunoId)
            => mapper.Map(await disciplinaRepository.GetDisciplinaByIdAsync(alunoId), new DisciplinaEditModel());

        public async Task SaveDisciplinaAsync(DisciplinaEditModel model)
        {
            var disciplina = model.Id > 0 ? (await disciplinaRepository.GetDisciplinaByIdAsync(model.Id)) : new Disciplina();

            mapper.Map(model, disciplina);

            if (model.Id <= 0)
            {
                await disciplinaRepository.AddAsync(disciplina);
            }
            else
            {
                await disciplinaRepository.UpdateAsync(disciplina);
            }

            await context.SaveChangesAsync();
        }
    }
}
