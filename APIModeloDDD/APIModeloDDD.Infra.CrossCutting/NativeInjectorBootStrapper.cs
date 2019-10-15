using APIModeloDDD.Domain.Interfaces;
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
            //services.AddScoped<UsuarioValidations>();
            //services.AddScoped<LivrosValidations>();
            //services.AddScoped<LoginValidations>();
            #endregion

            services.AddDbContext<Context>(o => o.UseSqlServer("Server=localhost;Database=dbmodelo;User Id=sa;Password=sa@12345;"));
        }
    }
}
