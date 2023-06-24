using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolManager.Application.Behaviors;
using System.Reflection;

namespace SchoolManager.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
            );

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}