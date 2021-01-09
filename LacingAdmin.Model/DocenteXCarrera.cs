using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class DocenteXCarrera
    {
        public int IdDocenteXCarrera { get; set; }
        public int IdDocente { get; set; }
        public int IdCarrera { get; set; }
        public string NombreDocente { get; set; }
        public string NombreCarrera { get; set; }
        public string NombreFacultad { get; set; }
    }
}
