using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ApiHelpDents.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using ApiHelpDents.Infraestructure.Repositories;
using ApiHelpDents.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace ApiHelpDents
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

            services.AddDbContext<HelpDents_Db_FinalContext>(options=>
                                                        options.UseSqlServer(Configuration.GetConnectionString("connectionDB")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiHelpDents", Version = "v1" });
            });

            services.AddTransient<IAdministradorRepository, AdministradorRepository>();
            services.AddTransient<IAsesorRepository, AsesorRepository>();
            services.AddTransient<IComentarioRepository, ComentarioRepository>();
            services.AddTransient<IEspecialidadRepository, EspecialidadRepository>();
            services.AddTransient<ITurnoRepository, TurnoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IAsesorHasEspecialidadRepository, AsesorHasEspecialidadRepository>();
            services.AddTransient<IAsesorHasComentarioRepository, AsesorHasComentarioRepository>();
            services.AddTransient<IAsesorHasTurnoRepository, AsesorHasTurnoRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelpDents v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}