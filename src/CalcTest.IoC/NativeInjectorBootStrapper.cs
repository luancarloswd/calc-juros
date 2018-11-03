using CalcTest.Crosscutting.Interfaces;
using CalcTest.Crosscutting.Notifications;
using CalcTest.Service.Interfaces;
using CalcTest.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CalcTest.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IDomainNotificationManager, DomainNotificationManager>();
            services.AddScoped<IJurosCompostosService, JurosCompostosService>();
        }
    }
}
