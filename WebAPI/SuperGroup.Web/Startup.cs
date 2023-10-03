using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SuperGroup.Data;
using SuperGroup.Web.Models;
using System;

namespace SuperGroup.Web
{
    public class Startup
    {
        private ServicesInstaller _servicesInstaller;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _servicesInstaller = new ServicesInstaller(services);
            services.AddControllers();
            services.AddDbContext<SuperGroupDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SuperGroupDBContext"))); // Specify the correct migrations assembly here

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200");
                        builder.AllowAnyHeader();
                        builder.AllowCredentials();
                    });
            });
            services.AddControllers()
                          .AddJsonOptions(options =>
                          {
                              options.JsonSerializerOptions.PropertyNamingPolicy = null; // Remove property name casing policy,

                          });
            _servicesInstaller.installServices();
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1",
                new OpenApiInfo { Title = "SuperGroup API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json",
                "SuperGroup API");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SeedData.SeedDatabase(serviceProvider.GetRequiredService<SuperGroupDBContext>());
        }
    }
}