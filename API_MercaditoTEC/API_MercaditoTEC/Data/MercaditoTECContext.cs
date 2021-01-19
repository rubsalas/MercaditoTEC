﻿using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using Microsoft.EntityFrameworkCore;

namespace API_MercaditoTEC.Data
{
    public class MercaditoTECContext : DbContext
    {
        public MercaditoTECContext(DbContextOptions<MercaditoTECContext> options) : base(options)
        {

        }

        /*
         * Tables
         */

        /* Morado */
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Datic> Datic { get; set; }
        public DbSet<MetodoPago> MetodoPago { get; set; }
        public DbSet<Categoria> Categoria { get; set; }

        /* Rosado */
        public DbSet<Estudiante> Estudiante { get; set; }

        /* Rojo */
        public DbSet<Vendedor> Vendedor { get; set; }

        /* Anaranjado */
        
        public DbSet<Producto> Producto { get; set; }

        /* Amarillo */
        public DbSet<MetodoPagoProducto> MetodoPagoProducto { get; set; }
        public DbSet<ImagenProducto> ImagenProducto { get; set; }


        /*
         * Joints
         */

        /* Rosado */
        public DbSet<EstudianteJ> EstudianteJ { get; set; }

        /* Rojo */
        public DbSet<VendedorJ> VendedorJ { get; set; }

        /* Anaranjado */
        
        public DbSet<ProductoJ> ProductoJ { get; set; }

        /* Amarillo */
        //public DbSet<MetodoPagoProductoJ> MetodoPagoProductoJ { get; set; }
    }
}
