using Api.HealthMed.Domain.Settings;
using Api.HealthMed.Infrastructure.Connection;
using Api.HealthMed.Infrastructure.Interfaces.Connection;
using Api.HealthMed.Infrastructure.Interfaces.Repositories;
using Api.HealthMed.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Api.HealthMed.DependencyInjection.Extensions.AddInfrastructureLayer;

public static partial class AddInfrastructureLayerExtensions
{
    public static IServiceCollection AddSettings(this IServiceCollection services) =>
        services.AddBindedSettings<DbSettings>();

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IPacienteRepository, PacienteRepository>()
                       .AddScoped<IMedicoRepository, MedicoRepository>()
                       .AddScoped<IDatabaseConnection, DatabaseConnection>();
    }

    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services
            .AddSettings()
            .AddRepositories();
}