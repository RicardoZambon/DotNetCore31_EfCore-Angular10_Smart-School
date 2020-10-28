namespace SmartSchool.DAL.DatabaseObjects
{
    public class AlunoDisciplina
    {
        public int AlunoId { get; set; }

        public virtual Aluno Aluno { get; set; }

        public int DisciplinaId { get; set; }

        public virtual professor Disciplina { get; set; }
    }
}