using LacingAdmin.IDataAccess;
using LacingAdmin.Web.Areas.Alumnos.Models;
using LacingAdmin.Web.Common;
using LacingAdmin.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LacingAdmin.Web.Areas.Alumnos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAlumnoDataAccess alumnoDataAccess;
        public LoginController(IAlumnoDataAccess _alumnoDataAccess)
        {
            alumnoDataAccess = _alumnoDataAccess;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AlumnoViewModel model)
        {
            if (String.IsNullOrEmpty(model.Alumno.NombreUsuario) && String.IsNullOrEmpty(model.Alumno.Contraseña))
            {
                model.MensajeValidacion = "Ingresar campos del formulario.";
                return View(model);
            }
            else if (String.IsNullOrEmpty(model.Alumno.NombreUsuario))
            {
                model.MensajeValidacion = "Ingresar Nombre de Usuario.";
                return View(model);
            }
            else if (String.IsNullOrEmpty(model.Alumno.Contraseña))
            {
                model.MensajeValidacion = "Ingresar Contraseña del usuario.";
                return View(model);
            }
            else
            {
                LacingAdmin.Model.Alumno alumno = new LacingAdmin.Model.Alumno();

                if (!String.IsNullOrEmpty(model.Alumno.NombreUsuario))
                {
                    model.Alumno.NombreUsuario.Replace("script", "");
                    model.Alumno.NombreUsuario.Replace("<", "");
                    model.Alumno.NombreUsuario.Replace(">", "");
                    model.Alumno.NombreUsuario.Replace(",", "");
                    model.Alumno.NombreUsuario.Replace("*", "");
                }

                alumno = alumnoDataAccess.GetAlumnoByNombreUsuario(model.Alumno.NombreUsuario);

                if (alumno.IdAlumno > 0)
                {
                    if (model.Alumno.Contraseña == alumno.Contraseña)
                    {
                        //Cerramos sesion anterior
                        Request.GetOwinContext().Authentication.SignOut();
                        //Ingresamos a la aplicación
                        var claims = SecurityHelper.CreateClaimsAlumno(alumno);
                        //Claim: cookie de seguridad
                        var identity = new ClaimsIdentity(claims, "ApplicationCookie");
                        var context = Request.GetOwinContext();
                        var authManager = context.Authentication;
                        authManager.SignIn(identity);

                        return RedirectToAction("Index", "Home", new { Area = "Alumnos" });
                    }
                    else
                    {
                        model.MensajeValidacion = "La contraseña es incorrecta, corrija por favor.";
                        return View(model);
                    }
                }
                else
                {
                    model.MensajeValidacion = "El nombre de usuario no existe, corrija por favor.";
                    return View(model);
                }
            }
        }

        public ActionResult SignOut()
        {
            Request.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index", "Login", new { Area = "Alumnos" });
        }
    }
}