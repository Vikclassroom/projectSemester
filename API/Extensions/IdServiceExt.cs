using API.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class IdServiceExt
    {
        public static IServiceCollection AddIdServices(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<AppAccount>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddSignInManager<SignInManager<AppAccount>>();
           
            // préparation suite semestre 2
            services.AddAuthentication();
            
            return services;
        }
    }
}
