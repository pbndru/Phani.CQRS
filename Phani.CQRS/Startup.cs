using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Phani.CQRS.Infrastructure;
using Phani.Services.Vehicles.Queries;

namespace Phani.CQRS
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
            //register http context to the services
            services.AddHttpContextAccessor();

            //register the pipe. we can add multiple pipes and executed by the order they added from top to bottom
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AuthorizedIdPipe<,>));

            //register medieators. Get where assemblies of handlers live
            services.AddMediatR(typeof(GetAllVehiclesQuery).Assembly);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
