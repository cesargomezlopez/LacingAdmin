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
    public class CarreraController : BaseController
    {
        private readonly ICarreraDataAccess carreraDataAccess;
        private readonly IFacultadDataAccess facultadDataAccess;
        public CarreraController(ICarreraDataAccess _carreraDataAccessDataAccess, IFacultadDataAccess _facultadDataAccess)
        {
            carreraDataAccess = _carreraDataAccessDataAccess;
            facultadDataAccess = _facultadDataAccess;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                CarreraViewModel model = new CarreraViewModel();
                model.ListaCarreras = carreraDataAccess.GetListaCarreras();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        public ActionResult ListaCarrerasView()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                CarreraViewModel model = new CarreraViewModel();
                model.ListaCarreras = carreraDataAccess.GetListaCarreras();
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
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                CarreraViewModel model = new CarreraViewModel();
                model.ListaFacultades = facultadDataAccess.GetListaFacultades();
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Crear(CarreraViewModel model)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                carreraDataAccess.CreateCarrera(model.carrera);
                return RedirectToAction("Index", "Carrera", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult Editar(int idCarrera)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                CarreraViewModel model = new CarreraViewModel();
                model.ListaFacultades = facultadDataAccess.GetListaFacultades();
                model.carrera = carreraDataAccess.GetCarreraById(idCarrera);
                ViewBag.IdCarrera = model.carrera.IdCarrera;
                ViewBag.NombreCarrera = model.carrera.NombreCarrera;
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Editar(CarreraViewModel model)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                carreraDataAccess.UpdateCarrera(model.carrera);
                return RedirectToAction("Index", "Carrera", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int idCarrera)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                carreraDataAccess.DeleteCarrera(idCarrera);
                return RedirectToAction("Index", "Carrera", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public string ExisteNombreCarrera(string nombreCarrera)
        {
            Carrera carrera = new Carrera();
            carrera = carreraDataAccess.GetCarreraByNombreCarrera(nombreCarrera);

            if (carrera.IdCarrera > 0)
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