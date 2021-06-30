using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Models.ViewModels
{
    public class ObservacionXHardwareViewModel
    {
        public string TipoObservacion { get; set; }
        public ObservacionXHardware ObservacionXHardware { get; set; }

        public List<ObservacionXHardware> ListaObservacionesXHardware { get; set; }
    }
}