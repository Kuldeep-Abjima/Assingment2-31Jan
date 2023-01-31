using Student.Data;
using Student.DataInterface;

namespace Assingment2
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomDatabase(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IDataBaseFactory>(x =>
            {
                return new DataBaseFactory(x.GetRequiredService<ILogger<IDataBaseFactory>>(), configuration.GetConnectionString("DBconnection"));


            });
            return services;
        
        }
    }
}
