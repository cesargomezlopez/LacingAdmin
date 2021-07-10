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
    public class EquipoGeneralController : BaseController
    {
        private readonly IHardwareDataAccess hardwareDataAccess;
        private readonly IFacultadDataAccess facultadDataAccess;
        private readonly ILaboratorioDataAccess laboratorioDataAccess;
        private readonly IObservacionXHardwareDataAccess observacionXHardwareDataAccess;

        public EquipoGeneralController(IHardwareDataAccess _hardwareDataAccess,
            IFacultadDataAccess _facultadDataAccess,
            ILaboratorioDataAccess _laboratorioDataAccess,
            IObservacionXHardwareDataAccess _observacionXHardwareDataAccess
            )
        {
            hardwareDataAccess = _hardwareDataAccess;
            facultadDataAccess = _facultadDataAccess;
            laboratorioDataAccess = _laboratorioDataAccess;
            observacionXHardwareDataAccess = _observacionXHardwareDataAccess;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        public ActionResult ListaEquiposGeneralView()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();
                model.ListaEquiposGeneral = hardwareDataAccess.GetListaEquiposGeneral();    
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
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();

                model.ListaFacultadesLaboratorio = facultadDataAccess.GetListaFacultades();
                model.ListaLaboratorios = laboratorioDataAccess.GetListaLaboratorios();

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Crear(Hardware hardware, string idLaboratorio)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();
                model.hardware = hardware;
                model.hardware.IdLaboratorio = int.Parse(idLaboratorio);

                List<Hardware> hardwareList = new List<Hardware>();
                hardwareList.Add(model.hardware);

                hardwareDataAccess.CreateHardware(hardwareList);

                return RedirectToAction("Index", "EquipoGeneral", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult Editar(string idHardware)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();

                model.hardware = hardwareDataAccess.GetHardwareById(int.Parse(idHardware));

                model.ListaFacultadesLaboratorio = facultadDataAccess.GetListaFacultades();
                model.ListaLaboratorios = laboratorioDataAccess.GetListaLaboratorios();

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Editar(Hardware hardware, string idLaboratorio, string idHardware)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();
                model.hardware = hardware;
                model.hardware.IdLaboratorio = int.Parse(idLaboratorio);
                model.hardware.IdHardware = int.Parse(idHardware);

                List<Hardware> equiposComputoList = new List<Hardware>();
                equiposComputoList.Add(model.hardware);

                hardwareDataAccess.UpdateHardware(equiposComputoList);

                return RedirectToAction("Index", "EquipoGeneral", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Eliminar(string idHardware)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                hardwareDataAccess.DeleteEquipoComputoById(int.Parse(idHardware));
                return RedirectToAction("Index", "EquipoGeneral", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult ObservacionesGeneralView(int idHardware)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                ObservacionXHardwareViewModel model = new ObservacionXHardwareViewModel();
                model.ObservacionXHardware = new ObservacionXHardware();
                model.ObservacionXHardware.IdHardware = idHardware;
                model.ObservacionXHardware.Tipo = "EquipoGeneral";
                model.ListaObservacionesXHardware = observacionXHardwareDataAccess.GetListaObservacionesXHardwareByIdAndTipo(idHardware, "EquipoGeneral");

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult ObservacionesGeneralView(ObservacionXHardware observacion)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                observacionXHardwareDataAccess.CreateObservacionTipoEquipoGeneral(observacion);
                return RedirectToAction("Index", "EquipoGeneral", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
    }
}