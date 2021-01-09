using LacingAdmin.Web.Common;
using LacingAdmin.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacingAdmin.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (SecurityHelper.GetAdministradorID() > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
    }
}