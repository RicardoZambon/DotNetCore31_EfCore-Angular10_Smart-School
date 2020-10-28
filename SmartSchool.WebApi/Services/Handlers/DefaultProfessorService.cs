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

        public async Task<ProfessorEditModel> GetProfessorAsync(int professorId)
            => mapper.Map(await professorRepository.GetProfessorByIdAsync(professorId), new ProfessorEditModel());

        public async Task<bool> AddProfessorAsync(ProfessorEditModel model)
        {
            var professor = new Professor();

            mapper.Map(model, professor);
            await professorRepository.AddAsync(professor);

            return (await context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> UpdateProfessorAsync(int professorId, ProfessorEditModel model)
        {
            var professor = (await professorRepository.GetProfessorByIdAsync(professorId));

            if (professor == null)
            {
                throw new KeyNotFoundException();
            }

            mapper.Map(model, professor);
            await professorRepository.UpdateAsync(professor);

            return (await context.SaveChangesAsync()) > 0;
        }

        public async Task<bool> DeleteProfessorAsync(int professorId)
        {
            var professor = (await professorRepository.GetProfessorByIdAsync(professorId));

            if (professor == null)
            {
                throw new KeyNotFoundException();
            }

            await professorRepository.DeleteAsync(professor);

            return (await context.SaveChangesAsync()) > 0;
        }
    }
}