using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Models.ViewModels
{
    public class HorarioViewModel
    {
        public Horario Horario { get; set; }
        public List<Horario> ListaHorarios { get; set; }


        public List<Facultad> ListaFacultadesLaboratorio { get; set; }
        public List<Laboratorio> ListaLaboratorios { get; set; }
        public List<Docente> ListaDocentes { get; set; }
        public List<Facultad> ListaFacultadesCurso { get; set; }
        public List<Carrera> ListaCarreras { get; set; }
        public List<Curso> ListaCursos { get; set; }
        public List<Grupo> ListaGrupos { get; set; }
        public List<Subgrupo> ListaSubgrupos { get; set; }

        public List<Dia> ListaDias { get {
                return 
                    new List<Dia> { new Dia { Nombre = "Lunes", Valor = 1 },
                                    new Dia { Nombre = "Martes", Valor = 2 },
                                    new Dia { Nombre = "Miércoles", Valor = 3 },
                                    new Dia { Nombre = "Jueves", Valor = 4 },
                                    new Dia { Nombre = "Viernes", Valor = 5 },
                                    new Dia { Nombre = "Sábado", Valor = 6 },
                                    new Dia { Nombre = "Domingo", Valor = 0 }
                    };
            } set { } }

        public List<Intervalo> ListaIntervalos { get {
                return new List<Intervalo> {
                    new Intervalo{ Nombre = "30 min", Valor = 30},
                    new Intervalo{ Nombre = "35 min", Valor = 35},
                    new Intervalo{ Nombre = "40 min", Valor = 40},
                    new Intervalo{ Nombre = "45 min", Valor = 45},
                    new Intervalo{ Nombre = "50 min", Valor = 50},
                    new Intervalo{ Nombre = "55 min", Valor = 55},
                    new Intervalo{ Nombre = "60 min", Valor = 60}
                };
            } set { } }
    }

    public class Dia {
        public string Nombre { get; set; }
        public int Valor { get; set; }
    }

    public class Intervalo {
        public string Nombre { get; set; }
        public int Valor { get; set; }
    }
}