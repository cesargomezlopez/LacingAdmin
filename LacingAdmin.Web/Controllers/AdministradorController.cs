using LacingAdmin.IDataAccess;
using LacingAdmin.Model;
using LacingAdmin.Web.Common;
using LacingAdmin.Web.Controllers.Base;
using LacingAdmin.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacingAdmin.Web.Controllers
{
    public class AdministradorController : BaseController
    {
        private readonly IAdministradorDataAccess administradorDataAccess;
        public AdministradorController(IAdministradorDataAccess _administradorDataAccess)
        {
            administradorDataAccess = _administradorDataAccess;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                AdministradorViewModel model = new AdministradorViewModel();
                model.ListaAdministradores = administradorDataAccess.GetListaAdministradores();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        
        [HttpGet]
        public ActionResult ListaAdministradoresView()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                AdministradorViewModel model = new AdministradorViewModel();
                model.ListaAdministradores = administradorDataAccess.GetListaAdministradores();
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        [HttpGet]
        public ActionResult Crear()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Crear(Administrador administrador)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                administradorDataAccess.CreateAdministrador(administrador);
                return RedirectToAction("Index", "Administrador", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult Editar(string nombreUsuario)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                Administrador administrador = new Administrador();
                administrador = administradorDataAccess.GetAdministradorByNombreUsuario(nombreUsuario);
                ViewBag.IdAdministrador = administrador.IdAdministrador;
                ViewBag.NombreUsuario = administrador.NombreUsuario;
                ViewBag.Contrasena = administrador.Contraseña;
                return PartialView(administrador);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Editar(Administrador administrador)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                administradorDataAccess.UpdateAdministrador(administrador);
                return RedirectToAction("Index", "Administrador", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int idAdministrador)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                administradorDataAccess.DeleteAdministrador(idAdministrador);
                return RedirectToAction("Index", "Administrador", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public string ExisteNombreUsuario(string nombreUsuario)
        {
            Administrador administrador = new Administrador();
            administrador = administradorDataAccess.GetAdministradorByNombreUsuario(nombreUsuario);

            if (administrador.IdAdministrador > 0)
            {
                return "existe";
            }
            else
            {
                return "noexiste";
            }
        }
    }
}