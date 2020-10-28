using AutoMapper;
using SmartSchool.DAL.DatabaseObjects;

namespace SmartSchool.WebApi.Models
{
    [AutoMap(typeof(Professor), ReverseMap = false)]
    public class ProfessorEditModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
    }
}