using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class AdministradorXLaboratorio
    {
        public int IdAdministradorXLaboratorio { get; set; }
        public int IdAdministrador { get; set; }
        public int IdLaboratorio { get; set; }
        public string NombresAdministrador { get; set; }
        public string NombreLaboratorio { get; set; }
    }
}
