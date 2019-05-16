using Aranda.Users.BackEnd.Repositories.Definition;
using Aranda.Users.BackEnd.Repositories.Implementation;
using Aranda.Users.BackEnd.Services.Definition;
using Aranda.Users.BackEnd.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Aranda.Users.BackEnd
{
    public static class ServiceCollectionExtension
    {
        public static void DependencyInjectionRepositories(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IRoleRepository, RoleRepository>();
        }

        public static void DependencyInjectionServices(this IServiceCollection service)
        {
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IRoleService, RoleService>();
        }
    }
}
