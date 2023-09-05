using HelperPayment.Application.Abstraction.Commands;
using HelperPayment.Application.Abstraction.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.Scan(s => s.FromAssemblies(typeof(ICommandHandler<>).Assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.Scan(s => s.FromAssemblies(typeof(IEventHandler<>).Assembly)
                .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }
    }
}