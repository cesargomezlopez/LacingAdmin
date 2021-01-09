using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class ReporteGeneral
    {
        public string Fecha { get; set; }
        public string Laboratorio { get; set; }
        public string Docente { get; set; }
        public string Curso { get; set; }
        public string Carrera { get; set; }
        public string HoraInicio { get; set; }
        public string HoraIngreso { get; set; }
        public string HoraFin { get; set; }
        public string HoraSalida { get; set; }
        public string Estado { get; set; }
        public string Observacion { get; set; }
        public string Tipo { get; set; }
        public int DiferenciaEntrada { get; set; }
    }
}
