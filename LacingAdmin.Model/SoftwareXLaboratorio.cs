using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class SoftwareXLaboratorio
    {
        public int IdSoftwareXLaboratorio { get; set; }
        public int IdSoftware { get; set; }
        public string NombreSoftware { get; set; }
        public string VersionSoftware { get; set; }
        public string TipoSoftware { get; set; }


        public int IdLaboratorio { get; set; }
        public string NombreLaboratorio { get; set; }
        public int IdFacultad { get; set; }
        public string NombreFacultad { get; set; }
    }
}
