﻿using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Tasks.Api.OperationFilters;
using Tasks.Core.Configuration;
using Tasks.Data.Entities;
using Tasks.Data.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Tasks.Api.Configuration
{
    public static class DependenciesConfiguration
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException(nameof(connectionString));
            }

            services
                .AddDbContext<ApplicationDbContext>(opts => opts.UseSqlServer(connectionString))
                .AddEntityFrameworkSqlServer();
        }

     
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new Info { Title = "Tasks.Api", Version = "v1" });
                setup.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Tasks.Api.Documentation.xml"));

                setup.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Enter 'Bearer {token}' (don't forget to add 'bearer') into the field below.", Name = "Authorization", Type = "apiKey" });

                setup.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", Enumerable.Empty<string>() },
                });

                setup.OperationFilter<OptionOperationFilter>();
            });
        }

        public static void AddCors(this IServiceCollection services, string url)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("Policy", builder => builder

                    .WithOrigins(url)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                );
            });
        }
    }
}
