using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SchoolManager.Domain.Contratcts.Infrastructure.Repositories;
using SchoolManager.Infrastructure.DbContext;
using SchoolManager.Infrastructure.Repositories;


namespace SchoolManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services
                .AddContext(configuration)
                .AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();

            return services;
        }

        private static IServiceCollection AddContext(
            this IServiceCollection services, ConfigurationManager configuration)
        {
            var DapperSettings = new DapperSettings();
            configuration.Bind(DapperSettings.SectionName, DapperSettings);
            services.AddSingleton(Options.Create(DapperSettings));
            services.AddSingleton<DapperContext>();

            return services;
        }
    }

}