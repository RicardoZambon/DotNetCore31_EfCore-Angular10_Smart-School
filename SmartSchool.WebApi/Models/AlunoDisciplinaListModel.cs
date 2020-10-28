using AutoMapper;
using SmartSchool.DAL.DatabaseObjects;

namespace SmartSchool.WebApi.Models
{
    [AutoMap(typeof(Aluno), ReverseMap = false)]
    public class AlunoDisciplinaListModel
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Telefone { get; set; }
    }
}