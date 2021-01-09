using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public int IdCarrera { get; set; }
        public string CodigoCurso { get; set; }
        public string NumeroMalla { get; set; }
        public string NumeroCiclo { get; set; }
        public string NombreCurso { get; set; }

        public string NombreCarrera { get; set; }
    }
}
