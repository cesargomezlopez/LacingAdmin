using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class Hardware
    {
        public int IdHardware { get; set; }
        public int IdLaboratorio { get; set; }
        public string TipoEquipo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Serie { get; set; }
        public string Inventario { get; set; }
        public string Procesador { get; set; }
        public string Velocidad { get; set; }
        public string Ram { get; set; }
        public string DiscoDuro { get; set; }
        public string TarjetaVideo { get; set; }
        public string Usuario { get; set; }
        public string Observacion { get; set; }
        public string Estado { get; set; }
        public string FlgEquipoComputo { get; set; }
        public string NombreLaboratorio { get; set; }
        public string NombreFacultad { get; set; }
    }
}
