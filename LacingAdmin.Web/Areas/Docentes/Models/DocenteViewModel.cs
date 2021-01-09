using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Areas.Docentes.Models
{
    public class DocenteViewModel
    {
        public LacingAdmin.Model.Docente Docente { get; set; }

        public string MensajeValidacion { get; set; }

        public List<LacingAdmin.Model.Horario> ListaHorariosDocente { get; set; }
        public List<Asistencia> ListaAsistenciasDocente { get; set; }
        public List<Curso> ListaCursosDocente { get; set; }
        public List<Asistencia> ListaAsistenciasAlumnos { get; set; }
        public Horario Horario { get; set; }
    }
}