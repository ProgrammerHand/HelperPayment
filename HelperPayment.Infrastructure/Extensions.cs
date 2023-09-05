using Helper.Infrastructure;
using Helper.Infrastructure.Dispatchers;
using HelperPayment.Application.Abstraction.Commands;
using HelperPayment.Application.Abstraction.Events;
using HelperPayment.Application.Abstraction.Queries;
using HelperPayment.Core.Invoice;
using HelperPayment.Core.Offer;
using HelperPayment.Core.Utility;
using HelperPayment.Infrastructure.DAL;
using HelperPayment.Infrastructure.DAL.Repositories;
using HelperPayment.Infrastructure.Dispatchers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelperPayment.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            services.AddSingleton<IEventDispatcher, EventDispatcher>();

            services.AddHttpContextAccessor();
            services.AddSingleton<IClockCustom, ClockCustom>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            
            services.AddDb(configuration);

            var infrastructureAssembly = typeof(AppOptions).Assembly;

            services.Scan(s => s.FromAssemblies(infrastructureAssembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            return services;
        }

        public static WebApplication UseInfrastructure(this WebApplication app)
        {
            //app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();
            app.UseReDoc(reDoc =>
            {
                reDoc.RoutePrefix = "docs";
                reDoc.SpecUrl("/swagger/v1/swagger.json");
                reDoc.DocumentTitle = "MySpot API";
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
        {
            var options = new T();
            var section = configuration.GetRequiredSection(sectionName);
            section.Bind(options);

            return options;
        }
    }
}