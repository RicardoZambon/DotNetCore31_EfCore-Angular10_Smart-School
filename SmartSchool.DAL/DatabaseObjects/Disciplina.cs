using System.ComponentModel.DataAnnotations;

namespace SmartSchool.DAL.DatabaseObjects
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Nome { get; set; }

        public int ProfessorId { get; set; }

        public virtual Professor Professor { get; set; }
    }
}