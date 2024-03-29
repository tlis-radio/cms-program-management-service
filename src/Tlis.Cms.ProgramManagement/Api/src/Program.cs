using Tlis.Cms.ProgramManagement.Api.Extensions;
using Tlis.Cms.ProgramManagement.Infrastructure;

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
            // builder.Logging.ConfigureOtel();
            // builder.Services.ConfigureOtel();

            // builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            var app = builder.Build();
            
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

