using Student.Data;
using Student.DataInterface;
using StudentServices.Infrastructure.Builder.MapperProfile;
using Scrutor;
using Student.serviceInterFace;
using StudentServices;
using Assingment2.Controllers;
using Student.Model;

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
        public static IServiceCollection AddCustomMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DtoToModelMappingProfile));
            services.AddAutoMapper(typeof(ModelToDtoMappingProfile));
            return services;
        }
        public static IServiceCollection AddCustomAssimblies(this IServiceCollection services)
        {
            var type = new List<Type>()
            {
              typeof(IDataBaseFactory),
              typeof(DataBaseFactory),
              typeof(IStudentService),
              typeof(StudentService),
              typeof(StudentController)

            };
            services.Scan(scan => scan
                .FromAssembliesOf(type)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());
            services.AddTransient<StudentModel>();
            return services;

        }
    }
}
