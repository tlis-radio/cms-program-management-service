using Microsoft.AspNetCore.Authentication.JwtBearer;
using Tlis.Cms.ProgramManagement.Api.Constants;

namespace Tlis.Cms.ProgramManagement.Api.Extensions;

public static class AuthorizationSetup
{
    public static void ConfigureAuthorization(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = configuration.GetSection("Jwt").GetValue<string>("Authority");
                options.Audience = configuration.GetSection("Jwt").GetValue<string>("Audience");
                options.RequireHttpsMetadata = configuration.GetSection("Jwt").GetValue<bool>("RequireHttpsMetadata");
                options.SaveToken = true;
            });
        
        services.AddAuthorization(options =>
        {
            options.AddPolicy(
                Policy.ProgramWrite,
                policy => policy.RequireClaim("permissions", "write:program"));
            options.AddPolicy(
                Policy.ProgramDelete,
                policy => policy.RequireClaim("permissions", "delete:program"));
            options.AddPolicy(
                Policy.ProgramRead,
                policy => policy.RequireClaim("permissions", "read:program"));
        });
    }
}