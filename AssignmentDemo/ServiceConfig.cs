using ApplicationCore.Interfaces;
using ApplicationCore.Service;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AssignmentDemo
{
    public static class ServiceConfig
    {
        public static void RegisterConfig(IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddTransient<IItemsService, ItemsService>();
            services.AddTransient<IOptionsService, OptionsService>();
            services.AddTransient(typeof(IRepository<>), typeof(EfRepository<>));
        }
    }
}
