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

        /*
         * Metodo para iniciar la conexión a las bases de datos
         */
        private void InitializeStorage(IServiceCollection services)
        {
            //SQLServer
            string SQLServerConnectionString = Configuration.GetConnectionString("MercaditoTECConnection");
            services.AddDbContext<MercaditoTECContext>(options => options.UseSqlServer(SQLServerConnectionString));
        }

        /*
         * Metodo para ajustar los scopes de los Repositorios y su respectiva Interfaz
         */
        private void InitializeScope(IServiceCollection services)
        {
            //Persona
            services.AddScoped<IPersonaRepo, SqlPersonaRepo>();
            //Datic
            services.AddScoped<IDaticRepo, SqlDaticRepo>();
            //Carrera
            services.AddScoped<ICarreraRepo, SqlCarreraRepo>();
            //MetodoPago
            services.AddScoped<IMetodoPagoRepo, SqlMetodoPagoRepo>();
            //Categoria
            services.AddScoped<ICategoriaRepo, SqlCategoriaRepo>();
            //Provincia
            services.AddScoped<IProvinciaRepo, SqlProvinciaRepo>();
            //TasaCambio
            services.AddScoped<ITasaCambioRepo, SqlTasaCambioRepo>();
            //Estudiante
            services.AddScoped<IEstudianteRepo, SqlEstudianteRepo>();
            //Curso
            services.AddScoped<ICursoRepo, SqlCursoRepo>();
            //Canton
            services.AddScoped<ICantonRepo, SqlCantonRepo>();
            //Administrador
            services.AddScoped<IAdministradorRepo, SqlAdministradorRepo>();
            //Tutor
            services.AddScoped<ITutorRepo, SqlTutorRepo>();
            //Tutorado
            services.AddScoped<ITutoradoRepo, SqlTutoradoRepo>();
            //Vendedor
            services.AddScoped<IVendedorRepo, SqlVendedorRepo>();
            //Ubicacion
            services.AddScoped<IUbicacionRepo, SqlUbicacionRepo>();
            //Comprador
            services.AddScoped<ICompradorRepo, SqlCompradorRepo>();
            //CursoTutor
            services.AddScoped<ICursoTutorRepo, SqlCursoTutorRepo>();
            //Producto
            services.AddScoped<IProductoRepo, SqlProductoRepo>();
            //PracticaTutor
            services.AddScoped<IPracticaTutorRepo, SqlPracticaTutorRepo>();
            //CursoTutorado
            services.AddScoped<ICursoTutoradoRepo, SqlCursoTutoradoRepo>();
            //MetodopagoProducto
            services.AddScoped<IMetodoPagoProductoRepo, SqlMetodoPagoProductoRepo>();
            //UbicacionProducto
            services.AddScoped<IUbicacionProductoRepo, SqlUbicacionProductoRepo>();
            //ImagenProducto
            services.AddScoped<IImagenProductoRepo, SqlImagenProductoRepo>();
            //CompraProducto
            services.AddScoped<ICompraProductoRepo, SqlCompraProductoRepo>();
            //TemaPracticaTutor
            services.AddScoped<ITemaPracticaTutorRepo, SqlTemaPracticaTutorRepo>();
            //MetodoPagoPracticaTutor
            services.AddScoped<IMetodoPagoPracticaTutorRepo, SqlMetodoPagoPracticaTutorRepo>();


            //EstudianteJ
            services.AddScoped<IEstudianteJRepo, SqlEstudianteJRepo>();
            //CursoJ
            services.AddScoped<ICursoJRepo, SqlCursoJRepo>();
            //AdministradorJ
            services.AddScoped<IAdministradorJRepo, SqlAdministradorJRepo>();
            //TutorJ
            services.AddScoped<ITutorJRepo, SqlTutorJRepo>();
            //TutoradoJ
            services.AddScoped<ITutoradoJRepo, SqlTutoradoJRepo>();
            //VendedorJ
            services.AddScoped<IVendedorJRepo, SqlVendedorJRepo>();
            //UbicacionJ
            services.AddScoped<IUbicacionJRepo, SqlUbicacionJRepo>();
            //CompradorJ
            services.AddScoped<ICompradorJRepo, SqlCompradorJRepo>();
            //CursoTutorJ
            services.AddScoped<ICursoTutorJRepo, SqlCursoTutorJRepo>();
            //ProductoJ
            services.AddScoped<IProductoJRepo, SqlProductoJRepo>();
            //PracticaTutorJ
            services.AddScoped<IPracticaTutorJRepo, SqlPracticaTutorJRepo>();
            //CursoTutorado
            services.AddScoped<ICursoTutoradoJRepo, SqlCursoTutoradoJRepo>();
            //MetodopagoProductoJ
            services.AddScoped<IMetodoPagoProductoJRepo, SqlMetodoPagoProductoJRepo>();
            //UbicacionProductoJ
            services.AddScoped<IUbicacionProductoJRepo, SqlUbicacionProductoJRepo>();
            //CompraProductoRepo
            services.AddScoped<ICompraProductoJRepo, SqlCompraProductoJRepo>();
            //MetodoPagoPracticaTutorJ
            services.AddScoped<IMetodoPagoPracticaTutorJRepo, SqlMetodoPagoPracticaTutorJRepo>();
        }

        /*
         * Metodo para habilitar CORS
         */
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
