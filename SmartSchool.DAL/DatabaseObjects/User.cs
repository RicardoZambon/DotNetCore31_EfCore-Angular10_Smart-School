using SmartSchool.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartSchool.DAL.DatabaseObjects
{
    public class User : ISoftDelete
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(100)]
        public string PasswordHash { get; set; }

        public bool IsDeleted { get; set; }
    }
}