using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_MercaditoTEC.Data;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Llama a la función de conexion con la base de datos
            InitializeStorage(services);

            services.AddScoped<IPersonaRepo, SqlPersonaRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
    }
}
