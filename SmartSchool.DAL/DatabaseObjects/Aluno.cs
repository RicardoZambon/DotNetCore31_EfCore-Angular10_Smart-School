﻿using SmartSchool.DAL.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmartSchool.DAL.DatabaseObjects
{
    public class Aluno : ISoftDelete
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Nome { get; set; }

        [StringLength(200)]
        public string Sobrenome { get; set; }

        [StringLength(50)]
        public string Telefone { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<AlunoDisciplina> Disciplinas { get; set; }
    }
}