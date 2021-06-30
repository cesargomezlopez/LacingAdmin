using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class ObservacionXHardware
    {
        public int IdObservacionXHardware { get; set; }
        public int IdHardware { get; set; }
        public string Tipo { get; set; }
        public string Observacion { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreSoftware { get; set; }
        public string VersionSoftware { get; set; }
        public string TipoSoftware { get; set; }
    }
}
