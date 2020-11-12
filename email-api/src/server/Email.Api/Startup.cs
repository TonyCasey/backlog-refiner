using System;
using System.Text;
using AutoMapper;
using Email.Api.Configuration;
using Email.Api.Filters;
using Email.Api.ModelBinders;
using Email.Business.AutoRrest;
using Email.Business.Identity;
using Email.Business.Services;
using Email.Core.Configuration;
using Email.Core.Identity;
using Email.Core.Models.SendGrid;
using Email.Core.Services;
using Email.Data.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Rest;
using SendGrid;
using Serilog;

namespace Email.Api
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
            services.AddCors(Configuration.GetValue<string>("ClientUIApplicationUrl"));

            services.AddLogging(logBuilder => logBuilder.AddSerilog(dispose: true));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration.GetSection(nameof(JwtConfiguration))["Issuer"],
                    ValidAudience = Configuration.GetSection(nameof(JwtConfiguration))["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection(nameof(JwtConfiguration))["Secret"])),
                    ValidateLifetime = false
                };
            });

            services.Configure<StsConfiguration>(Configuration.GetSection("StsConfiguration"));
            services.Configure<SendGridConfigurationOptions>(Configuration.GetSection("SendGridConfigurationOptions"));

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ISendGridService, SendGridService>();
            services.AddTransient<IUserService, UserService>();

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
            app.UseSwagger("Email API.");
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
