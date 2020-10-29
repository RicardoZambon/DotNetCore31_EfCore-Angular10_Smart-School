using AutoMapper;
using SmartSchool.DAL.DatabaseObjects;

namespace SmartSchool.WebApi.Models
{
    [AutoMap(typeof(Disciplina), ReverseMap = false)]
    public class DisciplinaEditModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int ProfessorId { get; set; }
    }
}