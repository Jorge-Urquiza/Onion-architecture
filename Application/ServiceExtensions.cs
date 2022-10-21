using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    //Agupar las inyecciones de nuestros servicios de terceros o propios.
    static class ServiceExtensions
    {
        public static void AddAplicationLayer(this IServiceCollection service) {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //add pattern mediator.
            service.AddMediatR(Assembly.GetExecutingAssembly());
  
        }
    }
}
    