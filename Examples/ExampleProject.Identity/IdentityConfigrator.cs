using Core.DAL.Identity;
using ExampleProject.Identity.EF;
using ExampleProject.Identity.Entities;
using ExampleProject.Identity.Models;
using ExampleProject.Identity.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Text;

namespace ExampleProject.Identity
{
    public class IdentityConfigrator : IIdentityConfigurator
    {
        private string _configFile => "jwt.json";

        public void ConfigureIdentity(IServiceCollection serviceCollection)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile(_configFile).Build();
            var jwtOptions = configuration.GetSection(JWTOptions.JWTSettings).Get<JWTOptions>();

            serviceCollection.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders()
                .AddTokenProvider("MyApp", typeof(DataProtectorTokenProvider<ApplicationUser>));

            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(o =>
               {
                   o.RequireHttpsMetadata = false;
                   o.SaveToken = false;
                   o.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ClockSkew = TimeSpan.Zero,
                       ValidIssuer = jwtOptions.Issuer,
                       ValidAudience = jwtOptions.Audience,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
                   };
                   o.Events = new JwtBearerEvents()
                   {
                       OnAuthenticationFailed = c =>
                       {
                           c.NoResult();
                           c.Response.StatusCode = 500;
                           c.Response.ContentType = "text/plain";
                           return c.Response.WriteAsync(c.Exception.ToString());
                       },
                       OnChallenge = context =>
                       {
                           context.HandleResponse();
                           context.Response.StatusCode = 401;
                           context.Response.ContentType = "application/json";
                           var result = JsonConvert.SerializeObject(new BaseResponse<string>("You are not Authorized"));
                           return context.Response.WriteAsync(result);
                       },
                       OnForbidden = context =>
                       {
                           context.Response.StatusCode = 403;
                           context.Response.ContentType = "application/json";
                           var result = JsonConvert.SerializeObject(new BaseResponse<string>("You are not authorized to access this resource"));
                           return context.Response.WriteAsync(result);
                       },
                   };
               });
        }
    }
}
