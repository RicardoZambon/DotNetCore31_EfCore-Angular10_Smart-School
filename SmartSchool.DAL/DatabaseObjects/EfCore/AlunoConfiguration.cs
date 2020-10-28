using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartSchool.DAL.DatabaseObjects.EfCore
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasData(new[]
            {
                new Aluno { Id = 1, Nome = "Marta", Sobrenome = "Kent", Telefone = "33225555" },
                new Aluno { Id = 2, Nome = "Paula", Sobrenome = "Isabela", Telefone = "3354288" },
                new Aluno { Id = 3, Nome = "Laura", Sobrenome = "Antonia", Telefone = "55668899" },
                new Aluno { Id = 4, Nome = "Luiza", Sobrenome = "Maria", Telefone = "6565659" },
                new Aluno { Id = 5, Nome = "Lucas", Sobrenome = "Machado", Telefone = "565685415" },
                new Aluno { Id = 6, Nome = "Pedro", Sobrenome = "Alvares", Telefone = "456454545" },
                new Aluno { Id = 7, Nome = "Paulo", Sobrenome = "José", Telefone = "9874512" }
            });
        }
    }
}