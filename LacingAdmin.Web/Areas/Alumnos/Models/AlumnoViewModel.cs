using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LacingAdmin.Model;

namespace LacingAdmin.Web.Areas.Alumnos.Models
{
    public class AlumnoViewModel
    {
        public LacingAdmin.Model.Alumno Alumno { get; set; }

        public string MensajeValidacion { get; set; }

        public List<Horario> ListaHorariosAlumno { get; set; }
        public List<Asistencia> ListaAsistenciasAlumno { get; set; }

        public int numAux { get; set; }
    }
}