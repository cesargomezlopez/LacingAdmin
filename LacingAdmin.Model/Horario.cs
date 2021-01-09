using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.Model
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public int IdDocente { get; set; }
        public int IdLaboratorio { get; set; }
        public int IdSubgrupo { get; set; }
        public int Dia { get; set; }
        public String DiaNombre { get {
                string aux;
                switch (Dia)
                {
                    case 0:
                        aux = "Domingo";
                        break;
                    case 1:
                        aux = "Lunes";
                        break;
                    case 2:
                        aux = "Martes";
                        break;
                    case 3:
                        aux = "Miércoles";
                        break;
                    case 4:
                        aux = "Jueves";
                        break;
                    case 5:
                        aux = "Viernes";
                        break;
                    case 6:
                        aux = "Sábado";
                        break;
                    default:
                        aux = "";
                        break;
                }
                return aux; } set { } }
        public int Horas { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public DateTime? FechaRecuperacion { get; set; }
        public string TipoCiclo { get; set; }



        public string NombreDocente { get; set; }
        public string NombreLaboratorio { get; set; }
        public string NumeroSubgrupo { get; set; }
        public string TipoSubgrupo { get; set; }
        public int IdGrupo { get; set; }
        public string NumeroGrupo { get; set; }
        public int IdCurso { get; set; }
        public string CodigoCurso { get; set; }
        public string NombreCurso { get; set; }
        public string NumeroCiclo { get; set; }
        public string NumeroMalla { get; set; }
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public int IdFacultadLaboratorio { get; set; }
        public int IdFacultadCurso { get; set; }
        public string NombreFacultad { get; set; }
        public string Intervalo { get; set; }

        public int FlagAsistenciaPendiente { get; set; }
        public int MinutosHora { get; set; }
    }
}
