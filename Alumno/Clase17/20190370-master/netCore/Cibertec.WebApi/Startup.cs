﻿using System;
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

            // habilitar CORS
            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            //.WithOrigins(new string[] { "o1", "o2" })

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
