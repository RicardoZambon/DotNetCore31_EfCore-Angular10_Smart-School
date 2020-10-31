using AutoMapper;
using SmartSchool.DAL.DatabaseObjects;

namespace SmartSchool.WebApi.Models
{
    public class DisciplinaListModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Professor { get; set; }
    }

    public class DisciplinaListModelProfile : Profile
    {
        public DisciplinaListModelProfile()
        {
            CreateMap<Disciplina, DisciplinaListModel>()
                .ForMember(x => x.Professor, opt =>
                {
                    opt.MapFrom(y => y.Professor.Nome);
                });
        }
    }
}