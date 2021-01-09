using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class Administrador
    {
        public int IdAdministrador { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombres { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
        public string NombreCompleto { get; set; }

        public string NombreEstado { get; set; }
    }
}
