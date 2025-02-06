using Api.HealthMed.DependencyInjection.Extensions.AddApplicationLayer;
using Api.HealthMed.DependencyInjection.Extensions.AddInfrastructureLayer;
using Microsoft.Extensions.DependencyInjection;

namespace Api.HealthMed.DependencyInjection;

public static class Bootstrap
{
    public static IServiceCollection RegisterServices(this IServiceCollection services) =>
        services
            .AddInfrastructure()
            .AddApplication();
}
