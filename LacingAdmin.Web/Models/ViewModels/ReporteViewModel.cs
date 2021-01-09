using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Models.ViewModels
{
    public class ReporteViewModel
    {
        public List<ReporteGeneral> ListaReporteGeneral { get; set; }
        public List<Docente> ListaDocentes { get; set; }
        public int FlgConsulta { get; set; }
    }
}