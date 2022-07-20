using Microsoft.Extensions.DependencyInjection;

namespace PhonebookMVC.Services
{
    public static class ServiceInjections
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
            return services;
        }
    }
}
