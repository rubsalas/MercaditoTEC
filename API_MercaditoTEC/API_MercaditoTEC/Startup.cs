using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_MercaditoTEC.Data;
using API_MercaditoTEC.Data.DataJ;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace API_MercaditoTEC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Llama a la función de conexion con la base de datos
            InitializeStorage(services);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Llama a la función para ajustar los scopes
            InitializeScope(services);

            //Llama a la funcion para habilitar CORS
            EnableCORS(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) 
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("EnableCORS");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        //Metodo para iniciar la conección a las bases de datos
        private void InitializeStorage(IServiceCollection services)
        {
            //SQLServer
            string SQLServerConnectionString = Configuration.GetConnectionString("MercaditoTECConnection");
            services.AddDbContext<MercaditoTECContext>(options => options.UseSqlServer(SQLServerConnectionString));
        }

        
        //Metodo para ajustar los scopes de los Repositorios y su respectiva Interfaz
        private void InitializeScope(IServiceCollection services)
        {
            //Persona
            services.AddScoped<IPersonaRepo, SqlPersonaRepo>();
            //Datic
            services.AddScoped<IDaticRepo, SqlDaticRepo>();
            //Categoria
            services.AddScoped<ICategoriaRepo, SqlCategoriaRepo>();
            //Estudiante
            services.AddScoped<IEstudianteRepo, SqlEstudianteRepo>();

            //EstudianteJ
            services.AddScoped<IEstudianteJRepo, SqlEstudianteJRepo>();
        }


        //Metodo para habilitar CORS
        private void EnableCORS(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });
        }

    }
}
