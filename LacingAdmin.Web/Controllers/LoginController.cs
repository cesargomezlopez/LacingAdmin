using LacingAdmin.IDataAccess;
using LacingAdmin.Model;
using LacingAdmin.Web.Common;
using LacingAdmin.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace LacingAdmin.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdministradorDataAccess administradorDataAccess;
        public LoginController(IAdministradorDataAccess _administradorDataAccess)
        {
            administradorDataAccess = _administradorDataAccess;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            if (String.IsNullOrEmpty(model.Administrador.NombreUsuario) && String.IsNullOrEmpty(model.Administrador.Contraseña))
            {
                model.MensajeValidacion = "Ingresar campos del formulario.";
                return View(model);
            }
            else if (String.IsNullOrEmpty(model.Administrador.NombreUsuario))
            {
                model.MensajeValidacion = "Ingresar Nombre de Usuario.";
                return View(model);
            }
            else if (String.IsNullOrEmpty(model.Administrador.Contraseña))
            {
                model.MensajeValidacion = "Ingresar Contraseña del usuario.";
                return View(model);
            }
            else
            {
                Administrador administrador = new Administrador();

                if (!String.IsNullOrEmpty(model.Administrador.NombreUsuario))
                {
                    model.Administrador.NombreUsuario.Replace("script", "");
                    model.Administrador.NombreUsuario.Replace("<", "");
                    model.Administrador.NombreUsuario.Replace(">", "");
                    model.Administrador.NombreUsuario.Replace(",", "");
                    model.Administrador.NombreUsuario.Replace("*", "");
                }

                administrador = administradorDataAccess.GetAdministradorByNombreUsuario(model.Administrador.NombreUsuario);

                if (administrador.IdAdministrador > 0)
                {
                    if (model.Administrador.Contraseña == administrador.Contraseña)
                    {
                        //Cerramos sesion anterior
                        Request.GetOwinContext().Authentication.SignOut();
                        //Ingresamos a la aplicación
                        var claims = SecurityHelper.CreateClaimsAdministrador(administrador);
                        //Claim: cookie de seguridad
                        var identity = new ClaimsIdentity(claims, "ApplicationCookie");
                        var context = Request.GetOwinContext();
                        var authManager = context.Authentication;
                        authManager.SignIn(identity);

                        return RedirectToAction("Index", "Home", new { Area = "" });
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
            return RedirectToAction("Index", "Login", new { Area = "" });
        }

        public ActionResult Autorizacion()
        {
            return View();
        }
    }
}