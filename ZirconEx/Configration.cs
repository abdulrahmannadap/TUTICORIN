using DataAccess.DbAccess;
using DataAccess.Service.Implimentation;
using DataAccess.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace ZirconEx
{
    public static class Configration
    {
        /// <summary>
        /// Register Your Dependencies
        /// </summary>
        /// <param name="builder">builder</param>
        public static void RegisterDependencies(WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
            });
            builder.Services.AddTransient<IUnitOfWork,UnitOfWork>();

        }
    }
}