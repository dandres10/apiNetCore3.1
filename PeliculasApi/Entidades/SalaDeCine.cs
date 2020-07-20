﻿namespace PeliculasApi.Entidades
{
    using NetTopologySuite.Geometries;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SalaDeCine : IId
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Nombre { get; set; }

        public Point Ubicacion { get; set; }
        public List<PeliculasSalasDeCine> PeliculasSalasDeCines { get; set; }
    }
}