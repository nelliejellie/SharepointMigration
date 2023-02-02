using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SharePointMigration.Data;
using SharePointMigration.Service;

[assembly: FunctionsStartup(typeof(SharePointMigration.Startup))]
namespace SharePointMigration
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var serviceProvider = builder.Services.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();

            var executionContextOptions = builder.Services.BuildServiceProvider()
                .GetService<IOptions<ExecutionContextOptions>>().Value;

            builder.Services.AddSingleton<IConfiguration>(sp => new ConfigurationBuilder()
                .SetBasePath(executionContextOptions.AppDirectory)
                .AddConfiguration(configuration)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build());

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<ITokenService, TokenService>();

            builder.Services.AddScoped<DynamicsApi>();
            builder.Services.AddTransient<IGraphSharePointListAccess, GraphSharePointListAccess>();
            builder.Services.AddScoped<IBPSProjectDifferentialsService, BPSProjectDifferentialsService>();
            builder.Services.AddScoped<IBrickColorsService, BrickColorsService>();
            builder.Services.AddScoped<ICompletedRequestsService, CompletedRequestsService>();
            builder.Services.AddScoped<IDesignCenterAppoitnmentsService, DesignCenterAppointmentsService>();
            builder.Services.AddScoped<IDesignCenterDataService, DesignCenterDataService>();
            builder.Services.AddScoped<IDesignCenterProjectEmailListService, DesignCenterProjectEmailListService>();
            builder.Services.AddScoped<IElevationsListService, ElevationsListService>();
            builder.Services.AddScoped<IEstimatorDetailsService, EstimatorDetailsService>();
            builder.Services.AddScoped<IETCDatesPaidService, ETCDatesPaidService>();
            builder.Services.AddScoped<IExteriorandInteriorSelectionsService, ExteriorandInteriorSelectionsService>();
            builder.Services.AddScoped<IFinanceCSECreditAmountsService, FinanceCSECreditAmountsService>();
            builder.Services.AddScoped<IHoustonMLSDetailsService, HoustonMLSDetailsService>();
            builder.Services.AddScoped<IJobDataForLotFitRequestsService, JobDataForLotFitRequestsService>();
            builder.Services.AddScoped<ILotInventoryBankholidaysService, LotInventoryBankholidaysService>();
            builder.Services.AddScoped<ILotInventoryDeveloperListService, LotInventoryDeveloperListService>();
            builder.Services.AddScoped<ILotInventoryTitleCompanyListService, LotInvenotryTitleCompanyListService>();
            builder.Services.AddScoped<IMonitorsService, MonitorsService>();
            builder.Services.AddScoped<INonHoustonMLSDetailsService, NonHoustonMLSDetailsService>();
            builder.Services.AddScoped<IPaintedBrickColorsService, PaintedBrickColorsService>();
            builder.Services.AddScoped<IPlanandElevationService, PlanandElevationService>();
            builder.Services.AddScoped<IPlanListService, PlanListService>();
            builder.Services.AddScoped<IPlanMenusService, PlanMenusService>();
            builder.Services.AddScoped<IPlanOptionsSqFtChangeService, PlanOptionsSqFtChangeService>();
            builder.Services.AddScoped<IMonitorsService, MonitorsService>();
            builder.Services.AddScoped<IRealtorPresentationFormService, RealtorPresentationFormService>();
            builder.Services.AddScoped<ISalesNeedInputService, SalesNeedInputService>();
            builder.Services.AddScoped<IStuccoColorsService, StuccoColorsService>();
            builder.Services.AddScoped<IStuccoElevationsService, StuccoElevationsService>();
            builder.Services.AddScoped<IProjectsService, ProjectsService>();
            builder.Services.AddScoped<ISubdivisionRequirementsListService, SubdivisionRequirementsListService>();
            builder.Services.AddScoped<ISubDivisionSelectionTypeService, SubdivisionSelectionTypeService>();
        }
    }
}