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

            app.UseMvc();
            try { 
            var sqlRetryPolicy = Policy
              .Handle<Exception>()
              .WaitAndRetry(new[]
              {
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(10)
              });

            sqlRetryPolicy.Execute(() =>
            {
                InitializeDatabase(initializer);
            });
            }
            catch( Exception ex)
            {
                //TOO: Log this
            }

        }

        private void InitializeDatabase(DbInitializer initializer)
        {
            using (var context = new QuizBoxContext())
            {
                context.Database.Migrate();
            }

            initializer.Seed();
        }
    }
}
