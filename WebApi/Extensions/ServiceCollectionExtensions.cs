using SimpleInjector.Lifestyles;
using SimpleInjector;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSimpleInjector(this IServiceCollection services)
        {
            Container container = new Container();
            container.Options.DefaultLifestyle = Lifestyle.Scoped;
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            services.AddSimpleInjector(container, options =>
            {
                options.AddAspNetCore()
                    .AddControllerActivation();
            });

            SimpleInjectorBootstrap.InitializeContainer(container);

            return services;
        }

    }
}
