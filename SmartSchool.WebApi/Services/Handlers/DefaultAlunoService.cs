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
    public class DefaultAlunoService : IAlunoService
    {
        private readonly IAlunoRepository alunoRepository;
        private readonly DataContext context;
        private readonly IMapper mapper;

        public DefaultAlunoService(IAlunoRepository alunoRepository, DataContext context, IMapper mapper)
        {
            this.alunoRepository = alunoRepository;
            this.context = context;
            this.mapper = mapper;
        }


        public IQueryable<AlunoListModel> GetAllAlunos()
            => alunoRepository.GetAllAlunos().ProjectTo<AlunoListModel>(mapper.ConfigurationProvider);

        public IQueryable<AlunoDisciplinaListModel> GetAlunosByDisciplinaId(int disciplinaId)
            => alunoRepository.GetAlunosByDisciplinaId(disciplinaId).ProjectTo<AlunoDisciplinaListModel>(mapper.ConfigurationProvider);

        public async Task<AlunoEditModel> GetAlunoAsync(int alunoId)
            => mapper.Map(await alunoRepository.GetAlunoByIdAsync(alunoId), new AlunoEditModel());

        public async Task SaveAlunoAsync(AlunoEditModel model)
        {
            var aluno = model.Id > 0 ? (await alunoRepository.GetAlunoByIdAsync(model.Id)) : new Aluno();

            mapper.Map(model, aluno);

            if (model.Id <= 0)
            {
                await alunoRepository.AddAsync(aluno);
            }
            else
            {
                await alunoRepository.UpdateAsync(aluno);
            }

            await context.SaveChangesAsync();
        }
    }
}