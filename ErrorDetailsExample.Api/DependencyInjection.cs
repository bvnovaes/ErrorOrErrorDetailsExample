using ErrorDetailsExample.Api.Controllers.Mapping;

namespace ErrorDetailsExample.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        
        return services;
    }
}