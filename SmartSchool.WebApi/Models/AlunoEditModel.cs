using AutoMapper;
using SmartSchool.DAL.DatabaseObjects;

namespace SmartSchool.WebApi.Models
{
    [AutoMap(typeof(Aluno), ReverseMap = true)]
    public class AlunoEditModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Telefone { get; set; }
    }

    //public class AlunoEditModelProfile : Profile
    //{
    //    public AlunoEditModelProfile()
    //    {
    //        CreateMap<EmployeeEditModel, Employees>()
    //            .ForMember(x => x.PasswordHash, opt =>
    //            {
    //                opt.PreCondition(src => !string.IsNullOrEmpty(src.Password));
    //                opt.MapFrom(src => PasswordHash.Create(src.ID, src.Password));
    //            });

    //        CreateMap<Employees, EmployeeEditModel>()
    //            .ForMember(x => x.Password, opt =>
    //            {
    //                opt.Ignore();
    //            });
    //    }
    //}
}