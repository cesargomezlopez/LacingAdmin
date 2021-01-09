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
    public class AlumnoController : BaseController
    {
        IAlumnoDataAccess alumnoDataAccess;
        public AlumnoController(IAlumnoDataAccess _alumnoDataAccess)
        {
            alumnoDataAccess = _alumnoDataAccess;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                AlumnoViewModel model = new AlumnoViewModel();
                model.ListaAlumnos = alumnoDataAccess.GetListaAlumno();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        public ActionResult ListaAlumnosView()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                AlumnoViewModel model = new AlumnoViewModel();
                model.ListaAlumnos = alumnoDataAccess.GetListaAlumno();
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
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                return PartialView();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Crear(Alumno alumno)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                alumnoDataAccess.CreateAlumno(alumno);
                return RedirectToAction("Index", "Alumno", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult Editar(int idAlumno)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                Alumno alumno = new Alumno();
                alumno = alumnoDataAccess.GetAlumnoById(idAlumno);
                ViewBag.IdAlumno = alumno.IdAlumno;
                ViewBag.NombreUsuario = alumno.NombreUsuario;
                ViewBag.Contrasena = alumno.Contraseña;
                return PartialView(alumno);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Editar(Alumno alumno)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                alumnoDataAccess.UpdateAlumno(alumno);
                return RedirectToAction("Index", "Alumno", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Eliminar(int idAlumno)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                alumnoDataAccess.DeleteAlumno(idAlumno);
                return RedirectToAction("Index", "Alumno", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public string ExisteNombreUsuario(string nombreUsuario)
        {
            Alumno alumno = new Alumno();
            alumno = alumnoDataAccess.GetAlumnoByNombreUsuario(nombreUsuario);

            if (alumno.IdAlumno > 0)
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