using AutoMapper;
using Find.Me.Api.Mapping;
using Find.Me.Api.Repository;
using Find.Me.Api.Repository.Mapping;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Find.Me.Api
{
    public class Startup
    {
        readonly string LooseOriginsPolicy = "_AllowAllOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddInfrastructure(Configuration);
            services.AddSwaggerGen();
            services.AddMediatR(Assembly.GetExecutingAssembly());

            var mappingProfiles = new Profile[]
            {
                new UserProfile(),
                new UserEntityToDomainProfile()
            };
            services.AddAutoMapper(context => context.AddProfiles(mappingProfiles));
            services.AddCors(o => o.AddPolicy(
                LooseOriginsPolicy, 
                b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                )
            ); // this needs to be properly configured;
        }
                
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(LooseOriginsPolicy);

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "Find Me API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHealthChecks("/health");
        }
    }
}
