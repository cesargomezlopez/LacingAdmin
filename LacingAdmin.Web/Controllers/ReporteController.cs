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
    public class ReporteController : BaseController
    {
        private readonly IReporteDataAccess reporteDataAccess;
        private readonly IDocenteDataAccess docenteDataAccess;
        private string dateInicio;
        private string dateFin;
        public ReporteController(IReporteDataAccess _reporteDataAccess, IDocenteDataAccess _docenteDataAccess)
        {
            reporteDataAccess = _reporteDataAccess;
            docenteDataAccess =_docenteDataAccess;
            dateInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - (DateTime.Now.Day - 1)).ToString("dd/MM/yyyy");
            dateFin = DateTime.Now.ToString("dd/MM/yyyy");
        }
        [HttpGet]
        public ActionResult General()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                ReporteViewModel model = new ReporteViewModel();
                ViewBag.dateInicio = this.dateInicio;
                ViewBag.dateFin = this.dateFin;
                model.FlgConsulta = 0;
                model.ListaDocentes = docenteDataAccess.GetListaDocentes();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [AllowAnonymous]
        public ActionResult ListaReporteGeneralPartial(string fechaInicio, string fechaFin, int? idDocente)
        {
            //string fi = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            //            .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
            //string ff = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            //            .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);

            ReporteViewModel model = new ReporteViewModel();
            model.ListaReporteGeneral = reporteDataAccess.GetReporteGeneral(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin), idDocente);
            return PartialView(model);
        }

        [AllowAnonymous]
        public ActionResult ReporteGeneralContent(string fechaInicio, string fechaFin, int? idDocente)
        {
            ReporteViewModel model = new ReporteViewModel();
            model.ListaReporteGeneral = reporteDataAccess.GetReporteGeneral(Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin), idDocente);
            return PartialView(model);
        }

        public ActionResult DescargarReporteGeneral(string fechaInicio, string fechaFin, int? idDocente)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                return new ActionAsPdf("ReporteGeneralContent", new { fechaInicio = fechaInicio, fechaFin = fechaFin, idDocente = idDocente }) { FileName = "ReporteLacing.pdf" };
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
    }
}