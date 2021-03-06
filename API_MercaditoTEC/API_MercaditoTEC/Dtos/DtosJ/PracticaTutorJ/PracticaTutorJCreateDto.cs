﻿using API_MercaditoTEC.Data;
using API_MercaditoTEC.Models;
using API_MercaditoTEC.Models.ModelsJ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_MercaditoTEC.Dtos.DtosJ
{
    public class PracticaTutorJCreateDto
    {
        [Required]
        public int idCursoTutor { get; set; }
        [Required]
        [MaxLength(150)]
        public string nombre { get; set; }
        [Required]
        [MaxLength(500)]
        public string descripcion { get; set; }
        [Required]
        public int cantidadEjercicios { get; set; }
        [Required]
        [MaxLength(75)]
        public string dificultad { get; set; }
        [Required]
        public int precio { get; set; }
        [Required]
        [MaxLength(75)]
        public string pdfPractica { get; set; }
        [Required]
        [MaxLength(75)]
        public string pdfSolucion { get; set; }

        [Required]
        public IEnumerable<TemaPracticaTutor> temas { get; set; }
        [Required]
        public IEnumerable<MetodoPagoPracticaTutorJ> metodosPago { get; set; }
    }
}
