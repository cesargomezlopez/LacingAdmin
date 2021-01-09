using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class Grupo
    {
        public int IdGrupo { get; set; }
        public int IdCurso { get; set; }
        public string NumeroGrupo { get; set; }
        public int CantidadSubgrupos { get; set; }
    }
}
