using HallOfFame.Data;
using HallOfFame.Interfaces;
using HallOfFameServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace HallOfFame
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
            services.AddControllers();

            services.AddSwaggerGen(c => c.SwaggerDoc
                ("v1", new OpenApiInfo
                    {
                        Title = "Hall of Fame API",
                        Version = "v1",
                        Description = "API"
                    }
                )
            );

            services.AddDbContext<HallOfFameDbContext>(options => options.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=test;Password=12345"));

            services.AddScoped<IHallOfFameService, HallOfFameService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
