using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SmartSchool.DAL;
using SmartSchool.DAL.Repositories;
using SmartSchool.DAL.Repositories.EfCore;
using SmartSchool.WebApi.Services;
using SmartSchool.WebApi.Services.Handlers;

namespace SmartSchool.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //EFCore
            services.AddDbContextPool<DataContext>((optionsBuilder) =>
            {
                optionsBuilder
                    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                    .UseLazyLoadingProxies()
                    .UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"),
                        b =>
                            b.MigrationsAssembly(typeof(DataContext).Assembly.GetName().Name)
                    );
            });

            //Repositories
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();

            //Services
            services.AddScoped<IAlunoService, DefaultAlunoService>();
            services.AddScoped<IDisciplinaService, DefaultDisciplinaService>();
            services.AddScoped<IProfessorService, DefaultProfessorService>();

            //AutoMapper
            services.AddAutoMapper(config =>
            {
                config.ForAllMaps((typeMap, config) =>
                {
                    config.ForAllMembers(opt =>
                    {
                        opt.Condition((sourceObject, destObject, sourceProperty, destProperty) =>
                        {
                            if (sourceProperty == null)
                            {
                                return !(destProperty == null);
                            }
                            return !sourceProperty.Equals(destProperty);
                        });
                    });
                });
            },
            typeof(Startup).Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}