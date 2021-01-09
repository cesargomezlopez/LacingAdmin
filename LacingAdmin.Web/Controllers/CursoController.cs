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
    public class CursoController : BaseController
    {
        private readonly ICursoDataAccess cursoDataAccess;
        private readonly ICarreraDataAccess carreraDataAccess;
        public CursoController(ICursoDataAccess _cursoDataAccess, ICarreraDataAccess _carreraDataAccess)
        {
            cursoDataAccess = _cursoDataAccess;
            carreraDataAccess = _carreraDataAccess;
        }
        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                CursoViewModel model = new CursoViewModel();
                model.ListaCursos = cursoDataAccess.GetListaCursos();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult ListaCursosView()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                CursoViewModel model = new CursoViewModel();
                model.ListaCursos = cursoDataAccess.GetListaCursos();
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
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                CursoViewModel model = new CursoViewModel();
                model.ListaCarreras = carreraDataAccess.GetListaCarreras();
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Crear(CursoViewModel model)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                cursoDataAccess.CreateCurso(model.Curso);
                return RedirectToAction("Index", "Curso", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult Editar(int idCurso)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                CursoViewModel model = new CursoViewModel();
                model.ListaCarreras = carreraDataAccess.GetListaCarreras();
                model.Curso = cursoDataAccess.GetCursoById(idCurso);
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Editar(CursoViewModel model)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                cursoDataAccess.UpdateCurso(model.Curso);
                return RedirectToAction("Index", "Curso", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int idCurso)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                cursoDataAccess.DeleteCurso(idCurso);
                return RedirectToAction("Index", "Curso", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult CrearGrupo(int idCurso)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                Grupo grupo = new Grupo();
                grupo.IdCurso = idCurso;
                return PartialView(grupo);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        [HttpPost]
        public ActionResult CrearGrupo(string numeroGrupo, int idCurso)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                Grupo grupo = new Grupo();
                grupo.IdCurso = idCurso;
                grupo.NumeroGrupo = numeroGrupo;
                cursoDataAccess.CreateGrupo(grupo);
                return RedirectToAction("Grupos", "Curso", new { Area = "", idCurso = idCurso });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult Grupos(int idCurso)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                CursoViewModel model = new CursoViewModel();
                model.ListaGrupos = cursoDataAccess.GetListaGruposByIdCurso(idCurso);
                model.Curso = cursoDataAccess.GetCursoById(idCurso);

                return View(model);
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
                CursoViewModel model = new CursoViewModel();
                model.ListaGrupos = cursoDataAccess.GetListaGruposByIdCurso(idCurso);
                model.Curso = cursoDataAccess.GetCursoById(idCurso);
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult EliminarGrupo(int idGrupo, int idCurso)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                cursoDataAccess.DeleteGrupo(idGrupo);
                return RedirectToAction("Grupos", "Curso", new { Area = "", idCurso = idCurso });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult SubgruposXGrupoView(int idGrupo, int idCurso)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                CursoViewModel model = new CursoViewModel();
                model.ListaSubgrupos = new List<Subgrupo>();
                model.ListaSubgrupos = cursoDataAccess.GetListaSubgruposByIdGrupo(idGrupo);

                model.Grupo = new Grupo();
                model.Grupo.IdGrupo = idGrupo;
                model.Grupo.IdCurso = idCurso;

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public void AgregarSubgrupo(int idGrupo, string numeroSubgrupo, string tipoSubgrupo)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                Subgrupo subgrupo = new Subgrupo();
                subgrupo.IdGrupo = idGrupo;
                subgrupo.NumeroSubgrupo = numeroSubgrupo;
                subgrupo.TipoSubgrupo = tipoSubgrupo;
                cursoDataAccess.CreateSubgrupo(subgrupo);
            }
        }

        [HttpPost]
        public ActionResult EliminarSubgrupo(int idSubgrupo, int idCurso)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                cursoDataAccess.DeleteSubgrupo(idSubgrupo);
                return RedirectToAction("Grupos", "Curso", new { Area = "", idCurso = idCurso });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public string ExisteNumeroSubgrupo(int idGrupo, string numeroSubgrupo)
        {
            Subgrupo subgrupo = new Subgrupo();
            subgrupo = cursoDataAccess.GetSubgrupoByIdGrupoNumeroSubgrupo(idGrupo, numeroSubgrupo);

            if (subgrupo.IdSubgrupo > 0)
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