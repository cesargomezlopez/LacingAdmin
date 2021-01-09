using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Models.ViewModels
{
    public class AlumnoViewModel
    {
        public List<Alumno> ListaAlumnos { get; set; }
        public Alumno Alumno { get; set; }
    }
}