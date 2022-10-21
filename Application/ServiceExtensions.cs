using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    //Agupar las inyecciones de nuestros servicios de terceros o propios.
    static class ServiceExtensions
    {
        public static void AddAplicationLayer(this IServiceCollection service) {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
