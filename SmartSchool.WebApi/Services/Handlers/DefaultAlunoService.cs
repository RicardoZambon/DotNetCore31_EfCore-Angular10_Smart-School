using AutoMapper;
using AutoMapper.QueryableExtensions;
using SmartSchool.DAL;
using SmartSchool.DAL.DatabaseObjects;
using SmartSchool.DAL.Repositories;
using SmartSchool.WebApi.Models;
using System.Collections.Generic;
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

        public async Task<AlunoEditModelReturn> AddAlunoAsync(AlunoEditModel model)
        {
            var aluno = new Aluno();

            mapper.Map(model, aluno);
            await alunoRepository.AddAsync(aluno);

            await context.SaveChangesAsync();
            return mapper.Map(aluno, new AlunoEditModelReturn());
        }

        public async Task<AlunoEditModelReturn> UpdateAlunoAsync(int alunoId, AlunoEditModel model)
        {
            var aluno = (await alunoRepository.GetAlunoByIdAsync(alunoId));

            if (aluno == null)
            {
                throw new KeyNotFoundException();
            }

            mapper.Map(model, aluno);
            await alunoRepository.UpdateAsync(aluno);

            await context.SaveChangesAsync();
            return mapper.Map(aluno, new AlunoEditModelReturn());
        }

        public async Task<bool> DeleteAlunoAsync(int alunoId)
        {
            var aluno = (await alunoRepository.GetAlunoByIdAsync(alunoId));

            if (aluno == null)
            {
                throw new KeyNotFoundException();
            }

            await alunoRepository.DeleteAsync(aluno);

            return (await context.SaveChangesAsync()) > 0;
        }
    }
}