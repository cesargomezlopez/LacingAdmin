using LacingAdmin.IDataAccess;
using LacingAdmin.Model;
using LacingAdmin.Web.Common;
using LacingAdmin.Web.Controllers.Base;
using LacingAdmin.Web.Models.ViewModels;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacingAdmin.Web.Controllers
{
    public class InventarioController : BaseController
    {
        private readonly IHardwareDataAccess hardwareDataAccess;
        private readonly IFacultadDataAccess facultadDataAccess;
        private readonly ILaboratorioDataAccess laboratorioDataAccess;
        public InventarioController(IReporteDataAccess _reporteDataAccess, IDocenteDataAccess _docenteDataAccess,
            IHardwareDataAccess _hardwareDataAccess, IFacultadDataAccess _facultadDataAccess, ILaboratorioDataAccess _laboratorioDataAccess)
        {
            hardwareDataAccess = _hardwareDataAccess;
            facultadDataAccess = _facultadDataAccess;
            laboratorioDataAccess = _laboratorioDataAccess;
        }
        [HttpGet]
        public ActionResult Hardware()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();
                model.ListaFacultadesLaboratorio = facultadDataAccess.GetListaFacultades();
                model.ListaLaboratorios = laboratorioDataAccess.GetListaLaboratorios();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [AllowAnonymous]
        public ActionResult ListaReporteEquipoComputoPartial(string idLaboratorio)
        {
            EquipoComputoViewModel model = new EquipoComputoViewModel();
            model.ListaEquiposComputo = hardwareDataAccess.GetListaHardwareByLaboratorioAndTipo(int.Parse(idLaboratorio), "1");
            return PartialView(model);
        }

        [AllowAnonymous]
        public ActionResult ListaReporteEquipoGeneralPartial(string idLaboratorio)
        {
            EquipoComputoViewModel model = new EquipoComputoViewModel();
            model.ListaEquiposGeneral = hardwareDataAccess.GetListaHardwareByLaboratorioAndTipo(int.Parse(idLaboratorio), "0");
            return PartialView(model);
        }

        [AllowAnonymous]
        public ActionResult ReporteGeneralContent(string flgReporteEquipoComputo, string idLaboratorio)
        {
            EquipoComputoViewModel model = new EquipoComputoViewModel();

            if (flgReporteEquipoComputo == "1")
            {
                model.ListaEquiposComputo = hardwareDataAccess.GetListaHardwareByLaboratorioAndTipo(int.Parse(idLaboratorio), "1");
                return PartialView(model);
            }
            else
            {
                model.ListaEquiposGeneral = hardwareDataAccess.GetListaHardwareByLaboratorioAndTipo(int.Parse(idLaboratorio), "0");
                return PartialView(model);
            }
        }

        public ActionResult DescargarReporteInventario(string flgReporteEquipoComputo, string idLaboratorio)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                return new ActionAsPdf("ReporteGeneralContent", new { flgReporteEquipoComputo = flgReporteEquipoComputo, idLaboratorio = idLaboratorio }) { FileName = "ReporteInventarioEquipoComputoLacing.pdf" };
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
    }
}