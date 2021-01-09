using LacingAdmin.IDataAccess;
using LacingAdmin.Model;
using LacingAdmin.Web.Common;
using LacingAdmin.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacingAdmin.Web.Controllers
{
    public class HorarioController : Controller
    {
        IHorarioDataAccess horarioDataAccess;
        IFacultadDataAccess facultadDataAccess;
        ICarreraDataAccess carreraDataAccess;
        ICursoDataAccess cursoDataAccess;
        IDocenteDataAccess docenteDataAccess;
        ILaboratorioDataAccess laboratorioDataAccess;
        public HorarioController(IHorarioDataAccess _horarioDataAccess,
            IFacultadDataAccess _facultadDataAccess,
            ICarreraDataAccess _carreraDataAccess,
            ICursoDataAccess _cursoDataAccess,
            IDocenteDataAccess _docenteDataAccess,
            ILaboratorioDataAccess _laboratorioDataAccess
            )
        {
            horarioDataAccess = _horarioDataAccess;
            facultadDataAccess = _facultadDataAccess;
            carreraDataAccess = _carreraDataAccess;
            cursoDataAccess = _cursoDataAccess;
            docenteDataAccess = _docenteDataAccess;
            laboratorioDataAccess = _laboratorioDataAccess;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                HorarioViewModel model = new HorarioViewModel();
                model.ListaHorarios = horarioDataAccess.GetListaHorarios();

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult ListaHorariosView()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                HorarioViewModel model = new HorarioViewModel();
                model.ListaHorarios = horarioDataAccess.GetListaHorarios();

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult Calendario()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                return View();
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
                List<Facultad> listaFacultades = new List<Facultad>();
                HorarioViewModel model = new HorarioViewModel();
                listaFacultades = facultadDataAccess.GetListaFacultades();
                model.ListaFacultadesLaboratorio = listaFacultades;
                model.ListaLaboratorios = laboratorioDataAccess.GetListaLaboratorios();

                model.ListaDocentes = docenteDataAccess.GetListaDocentes();

                model.ListaFacultadesCurso = listaFacultades;
                model.ListaCarreras = carreraDataAccess.GetListaCarreras();
                model.ListaCursos = cursoDataAccess.GetListaCursos();

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Crear(Horario horario)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                try
                {
                    if (String.IsNullOrEmpty(horario.FechaRecuperacion.ToString()))
                    {
                        horario.FechaRecuperacion = (DateTime?)null;
                    }

                    horarioDataAccess.CreateHorario(horario);

                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult ListaLaboratoriosView(int? idFacultad)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                HorarioViewModel model = new HorarioViewModel();
                model.ListaLaboratorios = laboratorioDataAccess.GetListaLaboratoriosByIdFacultad(idFacultad);
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult ListaCarrerasView(int? idFacultad)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                HorarioViewModel model = new HorarioViewModel();
                model.ListaCarreras = carreraDataAccess.GetListaCarrerasByIdFacultad(idFacultad);
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult ListaCursosView(int? idCarrera)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                HorarioViewModel model = new HorarioViewModel();
                model.ListaCursos = cursoDataAccess.GetListaCursosByIdCarrera(idCarrera);
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult ListaGruposView(int idCurso)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                HorarioViewModel model = new HorarioViewModel();
                model.ListaGrupos = cursoDataAccess.GetListaGruposByIdCurso(idCurso);
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult ListaSubgruposView(int idGrupo)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                HorarioViewModel model = new HorarioViewModel();
                model.ListaSubgrupos = cursoDataAccess.GetListaSubgruposByIdGrupo(idGrupo);
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult Editar(int idHorario)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                HorarioViewModel model = new HorarioViewModel();
                model.Horario = horarioDataAccess.GetHorarioById(idHorario);

                List<Facultad> listaFacultades = new List<Facultad>();
                listaFacultades = facultadDataAccess.GetListaFacultades();
                model.ListaFacultadesLaboratorio = listaFacultades;
                model.ListaDocentes = docenteDataAccess.GetListaDocentes();
                model.ListaFacultadesCurso = listaFacultades;

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Editar(Horario horario)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                try
                {
                    if (String.IsNullOrEmpty(horario.FechaRecuperacion.ToString()))
                    {
                        horario.FechaRecuperacion = (DateTime?)null;
                    }

                    horarioDataAccess.UpdateHorario(horario);
                }
                catch (Exception)
                {
                    throw;
                }

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int idHorario)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                try
                {
                    horarioDataAccess.DeleteHorario(idHorario);
                    return RedirectToAction("Index", "Horario", new { Area = ""});
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public int GetHorarioExiste(int idLaboratorio, int dia, string horaInicio, string horaFin, int idHorario)
        {
            return horarioDataAccess.GetHorarioExiste(idLaboratorio, dia, horaInicio, horaFin, idHorario);
        }
    }
}