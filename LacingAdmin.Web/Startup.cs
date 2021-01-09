using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(LacingAdmin.Web.Startup))]

namespace LacingAdmin.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            UrlHelper _url = new UrlHelper(HttpContext.Current.Request.RequestContext);
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    AuthenticationType = "ApplicationCookie",
                    CookieName = "LacingAdminCookie",
                    ExpireTimeSpan = TimeSpan.FromHours(1),
                    LoginPath = new PathString(_url.Action("Index", "Login", new { Area = ""}))
                }
                );
        }
    }
}
