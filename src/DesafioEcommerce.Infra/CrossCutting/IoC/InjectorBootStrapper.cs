using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Interfaces.Repository;
using DesafioEcommerce.Domain.Interfaces.Services;
using DesafioEcommerce.Domain.Notifications;
using DesafioEcommerce.Domain.Services;
using DesafioEcommerce.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioEcommerce.Infra.CrossCutting.IoC
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain - Services
            services.AddScoped<IProductService, ProductService>();

            // Infra - Repostories
            services.AddScoped<IProductRepository, ProductRepository>();

            // Infra - Notifications
            services.AddScoped<INotifiable, Notifiable>();
        }
    }
}
