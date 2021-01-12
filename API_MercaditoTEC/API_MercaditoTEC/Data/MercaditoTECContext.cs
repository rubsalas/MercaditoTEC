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

        /* Rosado */
        public DbSet<Estudiante> Estudiante { get; set; }


        /*
         * Joints
         */

        /* Rosado */
        public DbSet<EstudianteJ> EstudianteJ { get; set; }
    }
}