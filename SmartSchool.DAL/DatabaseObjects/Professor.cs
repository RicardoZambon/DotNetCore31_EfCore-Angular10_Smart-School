using SmartSchool.DAL.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.DAL.DatabaseObjects
{
    public class Professor : ISoftDelete
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Nome { get; set; }
        
        public bool IsDeleted { get; set; }

        public virtual ICollection<Disciplina> Disciplinas { get; set; }
    }
}