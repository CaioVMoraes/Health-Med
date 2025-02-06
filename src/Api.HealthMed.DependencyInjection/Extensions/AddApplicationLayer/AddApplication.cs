using Api.HealthMed.Services;
using Api.HealthMed.Services.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.HealthMed.DependencyInjection.Extensions.AddApplicationLayer;

public static partial class AddApplicationLayerExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services.AddScoped<IMedicoService, MedicoService>()
                .AddScoped<IPacienteService, PacienteService>();

    public static IServiceCollection AddApplication(this IServiceCollection services) => services
        .AddServices();
}
