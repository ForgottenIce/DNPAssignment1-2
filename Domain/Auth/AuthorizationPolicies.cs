using Microsoft.Extensions.DependencyInjection;

namespace Domain.Auth;

public class AuthorizationPolicies {
    public static void AddPolicies(IServiceCollection services) { //TODO make real policies
        services.AddAuthorizationCore(options => {
            options.AddPolicy("MustBeManager", a =>
                a.RequireAuthenticatedUser().RequireClaim("Role", "Manager"));
        });
    }
}