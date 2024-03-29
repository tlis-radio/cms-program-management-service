using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence;
using Tlis.Cms.ProgramManagement.Infrastructure.Persistence.Interfaces;

namespace Tlis.Cms.ProgramManagement.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IProgramManagementDbContext, ProgramManagementDbContext>(options =>
            {
                options
                    .UseNpgsql(
                        configuration.GetConnectionString("Postgres"),
                        x => x.MigrationsHistoryTable(
                            HistoryRepository.DefaultTableName, 
                            "cms_program_management"))
                    .UseSnakeCaseNamingConvention();
            },
            contextLifetime: ServiceLifetime.Transient,
            optionsLifetime: ServiceLifetime.Singleton);
        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}