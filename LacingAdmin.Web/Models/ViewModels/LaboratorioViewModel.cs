using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Models.ViewModels
{
    public class LaboratorioViewModel
    {
        public List<Laboratorio> ListaLaboratorios { get; set; }
        public Laboratorio laboratorio { get; set; }
        public List<Facultad> ListaFacultades { get; set; }
        public List<AdministradorXLaboratorio> ListaAdministradoresXLaboratorio { get; set; }
        public List<Administrador> ListaAdministradoresRestantes { get; set; }
        public Administrador AdministradorAdicional { get; set; }
    }
}