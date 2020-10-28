using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace SmartSchool.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var options = this.GetService<IDbContextOptions>();
            var migrationsAssembly = Assembly.Load(RelationalOptionsExtension.Extract(options).MigrationsAssembly);

            modelBuilder.ApplyConfigurationsFromAssembly(migrationsAssembly);
        }
    }
}