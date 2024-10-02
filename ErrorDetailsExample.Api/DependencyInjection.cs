using ErrorDetailsExample.Api.Mapping;

namespace ErrorDetailsExample.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddProblemDetails();
        services.AddAutoMapper(typeof(MappingProfile));
        
        return services;
    }
}
