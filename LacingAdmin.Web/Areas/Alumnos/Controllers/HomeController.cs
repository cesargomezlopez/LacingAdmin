using LacingAdmin.IDataAccess;
using LacingAdmin.Model;
using LacingAdmin.Web.Areas.Alumnos.Models;
using LacingAdmin.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacingAdmin.Web.Areas.Alumnos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlumnoDataAccess alumnoDataAccess;
        private readonly IHorarioDataAccess horarioDataAccess;
        private readonly IAsistenciaDataAccess asistenciaDataAccess;
        public HomeController(IAlumnoDataAccess _alumnoDataAccess, IHorarioDataAccess _horarioDataAccess, 
            IAsistenciaDataAccess _asistenciaDataAccess)
        {
            alumnoDataAccess = _alumnoDataAccess;
            horarioDataAccess = _horarioDataAccess;
            asistenciaDataAccess = _asistenciaDataAccess;
        }
        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetAlumnoID() > 0)
            {
                string numeroCiclo = "0";
                DateTime date = DateTime.Now;
                int month = date.Month;
                int year = date.Year;
                numeroCiclo = month > 2 && month < 8 ? "I" : "II";
                if (month < 3)
                {
                    numeroCiclo = "0";
                }
                this.ViewBag.ciclo = numeroCiclo;
                this.ViewBag.year = year;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Alumnos"});
            }
        }

        [HttpGet]
        public ActionResult ListaHorariosAlumnoPartial()
        {
            if (SecurityHelper.GetAlumnoID() > 0)
            {
                AlumnoViewModel model = new AlumnoViewModel();
                model.ListaHorariosAlumno = alumnoDataAccess.GetListaHorariosAlumno(SecurityHelper.GetAlumnoID());

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Alumnos" });
            }
        }

        [HttpGet]
        public ActionResult ListaAsistenciasAlumnoPartial()
        {
            if (SecurityHelper.GetAlumnoID() > 0)
            {
                AlumnoViewModel model = new AlumnoViewModel();
                model.ListaAsistenciasAlumno = alumnoDataAccess.GetListaAsistenciasAlumno(SecurityHelper.GetAlumnoID());

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Alumnos" });
            }
        }

        [HttpPost]
        public ActionResult MarcarAsistencia(int idHorario)
        {
            if (SecurityHelper.GetAlumnoID() > 0)
            {
                Horario horario = new Horario();
                horario = horarioDataAccess.GetHorarioById(idHorario);

                Asistencia asistencia = new Asistencia();
                asistencia.IdHorario = horario.IdHorario;
                asistencia.IdDocente = horario.IdDocente;
                asistencia.NombreDocente = horario.NombreDocente;
                asistencia.IdLaboratorio = horario.IdLaboratorio;
                asistencia.IdFacultad = horario.IdFacultadLaboratorio;
                asistencia.NombreLaboratorio = horario.NombreLaboratorio;
                asistencia.IdSubgrupo = horario.IdSubgrupo;
                asistencia.NumeroSubgrupo = horario.NumeroSubgrupo;
                asistencia.TipoSubgrupo = horario.TipoSubgrupo;
                asistencia.IdGrupo = horario.IdGrupo;
                asistencia.NumeroGrupo = horario.NumeroGrupo;
                asistencia.IdCurso = horario.IdCurso;
                asistencia.CodigoCurso = horario.CodigoCurso;
                asistencia.NombreCurso = horario.NombreCurso;
                asistencia.NumeroCiclo = horario.NumeroCiclo;
                asistencia.NumeroMalla = horario.NumeroMalla;
                asistencia.IdCarrera = horario.IdCarrera;
                asistencia.NombreCarrera = horario.NombreCarrera;
                asistencia.NombreFacultad = horario.NombreFacultad;
                asistencia.Dia = horario.Dia;
                asistencia.HoraInicio = horario.HoraInicio;
                asistencia.HoraFin = horario.HoraFin;
                asistencia.FechaRecuperacion = horario.FechaRecuperacion;
                asistencia.IdAlumno = SecurityHelper.GetAlumnoID();
                asistencia.NombreUsuarioAlumno = SecurityHelper.GetAlumnoNombreUsuario();
                asistencia.NombreAlumno = SecurityHelper.GetAlumnoNombres();
                asistencia.TipoAsistencia = 3; //tipoAsistencia 1=Administrador, 2=Docente, 3=Alumno
                asistencia.CantidadHoras = horario.Horas;
                asistencia.MinutosHora = horario.MinutosHora;

                asistenciaDataAccess.CreateAsistencia(asistencia);

                return RedirectToAction("Index", "Home", new { Area = "Alumnos" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "Alumnos" });
            }
        }
    }
}