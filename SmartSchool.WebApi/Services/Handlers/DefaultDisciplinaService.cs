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

        public async Task<DisciplinaEditModel> GetDisciplinaAsync(int disciplinaId)
            => mapper.Map(await disciplinaRepository.GetDisciplinaByIdAsync(disciplinaId), new DisciplinaEditModel());

        public async Task<bool> AddDisciplinaAsync(DisciplinaEditModel model)
        {
            var disciplina = new Disciplina();

            mapper.Map(model, disciplina);
            await disciplinaRepository.AddAsync(disciplina);

            return (await context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> UpdateDisciplinaAsync(int disciplinaId, DisciplinaEditModel model)
        {
            var disciplina = (await disciplinaRepository.GetDisciplinaByIdAsync(disciplinaId));

            if (disciplina == null)
            {
                throw new KeyNotFoundException();
            }

            mapper.Map(model, disciplina);
            await disciplinaRepository.UpdateAsync(disciplina);

            return (await context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeleteDisciplinaAsync(int disciplinaId)
        {
            var disciplina = (await disciplinaRepository.GetDisciplinaByIdAsync(disciplinaId));

            if (disciplina == null)
            {
                throw new KeyNotFoundException();
            }

            await disciplinaRepository.DeleteAsync(disciplina);

            return (await context.SaveChangesAsync()) > 0;
        }
    }
}
