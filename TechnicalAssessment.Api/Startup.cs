using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TechnicalAssessment.Api.Configuration;
using TechnicalAssessment.Api.Repositories;
using TechnicalAssessment.Api.BL;

namespace TechnicalAssessment.Api
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
            services.AddOptions();

            services
                .AddOptions<SqlServerOptions>()
                .Bind(Configuration.GetSection("SqlServer"))
                .ValidateDataAnnotations();

            services.AddControllers();
            services.AddDbContext<ITechnicalAssessmentContext, TechnicalAssessmentContext>((serviceProvider, options) =>
            {
                var sqlServerOptions = serviceProvider.GetService<IOptionsMonitor<SqlServerOptions>>();
                options.UseSqlServer(sqlServerOptions.CurrentValue.ConnectionString, optionsBuilder =>
                {
                    optionsBuilder.EnableRetryOnFailure();
                });
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderLineRepository, OrderLineRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechnicalAssessment", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechnicalAssessment v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
