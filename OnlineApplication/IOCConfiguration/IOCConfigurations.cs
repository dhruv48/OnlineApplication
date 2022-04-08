using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace OnlineApplication.IOCConfiguration
{
    public class IOCConfigurations
    {
        public static void Configuration(IServiceCollection services)
        {
            Configure(services,OnlineApplication.DB.IOC.Module.GetTypes());
            Configure(services, OnlineApplication.Business.IOC.Module.GetTypes());

        }


        private static void Configure(IServiceCollection services, Dictionary<Type, Type> types)
        {
            foreach (var type in types)
            {
                services.AddScoped(type.Key, type.Value);
            }

        }
    }
}
