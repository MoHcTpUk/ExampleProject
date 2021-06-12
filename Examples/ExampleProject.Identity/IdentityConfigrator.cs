using Core.DAL.Identity;
using ExampleProject.Identity.EF;
using ExampleProject.Identity.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleProject.Identity
{
    public class IdentityConfigrator : IIdentityConfigurator
    {
        public void ConfigureIdentity(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<IdentityDbContext>();
        }
    }
}
