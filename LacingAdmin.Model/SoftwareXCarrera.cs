using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class SoftwareXCarrera
    {
        public int IdSoftwareXCarrera { get; set; }
        public int IdSoftware { get; set; }
        public string NombreSoftware { get; set; }
        public string VersionSoftware { get; set; }
        public string TipoSoftware { get; set; }


        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public int IdFacultad { get; set; }
        public string NombreFacultad { get; set; }
    }
}
