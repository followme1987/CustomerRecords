using CustomerRecords.Application.Service;
using CustomerRecords.Application.Service.Interface;
using CustomerRecords.Infrastructure.Service;
using CustomerRecords.WebApi.ErrorHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerRecords.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<ICustomerGenerationService, CustomerGenerationByJsonFileService>()
                .AddSingleton<IGenericDistanceCalculatorService, DistanceCalculatorDefaultFormulasService>()
                .AddSingleton<IFileOperationService, FileOperationService>(_ => new FileOperationService(Configuration["FileSection:FilePath"]))
                .BuildServiceProvider();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSingleton<IConfiguration>(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMiddleware<CustomExceptionMiddleware>();

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
