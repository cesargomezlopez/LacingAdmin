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
    public class DocenteController : Controller
    {
        private readonly IDocenteDataAccess docenteDataAccess;
        private readonly IDocenteXCarreraDataAccess docenteXCarreraDataAccess;
        public DocenteController(IDocenteDataAccess _docenteDataAccess, IDocenteXCarreraDataAccess _docenteXCarreraDataAccess)
        {
            docenteDataAccess = _docenteDataAccess;
            docenteXCarreraDataAccess = _docenteXCarreraDataAccess;
        }
        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                DocenteViewModel model = new DocenteViewModel();
                model.ListaDocentes = docenteDataAccess.GetListaDocentes();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult DocenteXCarrerasView(int idDocente)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                DocenteViewModel model = new DocenteViewModel();
                LacingAdmin.Model.Docente docenteAux = new LacingAdmin.Model.Docente();
                docenteAux.IdDocente = idDocente;
                model.Docente = docenteAux;
                model.ListaDocentesXCarrera = docenteDataAccess.GetListaCarrerasByIdDocente(idDocente);
                model.ListaFacultadesRestantes = docenteDataAccess.GetListaFacultadesRestantes(idDocente);
                model.ListaCarrerasXFacultadRestantes = docenteDataAccess.GetListaCarrerasRestantes(idDocente);
                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public void AgregarDocenteXCarrera(int idDocente, int idCarrera)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                try
                {
                    docenteXCarreraDataAccess.CreateDocenteXCarrera(idDocente, idCarrera);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public void EliminarDocenteXCarrera(int idDocenteXCarrera)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                try
                {
                    docenteXCarreraDataAccess.DeleteDocenteXCarrera(idDocenteXCarrera);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [HttpGet]
        public ActionResult ListaDocentesView()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                DocenteViewModel model = new DocenteViewModel();
                model.ListaDocentes = docenteDataAccess.GetListaDocentes();
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
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Crear(Docente docente)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                docenteDataAccess.CreateDocente(docente);
                return RedirectToAction("Index", "Docente", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult Editar(int idDocente)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                Docente docente = new Docente();
                docente = docenteDataAccess.GetDocenteById(idDocente);
                ViewBag.IdDocente = docente.IdDocente;
                ViewBag.NombreUsuario = docente.NombreUsuario;
                ViewBag.Contrasena = docente.Contraseña;
                return PartialView(docente);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Editar(Docente docente)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                docenteDataAccess.UpdateDocente(docente);
                return RedirectToAction("Index", "Docente", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int idDocente)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                docenteDataAccess.DeleteDocente(idDocente);
                return RedirectToAction("Index", "Docente", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public string ExisteNombreUsuario(string nombreUsuario)
        {
            Docente docente = new Docente();
            docente = docenteDataAccess.GetDocenteByNombreUsuario(nombreUsuario);

            if (docente.IdDocente > 0)
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