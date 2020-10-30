using EAuction.Core;
using EAuction.WebApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EAuctionWebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration cfg)
        {
            Configuration = cfg;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EAuctionContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("EAuctionDB"));
            });

            services.AddTransient<IEvaluationMode, UpperAmount>();
            services.AddTransient<IRepository<Auction>, AuctionRepository>();
            services.AddTransient<IRepository<Interested>, InterestedRepository>();
            services.AddTransient<IRepository<User>, UserRepository>();

            services.AddSession();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();

            app.UseMvcWithDefaultRoute();
        }
    }
}
