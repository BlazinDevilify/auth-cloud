using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthCloud.Shared.Users
{
    public static class Extensions
    {
        public static IServiceCollection AddUserService<T>(this IServiceCollection service) where T : class, IUserService
        {
            return service.AddTransient<IUserService, T>();
        }
    }
}
