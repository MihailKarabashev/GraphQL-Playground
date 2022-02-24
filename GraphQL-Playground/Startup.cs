using GraphQL_Playground.Data;
using GraphQL_Playground.GraphQL.Players;
using GraphQL_Playground.GraphQL.Teams;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace GraphQL_Playground
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddPooledDbContextFactory<AppDbContext>(
                options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services
                .AddGraphQLServer()
                .AddQueryType()
                .AddMutationType()

                .AddTypeExtension<TeamQueries>()
                .AddTypeExtension<TeamMutations>()
                .AddDataLoader<TeamByIdDataLoader>()

                .AddTypeExtension<PlayerQueries>()

                .AddFiltering()
                .AddSorting()
                .AddProjections();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
