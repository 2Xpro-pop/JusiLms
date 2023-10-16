using System.Diagnostics.CodeAnalysis;
using Refit;

namespace JusiLms;

public static class ServiceCollectionRefitExtensions
{
    public static IServiceCollection AddRefitApi<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this IServiceCollection services) where T : class
    {
        return services.AddScoped(services =>
        {
            return RestService.For<T>(services.GetRequiredService<HttpClient>());
        });
    }
}
