using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Cibertec.WebApi.Models;
using System.Text;
using Cibertec.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Cibertec.WebApi.Hubs;

namespace Cibertec.WebApi
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
            // configurar las dependencias
            services.AddSingleton<IUnitOfWork>(option => new NorthwindUnitOfWork(Configuration.GetConnectionString("Northwind")));

            // depdencia de IAuthService
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            // leer la configuración para generar los JWT del appSettings.json
            services.Configure<TokenManagement>(Configuration.GetSection("tokenManagement"));
            var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();

            // configurar autenticación con JWT
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerConfig =>
            {
                bearerConfig.RequireHttpsMetadata = false;
                bearerConfig.SaveToken = true;
                bearerConfig.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
                    ValidIssuer = token.Issuer,
                    ValidAudience = token.Audience,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            // habilitar CORS
            services.AddCors();

            services.AddAuthorization(auth =>
            {
                auth.DefaultPolicy = new AuthorizationPolicyBuilder(new[] { JwtBearerDefaults.AuthenticationScheme }).RequireAuthenticatedUser().Build();
            });

            // Habilitar singlR
            services.AddSignalR();

            // Habilitar CORS
            services.AddCors();

            // habilitar la autenticación a nivel global
            services.AddMvc(config => config.Filters.Add(new AuthorizeFilter())).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // configurar CORS
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            // configurar el aplicativo para que utilice la autenticación
            app.UseAuthentication();

            //.WithOrigins(new string[] { "o1", "o2" })

            app.UseHttpsRedirection();

            // Configurar SignalR
            app.UseSignalR(hubs => hubs.MapHub<ChatHub>("/chathub"));

            app.UseMvc();
        }
    }
}
