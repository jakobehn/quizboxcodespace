using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QBox.Api.Migrations;
using QBoxCore.Api.Models;
using Polly;
using System.Data.SqlClient;
using System;
using Prometheus;

namespace QBoxCore.Api
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
            services.AddMvc();

            services.AddTransient<DbInitializer>(d => new DbInitializer(new QuizBoxContext()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DbInitializer initializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMetricServer();
            app.UseMvc();
            InitializeDatabase(initializer);
        }

        private async void InitializeDatabase(DbInitializer initializer)
        {
            int retryCount = 3;
            int i = 0;
            while(i < retryCount)
            {
                try{
                    using (var context = new QuizBoxContext())
                    {
                        context.Database.Migrate();
                    }
                    i = 3;
                }
                catch( Exception ex)
                {
                    System.Threading.Thread.Sleep(3000);
                    i = i +1;
                }

            }

            initializer.Seed();
        }
    }
}
