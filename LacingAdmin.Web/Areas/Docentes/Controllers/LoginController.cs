using LacingAdmin.IDataAccess;
using LacingAdmin.Web.Areas.Docentes.Models;
using LacingAdmin.Web.Common;
using LacingAdmin.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LacingAdmin.Web.Areas.Docentes.Controllers
{
    public class LoginController : Controller
    {
        private readonly IDocenteDataAccess docenteDataAccess;
        public LoginController(IDocenteDataAccess _docenteDataAccess)
        {
            docenteDataAccess = _docenteDataAccess;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DocenteViewModel model)
        {
            if (String.IsNullOrEmpty(model.Docente.NombreUsuario) && String.IsNullOrEmpty(model.Docente.Contraseña))
            {
                model.MensajeValidacion = "Ingresar campos del formulario.";
                return View(model);
            }
            else if (String.IsNullOrEmpty(model.Docente.NombreUsuario))
            {
                model.MensajeValidacion = "Ingresar Nombre de Usuario.";
                return View(model);
            }
            else if (String.IsNullOrEmpty(model.Docente.Contraseña))
            {
                model.MensajeValidacion = "Ingresar Contraseña del usuario.";
                return View(model);
            }
            else
            {
                LacingAdmin.Model.Docente docente = new LacingAdmin.Model.Docente();

                if (!String.IsNullOrEmpty(model.Docente.NombreUsuario))
                {
                    model.Docente.NombreUsuario.Replace("script", "");
                    model.Docente.NombreUsuario.Replace("<", "");
                    model.Docente.NombreUsuario.Replace(">", "");
                    model.Docente.NombreUsuario.Replace(",", "");
                    model.Docente.NombreUsuario.Replace("*", "");
                }

                docente = docenteDataAccess.GetDocenteByNombreUsuario(model.Docente.NombreUsuario);

                if (docente.IdDocente > 0)
                {
                    if (model.Docente.Contraseña == docente.Contraseña)
                    {
                        //Cerramos sesion anterior
                        Request.GetOwinContext().Authentication.SignOut();
                        //Ingresamos a la aplicación
                        var claims = SecurityHelper.CreateClaimsDocente(docente);
                        //Claim: cookie de seguridad
                        var identity = new ClaimsIdentity(claims, "ApplicationCookie");
                        var context = Request.GetOwinContext();
                        var authManager = context.Authentication;
                        authManager.SignIn(identity);

                        return RedirectToAction("Index", "Home", new { Area = "Docentes" });
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
            return RedirectToAction("Index", "Login", new { Area = "Docentes" });
        }
    }
}