using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Models.ViewModels
{
    public class EquipoComputoViewModel
    {
        public int contador { get; set; }
        public string lastUser { get; set; }
        public List<Hardware> ListaEquiposComputo { get; set; }
        public List<Hardware> ListaEquiposComputoGetByUsuario { get; set; }


        public string usuario { get; set; }
        public int idLaboratorio { get; set; }
        public string idLaboratorioString { get; set; }
        public Hardware equipoComputoCpu { get; set; }
        public Hardware equipoComputoMonitor { get; set; }
        public Hardware equipoComputoTeclado { get; set; }
        public Hardware equipoComputoMouse { get; set; }


        public List<Facultad> ListaFacultadesLaboratorio { get; set; }
        public List<Laboratorio> ListaLaboratorios { get; set; }


        public Hardware hardware { get; set; }
        public List<Hardware> ListaEquiposGeneral { get; set; }
    }
}