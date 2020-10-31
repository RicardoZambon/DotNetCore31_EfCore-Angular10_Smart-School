using AutoMapper;
using SmartSchool.DAL.DatabaseObjects;

namespace SmartSchool.WebApi.Models
{
    [AutoMap(typeof(Disciplina), ReverseMap = true)]
    public class DisciplinaEditModel
    {
        public string Nome { get; set; }

        public int ProfessorId { get; set; }
    }
}