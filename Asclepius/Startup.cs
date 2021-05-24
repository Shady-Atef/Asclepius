using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asclepius
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
            #region Identity
            services.AddIdentity<ApplicationUser, IdentityRole<long>>(
               opt =>
               {
                   opt.Lockout.AllowedForNewUsers = true;
                   opt.Lockout.MaxFailedAccessAttempts = Configuration.GetValue<int>("Auth:MaxFailedAccessAttemptsBeforeLockout");
                    //opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(Configuration.GetValue<double>("Auth:DefaultAccountLockoutTimeSpan"));
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.MaxValue;

               })
               .AddEntityFrameworkStores<AsclepiusContext>()
               .AddDefaultTokenProviders();
            #endregion
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddMicrosoftIdentityWebApi(Configuration.GetSection("AzureAd"));



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Asclepius", Version = "v1" });
            });

            services.AddDbContext<AsclepiusContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Asclepius"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asclepius v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
