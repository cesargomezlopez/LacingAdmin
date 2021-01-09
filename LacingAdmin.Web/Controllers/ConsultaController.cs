using LacingAdmin.IDataAccess;
using LacingAdmin.Web.Common;
using LacingAdmin.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacingAdmin.Web.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly IConsultaDataAccess consultaDataAccess;
        private readonly IDocenteDataAccess docenteDataAccess;
        private readonly ICarreraDataAccess carreraDataAccess;
        private readonly IFacultadDataAccess facultadDataAccess;
        private readonly ICursoDataAccess cursoDataAccess;
        private readonly ILaboratorioDataAccess laboratorioDataAccess;
        public ConsultaController(IConsultaDataAccess _consultaDataAccess,
                                    IDocenteDataAccess _docenteDataAccess,
                                    ICarreraDataAccess _carreraDataAccess, 
                                    IFacultadDataAccess _facultadDataAccess,
                                    ICursoDataAccess _cursoDataAccess,
                                    ILaboratorioDataAccess _laboratorioDataAccess)
        {
            consultaDataAccess = _consultaDataAccess;
            docenteDataAccess = _docenteDataAccess;
            carreraDataAccess = _carreraDataAccess;
            facultadDataAccess = _facultadDataAccess;
            cursoDataAccess = _cursoDataAccess;
            laboratorioDataAccess = _laboratorioDataAccess;
        }
        public ActionResult Index()
        {
            if (SecurityHelper.GetAdministradorID() > 0)
            {
                ConsultaViewModel model = new ConsultaViewModel();
                model.ListaDocentes = docenteDataAccess.GetListaDocentes();
                model.ListaFacultades = facultadDataAccess.GetListaFacultades();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        public ActionResult ConsultaXDocentePartial(int idDocente)
        {
            if (SecurityHelper.GetAdministradorID() > 0)
            {
                ConsultaViewModel model = new ConsultaViewModel();
                model.ListaHorariosConsulta = consultaDataAccess.GetListaHorariosXDocente(idDocente);
                return PartialView("ConsultaPartial", model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        public ActionResult ConsultaXCursoPartial(int idCurso)
        {
            if (SecurityHelper.GetAdministradorID() > 0)
            {
                ConsultaViewModel model = new ConsultaViewModel();
                model.ListaHorariosConsulta = consultaDataAccess.GetListaHorariosXCurso(idCurso);
                return PartialView("ConsultaPartial", model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        public ActionResult ConsultaXLaboratorioPartial(int idLaboratorio)
        {
            if (SecurityHelper.GetAdministradorID() > 0)
            {
                ConsultaViewModel model = new ConsultaViewModel();
                model.ListaHorariosConsulta = consultaDataAccess.GetListaHorariosXLaboratorio(idLaboratorio);
                return PartialView("ConsultaPartial", model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        public PartialViewResult ConsultaPartial(ConsultaViewModel model)
        {
            return PartialView(model);
        }
        public ActionResult ComboLaboratoriosPartial(int? idFacultad)
        {
            if (SecurityHelper.GetAdministradorID() > 0)
            {
                ConsultaViewModel model = new ConsultaViewModel();
                model.ListaLaboratorios = laboratorioDataAccess.GetListaLaboratoriosByIdFacultad(idFacultad);
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        public ActionResult ComboCarrerasCursoPartial(int? idFacultad)
        {
            if (SecurityHelper.GetAdministradorID() > 0)
            {
                ConsultaViewModel model = new ConsultaViewModel();
                model.ListaCarreras = carreraDataAccess.GetListaCarrerasByIdFacultad(idFacultad);
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        public ActionResult ComboCursosPartial(int? idCarrera)
        {
            if (SecurityHelper.GetAdministradorID() > 0)
            {
                ConsultaViewModel model = new ConsultaViewModel();
                model.ListaCursos = cursoDataAccess.GetListaCursosByIdCarrera(idCarrera);
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
    }
}