using Tlis.Cms.ProgramManagement.Api.Extensions;
using Tlis.Cms.ProgramManagement.Infrastructure;
using Tlis.Cms.ProgramManagement.Application;
using Microsoft.AspNetCore.Localization;

namespace Tlis.Cms.ProgramManagement.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMemoryCache();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddControllers();

            builder.Services.ConfigureProblemDetails();
            builder.Services.ConfigureSwagger();
            builder.Services.ConfigureAuthorization(builder.Configuration);

            builder.Logging.AddConsole();
            builder.Logging.ConfigureOtel(builder.Environment);
            builder.Services.ConfigureOtel(builder.Environment);

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            var app = builder.Build();

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("sk-SK")
            });

            app.UseExceptionHandler();
            app.UseStatusCodePages();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

