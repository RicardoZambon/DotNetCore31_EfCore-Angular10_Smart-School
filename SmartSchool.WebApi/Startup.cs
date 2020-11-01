using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SmartSchool.DAL;
using SmartSchool.DAL.Repositories;
using SmartSchool.DAL.Repositories.EfCore;
using SmartSchool.WebApi.Services;
using SmartSchool.WebApi.Services.Handlers;
using System.Text;

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

            services.AddCors();

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
            services.AddScoped<IUserRepository, UserRepository>();

            //Services
            services.AddScoped<IAlunoService, DefaultAlunoService>();
            services.AddScoped<IDisciplinaService, DefaultDisciplinaService>();
            services.AddScoped<IProfessorService, DefaultProfessorService>();
            services.AddScoped<IUserService, DefaultUserService>();

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
                                return destProperty != null;
                            }
                            return !sourceProperty.Equals(destProperty);
                        });
                    });
                });
            },
            typeof(Startup).Assembly);

            //Authentication
            var apiSecrets = Configuration[$"Settings:{nameof(TokenSecrets.ApiSecrets)}"];

            services.AddScoped<ITokenService, TokenService>();
            services.Configure<TokenSecrets>(s => s.ApiSecrets = apiSecrets)
                .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(apiSecrets)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization();
            });
        }
    }
}