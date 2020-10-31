using AutoMapper;
using SmartSchool.DAL.DatabaseObjects;

namespace SmartSchool.WebApi.Models
{
    [AutoMap(typeof(Professor), ReverseMap = true)]
    public class ProfessorEditModelReturn
    {
        public string Nome { get; set; }
    }
}