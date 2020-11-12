using AutoMapper;
using Sts.Api.Configuration;
using Sts.Api.Filters;
using Sts.Api.ModelBinders;
using Sts.Business.Identity;
using Sts.Business.Services;
using Sts.Core.Configuration;
using Sts.Core.Identity;
using Sts.Core.Services;
using Sts.Data.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Sts.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext(Configuration.GetConnectionString("DbConnectionString"));
            services.AddAutoMapper();
            services.AddSwagger();
            services.AddJwtIdentity(Configuration.GetSection(nameof(JwtConfiguration)));
            services.AddCors(Configuration.GetValue<string>("ClientUIApplicationUrl"));
            

            services.AddLogging(logBuilder => logBuilder.AddSerilog(dispose: true));

            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IJwtFactory, JwtFactory>();
            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ITeamUserService, TeamUserService>();

            services.AddMvc(options =>
            {
                options.ModelBinderProviders.Insert(0, new OptionModelBinderProvider());
                options.Filters.Add<ExceptionFilter>();
                options.Filters.Add<ModelStateFilter>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ApplicationDbContext dbContext)
        {
            app.UseCors("Policy");

            dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                //dbContext.Database.EnsureCreated();
            }
            else
            {
                app.UseHsts();
            }

            loggerFactory.AddLogging(Configuration.GetSection("Logging"));

            app.UseHttpsRedirection();
            app.UseSwagger("Sts API");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
