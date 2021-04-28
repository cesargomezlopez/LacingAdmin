using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class Software
    {
        public int IdSoftware { get; set; }
        public string Nombre { get; set; }
        public string Version { get; set; }
        public string Tipo { get; set; }


        public int IdFacultad { get; set; }
        public string NombreFacultad { get; set; }

        public List<SoftwareXLaboratorio> ListaSoftwareXLaboratorio { get; set; }
        public List<Laboratorio> ListaLaboratorios { get; set; }
        public List<SoftwareXCarrera> ListaSoftwareXCarrera { get; set; }
        public List<Carrera> ListaCarreras { get; set; }

        public string LaboratoriosStringList { get; set; }
        public string CarrerasStringList { get; set; }
    }
}
