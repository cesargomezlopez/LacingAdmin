using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class Laboratorio
    {
        public int IdLaboratorio { get; set; }
        public int IdFacultad { get; set; }
        public string NombreLaboratorio { get; set; }
        public string Estado { get; set; }

        public string NombreFacultad { get; set; }
        public string NombreEstado { get; set; }
        public int CantidadAdministradores { get; set; }
    }
}
