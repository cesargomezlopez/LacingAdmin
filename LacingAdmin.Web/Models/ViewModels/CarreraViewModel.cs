using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Models.ViewModels
{
    public class CarreraViewModel
    {
        public List<Carrera> ListaCarreras { get; set; }
        public Carrera carrera { get; set; }
        public List<Facultad> ListaFacultades { get; set; }
    }
}