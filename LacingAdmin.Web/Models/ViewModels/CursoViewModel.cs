using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Models.ViewModels
{
    public class CursoViewModel
    {
        public Curso Curso { get; set; }
        public List<Curso> ListaCursos { get; set; }
        public List<Carrera> ListaCarreras { get; set; }

        public Grupo Grupo { get; set; }
        public List<Grupo> ListaGrupos { get; set; }

        public Subgrupo Subgrupo { get; set; }
        public List<Subgrupo> ListaSubgrupos { get; set; }
    }
}