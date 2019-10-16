using APIModeloDDD.Domain.Interfaces;
using APIModeloDDD.Domain.Validations;
using APIModeloDDD.Infra.Data.Context;
using APIModeloDDD.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIModeloDDD.Infra.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Repositories
            services.AddTransient<IPersonRepository, PersonRepository>();
            #endregion

            #region Validations
            services.AddScoped<PersonPostValidator>();
            services.AddScoped<PersonAuthValidator>();
            #endregion

            services.AddDbContext<Context>(o => o.UseSqlServer("Server=localhost;Database=dbmodelo;User Id=sa;Password=sa@12345;"));
        }
    }
}
