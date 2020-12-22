using afmr.api.Extensions;
using afmr.api.ModelBinders;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.IO;

namespace afmr.api
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
            services.AddLogging();

            services.RegisterDependencies((ConfigurationRoot)Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("CoorsPolicy", builder =>
               {
                   builder.AllowAnyOrigin();
                   builder.AllowAnyMethod();
                   builder.AllowAnyHeader();
               });
            });

            services.AddControllers(options =>
            {
                //ensure UTC is sent and transformed into DateTime in .Net
                options.ModelBinderProviders.Insert(0, new DateTimeUtcModelBinderProvider());
            });

            services.ConfigureSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app, 
            IWebHostEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseHttpStatusCodeExceptionMiddleware();
            }
            else
            {
                //app.UseHttpStatusCodeExceptionMiddleware();
                //app.UseExceptionHandler();

            }

            app.UseSwaggerConfig();

            app.UseHttpsRedirection();
            
            app.UseDefaultFiles();

            app.UseStaticFiles();

            app.UserTokenHandler();

            app.UseCors("CoorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}