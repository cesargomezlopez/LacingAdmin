using LacingAdmin.IDataAccess;
using LacingAdmin.Web.Areas.Docentes.Models;
using LacingAdmin.Web.Common;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacingAdmin.Web.Areas.Docentes.Controllers
{
    public class AsistenciaController : Controller
    {
        private readonly IDocenteDataAccess docenteDataAccess;
        private readonly IHorarioDataAccess horarioDataAccess;
        private string dateInicio;
        private string dateFin;
        public AsistenciaController(IDocenteDataAccess _docenteDataAccess, IHorarioDataAccess _horarioDataAccess)
        {
            docenteDataAccess = _docenteDataAccess;
            horarioDataAccess = _horarioDataAccess;
            dateInicio = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day - (DateTime.Now.Day - 1)).ToString("dd/MM/yyyy");
            dateFin = DateTime.Now.ToString("dd/MM/yyyy");
        }
        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetDocenteID() > 0)
            {
                DocenteViewModel model = new DocenteViewModel();
                model.ListaCursosDocente = docenteDataAccess.GetListaCursosDocente(SecurityHelper.GetDocenteID());
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Docentes" });
            }
        }

        [HttpGet]
        public ActionResult ListaAsistenciasPartial(int? idCurso)
        {
            if (SecurityHelper.GetDocenteID() > 0)
            {
                DocenteViewModel model = new DocenteViewModel();
                model.ListaAsistenciasDocente = docenteDataAccess.GetListaAsistenciasDocente(SecurityHelper.GetDocenteID(), idCurso);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Docentes" });
            }
        }

        [HttpGet]
        public ActionResult Alumnos(int? idSubgrupo)
        {
            if (SecurityHelper.GetDocenteID() > 0)
            {
                DocenteViewModel model = new DocenteViewModel();
                ViewBag.IdSubgrupo = idSubgrupo;
                ViewBag.dateInicio = this.dateInicio;
                ViewBag.dateFin = this.dateFin;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Docentes" });
            }
        }

        [HttpGet]
        public ActionResult ListaAsistenciasAlumnosxCursoPartial(int? idSubgrupo, string fechaInicio, string fechaFin)
        {
            if (SecurityHelper.GetDocenteID() > 0)
            {
                DocenteViewModel model = new DocenteViewModel();
                model.ListaAsistenciasAlumnos = docenteDataAccess.GetListaAsistenciasAlumnosByIdSubgrupo(idSubgrupo, Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin));
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Docentes" });
            }
        }

        [AllowAnonymous]
        public ActionResult ReporteAsistenciasAlumnosContent(int? idSubgrupo, string fechaInicio, string fechaFin)
        {
            DocenteViewModel model = new DocenteViewModel();
            model.ListaAsistenciasAlumnos = docenteDataAccess.GetListaAsistenciasAlumnosByIdSubgrupo(idSubgrupo, Convert.ToDateTime(fechaInicio), Convert.ToDateTime(fechaFin));
            //model.Horario = horarioDataAccess.
            return PartialView(model);
        }

        public ActionResult DescargarReporteAsistenciasAlumnos(int? idSubgrupo, string fechaInicio, string fechaFin)
        {
            if (SecurityHelper.GetDocenteID() > 0)
            {
                return new ActionAsPdf("ReporteAsistenciasAlumnosContent", new { idSubgrupo = idSubgrupo, fechaInicio = fechaInicio, fechaFin = fechaFin }) { FileName = "ReporteAsistenciasAlumnosLacing.pdf" };
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
    }
}