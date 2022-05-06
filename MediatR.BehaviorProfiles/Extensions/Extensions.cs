using Microsoft.Extensions.DependencyInjection;

namespace MediatR.BehaviorProfiles.Extensions;

public static class Extensions
{
    /// <summary>
    /// Adds and configures the MediatR behavior profile.
    /// </summary>
    /// <returns>IServiceCollection</returns>
    public static IServiceCollection AddBehaviorProfile<T>(this IServiceCollection services) where T : BehaviorProfile
    {
        return Activator
            .CreateInstance<T>()
            .Configure(services);
    }
}