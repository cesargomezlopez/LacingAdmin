using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Models.ViewModels
{
    public class DocenteViewModel
    {
        public List<Docente> ListaDocentes { get; set; }
        public Docente Docente { get; set; }
        public List<DocenteXCarrera> ListaDocentesXCarrera { get; set; }
        public List<Facultad> ListaFacultadesRestantes { get; set; }
        public List<Carrera> ListaCarrerasXFacultadRestantes { get; set; }
    }
}