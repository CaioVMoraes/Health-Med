using Api.HealthMed.Application;
using Api.HealthMed.Application.Interfaces.Services;
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
