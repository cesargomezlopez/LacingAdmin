using LacingAdmin.IDataAccess;
using LacingAdmin.Model;
using LacingAdmin.Web.Areas.Docentes.Models;
using LacingAdmin.Web.Common;
using LacingAdmin.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacingAdmin.Web.Areas.Docentes.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDocenteDataAccess docenteDataAccess;
        private readonly IHorarioDataAccess horarioDataAccess;
        private readonly IAsistenciaDataAccess asistenciaDataAccess;

        public HomeController(IDocenteDataAccess _docenteDataAccess, IHorarioDataAccess _horarioDataAccess
            , IAsistenciaDataAccess _asistenciaDataAccess)
        {
            docenteDataAccess = _docenteDataAccess;
            horarioDataAccess = _horarioDataAccess;
            asistenciaDataAccess = _asistenciaDataAccess;
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetDocenteID() > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Docentes" });
            }
        }

        [HttpGet]
        public ActionResult ListaHorariosDocentePartial()
        {
            if (SecurityHelper.GetDocenteID() > 0)
            {
                DocenteViewModel model = new DocenteViewModel();
                model.ListaHorariosDocente = docenteDataAccess.GetListaHorariosDocente(SecurityHelper.GetDocenteID());
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Docentes" });
            }
        }

        [HttpPost]
        public ActionResult MarcarAsistencia(int idHorario)
        {
            if (SecurityHelper.GetDocenteID() > 0)
            {
                Horario horario = new Horario();
                horario = horarioDataAccess.GetHorarioById(idHorario);

                Asistencia asistencia = new Asistencia();
                asistencia.IdHorario = horario.IdHorario;
                asistencia.IdDocente = horario.IdDocente;
                asistencia.NombreDocente = horario.NombreDocente;
                asistencia.IdLaboratorio= horario.IdLaboratorio;
                asistencia.IdFacultad= horario.IdFacultadLaboratorio;
                asistencia.NombreLaboratorio= horario.NombreLaboratorio;
                asistencia.IdSubgrupo= horario.IdSubgrupo;
                asistencia.NumeroSubgrupo= horario.NumeroSubgrupo;
                asistencia.TipoSubgrupo= horario.TipoSubgrupo;
                asistencia.IdGrupo= horario.IdGrupo;
                asistencia.NumeroGrupo= horario.NumeroGrupo;
                asistencia.IdCurso= horario.IdCurso;
                asistencia.CodigoCurso= horario.CodigoCurso;
                asistencia.NombreCurso= horario.NombreCurso;
                asistencia.NumeroCiclo= horario.NumeroCiclo;
                asistencia.NumeroMalla= horario.NumeroMalla;
                asistencia.IdCarrera= horario.IdCarrera;
                asistencia.NombreCarrera= horario.NombreCarrera;
                asistencia.NombreFacultad= horario.NombreFacultad;
                asistencia.Dia= horario.Dia;
                asistencia.HoraInicio= horario.HoraInicio;
                asistencia.HoraFin= horario.HoraFin;
                asistencia.FechaRecuperacion= horario.FechaRecuperacion;
                asistencia.NombreUsuarioDocente = SecurityHelper.GetDocenteNombreUsuario();
                asistencia.TipoAsistencia = 2; //tipoAsistencia 1=Administrador, 2=Docente, 3=Alumno
                asistencia.CantidadHoras = horario.Horas;
                asistencia.MinutosHora = horario.MinutosHora;

                asistenciaDataAccess.CreateAsistencia(asistencia);

                return RedirectToAction("Index", "Home", new { Area = "Docentes"});
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Docentes" });
            }
        }
    }
}