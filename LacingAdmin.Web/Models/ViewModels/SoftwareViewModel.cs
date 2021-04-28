using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Models.ViewModels
{
    public class SoftwareViewModel
    {
        public int contador { get; set; }
        public List<Software> ListaSoftware { get; set; }
        public Software Software { get; set; }


        public int idLaboratorio { get; set; }
        public List<Facultad> ListaFacultadesLaboratorio { get; set; }
        public List<Laboratorio> ListaLaboratorios { get; set; }

        // Create - Edit Form
        public List<Facultad> ListaFacultadesLaboratorioForm { get; set; }
        public List<Laboratorio> ListaLaboratoriosForm { get; set; }
        public List<Carrera> ListaCarrerasForm { get; set; }
        public string ListaStringLaboratoriosForm { get; set; }
        public string ListaStringCarrerasForm { get; set; }
    }
}