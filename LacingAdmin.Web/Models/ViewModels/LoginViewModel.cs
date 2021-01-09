using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LacingAdmin.Web.Models.ViewModels
{
    public class LoginViewModel
    {
        public Administrador Administrador { get; set; }
        public string MensajeValidacion { get; set; }
    }
}