using DesafioEcommerce.Domain.Commands;
using DesafioEcommerce.Domain.Entities;
using DesafioEcommerce.Domain.Interfaces;
using DesafioEcommerce.Domain.Interfaces.Repository;
using DesafioEcommerce.Domain.Interfaces.Services;
using DesafioEcommerce.Domain.Notifications;
using DesafioEcommerce.Domain.Services;
using DesafioEcommerce.Domain.Validations;
using DesafioEcommerce.Domain.ValueObjects;
using DesafioEcommerce.Infra.Data.Repository;
using DesafioEcommerce.Infra.Data.Transactions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioEcommerce.Infra.CrossCutting.IoC
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain - Services
            services.AddScoped<IProductService, ProductService>();

            // Infra - UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Repostories
            services.AddScoped<IProductRepository, ProductRepository>();

            // Infra - Notifications
            services.AddScoped<INotifiable, Notifiable>();

            // Domain - Validations
            services.AddTransient<IValidator<Product>, ProductValidation>();
            services.AddTransient<IValidator<Email>, EmailValidation>();
            services.AddTransient<IValidator<Payment>, PaymentValidation>();
            services.AddTransient<IValidator<CreateCreditCardPaymentCommand>, CreateCreditCardPaymentCommandValidation>();
        }
    }
}
