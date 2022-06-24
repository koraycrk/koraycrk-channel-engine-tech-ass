
using ChannelEngineAssessment.Core;
using ChannelEngineAssessment.Core.Interfaces;
using ChannelEngineAssessment.Infrastructure.Logging;
using ChannelEngineAssessment.Infrastructure.Data;
using ChannelEngineAssessment.Infrastructure.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ChannelEngineAssessment.Core.Repositories;
using ChannelEngineAssessment.Core.Repositories.Base;
using ChannelEngineAssessment.Core.Configuration;
using ChannelEngineAssessment.Infrastructure.Repository.Base;

namespace ChannelEngineAssessment.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ChannelEngineAssessment dependencies
            ConfigureChannelEngineAssessmentServices(services);            

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddRazorPages();
        }        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        private void ConfigureChannelEngineAssessmentServices(IServiceCollection services)
        {
            // Add Core Layer
            services.Configure<ChannelEngineAssessmentSettings>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            

            // Add Web Layer
            services.AddAutoMapper(typeof(Startup)); // Add AutoMapper
           

            // Add Miscellaneous
            services.AddHttpContextAccessor();
           
        }

        public void ConfigureDatabases(IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<ChannelEngineAssessmentContext>(c =>
                c.UseInMemoryDatabase("ChannelEngineAssessmentConnection"));

            //// use real database
            //services.AddDbContext<ChannelEngineAssessmentContext>(c =>
            //    c.UseSqlServer(Configuration.GetConnectionString("ChannelEngineAssessmentConnection")));
        }
    }
}
