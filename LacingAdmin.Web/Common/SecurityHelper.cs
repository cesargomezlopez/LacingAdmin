using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using LacingAdmin.Model;

namespace LacingAdmin.Web.Common
{
    public class SecurityHelper
    {
        #region ClaimsAdministrador
        public static List<Claim> CreateClaimsAdministrador(Administrador administrador)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, $"{administrador.Nombres}{", "}{administrador.Paterno}{" "}{administrador.Materno}"));
            claims.Add(new Claim("IdAdministrador", administrador.IdAdministrador.ToString()));
            claims.Add(new Claim("NombreUsuario", administrador.NombreUsuario.ToString()));
            claims.Add(new Claim("Contraseña", administrador.Contraseña.ToString()));
            claims.Add(new Claim("Rol", administrador.Rol.ToString()));
            claims.Add(new Claim("Estado", administrador.Estado.ToString()));

            return claims;
        }

        public static IEnumerable<Claim> GetClaimsByType(string type)
        {
            var identity = (ClaimsIdentity)HttpContext.Current.User.Identity; //Cada vez logeado toda la info 
            //guardada esta en este identity, HttpContext.Current.User.Identity esta recuperando la info
            var claims = identity.Claims.Where(item => item.Type == type).ToList();
            return claims;
        }

        public static string GetAdministradorNombres()
        {
            var claimValue = GetClaimsByType(ClaimTypes.Name).FirstOrDefault()?.Value;
            return claimValue;
        }

        public static int GetAdministradorID()
        {
            var claimValue = GetClaimsByType("IdAdministrador").FirstOrDefault() != null ?
                Convert.ToInt32(GetClaimsByType("IdAdministrador").FirstOrDefault().Value) : 0;
            return claimValue;
        }
        public static string GetAdministradorNombreUsuario()
        {
            var claimValue = GetClaimsByType("NombreUsuario").FirstOrDefault()?.Value;
            return claimValue;
        }
        public static string GetAdministradorContraseña()
        {
            var claimValue = GetClaimsByType("Contraseña").FirstOrDefault()?.Value;
            return claimValue;
        }
        public static string GetAdministradorRol()
        {
            var claimValue = GetClaimsByType("Rol").FirstOrDefault()?.Value;
            return claimValue;
        }
        public static string GetAdministradorEstado()
        {
            var claimValue = GetClaimsByType("Estado").FirstOrDefault()?.Value;
            return claimValue;
        }

        #endregion



        #region ClaimsDocente
        public static List<Claim> CreateClaimsDocente(Docente docente)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, $"{docente.Nombres}{", "}{docente.Paterno}{" "}{docente.Materno}"));
            claims.Add(new Claim("IdDocente", docente.IdDocente.ToString()));
            claims.Add(new Claim("NombreUsuarioDocente", docente.NombreUsuario.ToString()));
            claims.Add(new Claim("ContraseñaDocente", docente.Contraseña.ToString()));

            return claims;
        }

        public static string GetDocenteNombres()
        {
            var claimValue = GetClaimsByType(ClaimTypes.Name).FirstOrDefault()?.Value;
            return claimValue;
        }

        public static int GetDocenteID()
        {
            var claimValue = GetClaimsByType("IdDocente").FirstOrDefault() != null ?
                Convert.ToInt32(GetClaimsByType("IdDocente").FirstOrDefault().Value) : 0;
            return claimValue;
        }
        public static string GetDocenteNombreUsuario()
        {
            var claimValue = GetClaimsByType("NombreUsuarioDocente").FirstOrDefault()?.Value;
            return claimValue;
        }
        #endregion



        #region ClaimsAlumno
        public static List<Claim> CreateClaimsAlumno(Alumno alumno)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, $"{alumno.Nombres}{", "}{alumno.Paterno}{" "}{alumno.Materno}"));
            claims.Add(new Claim("IdAlumno", alumno.IdAlumno.ToString()));
            claims.Add(new Claim("NombreUsuarioAlumno", alumno.NombreUsuario.ToString()));
            claims.Add(new Claim("ContraseñaAlumno", alumno.Contraseña.ToString()));

            return claims;
        }
        public static string GetAlumnoNombres()
        {
            var claimValue = GetClaimsByType(ClaimTypes.Name).FirstOrDefault()?.Value;
            return claimValue;
        }

        public static int GetAlumnoID()
        {
            var claimValue = GetClaimsByType("IdAlumno").FirstOrDefault() != null ?
                Convert.ToInt32(GetClaimsByType("IdAlumno").FirstOrDefault().Value) : 0;
            return claimValue;
        }
        public static string GetAlumnoNombreUsuario()
        {
            var claimValue = GetClaimsByType("NombreUsuarioAlumno").FirstOrDefault()?.Value;
            return claimValue;
        }
        #endregion
    }
}