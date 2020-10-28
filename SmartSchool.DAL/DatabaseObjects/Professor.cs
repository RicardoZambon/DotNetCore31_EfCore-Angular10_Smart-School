using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.DAL.DatabaseObjects
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Nome { get; set; }

        public ICollection<Disciplina> Disciplinas { get; set; }
    }
}