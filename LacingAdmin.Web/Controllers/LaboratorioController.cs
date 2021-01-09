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
    public class LaboratorioController : BaseController
    {
        private readonly ILaboratorioDataAccess laboratorioDataAccess;
        private readonly IFacultadDataAccess facultadDataAccess;
        private readonly IAdministradorXLaboratorioDataAccess administradorXLaboratorioDataAccess;
        public LaboratorioController(ILaboratorioDataAccess _laboratorioDataAccess, IFacultadDataAccess _facultadDataAccess,
                                        IAdministradorXLaboratorioDataAccess _administradorXLaboratorioDataAccess)
        {
            laboratorioDataAccess = _laboratorioDataAccess;
            facultadDataAccess = _facultadDataAccess;
            administradorXLaboratorioDataAccess = _administradorXLaboratorioDataAccess;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                LaboratorioViewModel model = new LaboratorioViewModel();
                model.ListaLaboratorios = laboratorioDataAccess.GetListaLaboratorios();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        
        [HttpGet]
        public ActionResult ListaLaboratoriosView()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                LaboratorioViewModel model = new LaboratorioViewModel();
                model.ListaLaboratorios = laboratorioDataAccess.GetListaLaboratorios();
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult AdministradoresView(int idLaboratorio)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                LaboratorioViewModel model = new LaboratorioViewModel();
                model.laboratorio = new Laboratorio();
                model.laboratorio.IdLaboratorio = idLaboratorio;
                model.ListaAdministradoresXLaboratorio = laboratorioDataAccess.GetListaAdministradoresByIdLaboratorio(idLaboratorio);
                model.ListaAdministradoresRestantes = laboratorioDataAccess.GetListaAdministradoresRestantes(idLaboratorio);
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public void AgregarAdministradorLaboratorio(int idAdministrador, int idLaboratorio)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                administradorXLaboratorioDataAccess.CreateAdministradorLaboratorio(idAdministrador, idLaboratorio);
            }
        }

        [HttpPost]
        public void EliminarAdministradorLaboratorio(int idAdministradorLaboratorio)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                administradorXLaboratorioDataAccess.DeleteAdministradorLaboratorio(idAdministradorLaboratorio);
            }
        }

        [HttpGet]
        public ActionResult Crear()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                ViewBag.ListaFacultades = facultadDataAccess.GetListaFacultades();
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Crear(Laboratorio laboratorio)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                laboratorioDataAccess.CreateLaboratorio(laboratorio);
                return RedirectToAction("Index", "Laboratorio", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult Editar(int idLaboratorio)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                ViewBag.ListaFacultades = facultadDataAccess.GetListaFacultades();
                ViewBag.laboratorio = laboratorioDataAccess.GetLaboratorioById(idLaboratorio);
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Editar(Laboratorio laboratorio)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                laboratorioDataAccess.UpdateLaboratorio(laboratorio);
                return RedirectToAction("Index", "Laboratorio", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int idLaboratorio)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                laboratorioDataAccess.DeleteLaboratorio(idLaboratorio);
                return RedirectToAction("Index", "Laboratorio", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public string ExisteNombreLaboratorio(string nombreLaboratorio)
        {
            Laboratorio laboratorio = new Laboratorio();
            laboratorio = laboratorioDataAccess.GetLaboratorioByNombreLaboratorio(nombreLaboratorio);

            if (laboratorio.IdLaboratorio > 0)
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