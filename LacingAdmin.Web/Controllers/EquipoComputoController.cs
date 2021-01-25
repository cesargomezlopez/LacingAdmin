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
    public class EquipoComputoController : BaseController
    {
        private readonly IHardwareDataAccess hardwareDataAccess;
        public EquipoComputoController(IHardwareDataAccess _hardwareDataAccess)
        {
            hardwareDataAccess = _hardwareDataAccess;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        public ActionResult ListaEquiposComputoView()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();
                model.ListaEquiposComputo = hardwareDataAccess.GetListaEquiposComputo();    
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        //[HttpGet]
        //public ActionResult Crear()
        //{
        //    if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
        //    {
        //        return PartialView();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Login", new { Area = "" });
        //    }
        //}

        //[HttpPost]
        //public ActionResult Crear(Facultad facultad)
        //{
        //    if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
        //    {
        //        facultadDataAccess.CreateFacultad(facultad);
        //        return RedirectToAction("Index", "Facultad", new { Area = "" });
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Login", new { Area = "" });
        //    }
        //}

        //[HttpGet]
        //public ActionResult Editar(int idFacultad)
        //{
        //    if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
        //    {
        //        ViewBag.facultad = facultadDataAccess.GetFacultadById(idFacultad);
        //        return PartialView();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Login", new { Area = "" });
        //    }
        //}

        //[HttpPost]
        //public ActionResult Editar(Facultad facultad)
        //{
        //    if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
        //    {
        //        facultadDataAccess.UpdateFacultad(facultad);
        //        return RedirectToAction("Index", "Facultad", new { Area = "" });
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Login", new { Area = "" });
        //    }
        //}

        //[HttpPost]
        //public ActionResult Eliminar(int idFacultad)
        //{
        //    if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
        //    {
        //        facultadDataAccess.DeleteFacultad(idFacultad);
        //        return RedirectToAction("Index", "Facultad", new { Area = "" });
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Login", new { Area = "" });
        //    }
        //}

        //[HttpGet]
        //public string ExisteNombreFacultad(string nombreFacultad)
        //{
        //    Facultad facultad = new Facultad();
        //    facultad = facultadDataAccess.GetFacultadByNombreFacultad(nombreFacultad);

        //    if (facultad.IdFacultad > 0)
        //    {
        //        return "existe";
        //    }
        //    else
        //    {
        //        return "noexiste";
        //    }
        //}
    }
}