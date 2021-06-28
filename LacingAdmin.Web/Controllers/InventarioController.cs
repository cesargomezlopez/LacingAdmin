using LacingAdmin.IDataAccess;
using LacingAdmin.Model;
using LacingAdmin.Web.Common;
using LacingAdmin.Web.Controllers.Base;
using LacingAdmin.Web.Models.ViewModels;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LacingAdmin.Web.Controllers
{
    public class InventarioController : BaseController
    {
        private readonly IHardwareDataAccess hardwareDataAccess;
        private readonly ISoftwareDataAccess softwareDataAccess;
        private readonly IFacultadDataAccess facultadDataAccess;
        private readonly ILaboratorioDataAccess laboratorioDataAccess;
        public InventarioController(IHardwareDataAccess _hardwareDataAccess,
            ISoftwareDataAccess _softwareDataAccess,
            IFacultadDataAccess _facultadDataAccess,
            ILaboratorioDataAccess _laboratorioDataAccess)
        {
            hardwareDataAccess = _hardwareDataAccess;
            softwareDataAccess = _softwareDataAccess;
            facultadDataAccess = _facultadDataAccess;
            laboratorioDataAccess = _laboratorioDataAccess;
        }

        #region Hardware
        [HttpGet]
        public ActionResult Hardware()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();
                model.ListaFacultadesLaboratorio = facultadDataAccess.GetListaFacultades();
                model.ListaLaboratorios = laboratorioDataAccess.GetListaLaboratorios();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [AllowAnonymous]
        public ActionResult ListaReporteEquipoComputoPartial(string idLaboratorio, string nombreUsuario)
        {
            EquipoComputoViewModel model = new EquipoComputoViewModel();
            if (String.IsNullOrEmpty(nombreUsuario))
            {
                model.ListaEquiposComputo = hardwareDataAccess.GetListaHardwareByLaboratorioAndTipo(int.Parse(idLaboratorio), "1");
            } else
            {
                model.ListaEquiposComputo = hardwareDataAccess.GetListaHardwareByLaboratorioAndTipoAndNombreUsuario(int.Parse(idLaboratorio), "1", nombreUsuario);
            }
            return PartialView(model);
        }

        [AllowAnonymous]
        public ActionResult ListaReporteEquipoGeneralPartial(string idLaboratorio)
        {
            EquipoComputoViewModel model = new EquipoComputoViewModel();
            model.ListaEquiposGeneral = hardwareDataAccess.GetListaHardwareByLaboratorioAndTipo(int.Parse(idLaboratorio), "0");
            return PartialView(model);
        }

        [AllowAnonymous]
        public ActionResult ReporteGeneralContent(string flgReporteEquipoComputo, string idLaboratorio, string nombreUsuario)
        {
            EquipoComputoViewModel model = new EquipoComputoViewModel();

            if (flgReporteEquipoComputo == "1")
            {
                if (!String.IsNullOrEmpty(nombreUsuario))
                {
                    model.ListaEquiposComputo = hardwareDataAccess.GetListaHardwareByLaboratorioAndTipoAndNombreUsuario(int.Parse(idLaboratorio), "1", nombreUsuario);
                    return PartialView(model);
                } else
                {
                    model.ListaEquiposComputo = hardwareDataAccess.GetListaHardwareByLaboratorioAndTipo(int.Parse(idLaboratorio), "1");
                    return PartialView(model);
                }
            }
            else
            {
                model.ListaEquiposGeneral = hardwareDataAccess.GetListaHardwareByLaboratorioAndTipo(int.Parse(idLaboratorio), "0");
                return PartialView(model);
            }
        }

        public ActionResult DescargarReporteInventario(string flgReporteEquipoComputo, string idLaboratorio, string nombreUsuario)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                return new ActionAsPdf("ReporteGeneralContent", new { flgReporteEquipoComputo = flgReporteEquipoComputo, idLaboratorio = idLaboratorio, nombreUsuario = nombreUsuario }) { FileName = "ReporteInventarioEquipoComputoLacing.pdf" };
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        #endregion


        #region Software
        [HttpGet]
        public ActionResult Software()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                SoftwareViewModel model = new SoftwareViewModel();
                model.ListaFacultadesLaboratorio = facultadDataAccess.GetListaFacultades();
                model.ListaLaboratorios = laboratorioDataAccess.GetListaLaboratorios();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [AllowAnonymous]
        public ActionResult ListaReporteSoftwarePartial(string idFacultad, string idLaboratorio, string nombreSoftware, string tipoSoftware)
        {
            SoftwareViewModel model = new SoftwareViewModel();
            this.GetListaSoftwaresReporte(model, idFacultad, idLaboratorio, nombreSoftware, tipoSoftware);

            return PartialView(model);
        }

        public void GetListaSoftwaresReporte(SoftwareViewModel model, string idFacultad, string idLaboratorio, string nombreSoftware, string tipoSoftware)
        {
            if (!String.IsNullOrEmpty(idFacultad))
            {
                model.ListaSoftware = softwareDataAccess.GetListaSoftwareByIdFacultad(int.Parse(idFacultad));
            }
            else if (!String.IsNullOrEmpty(idLaboratorio))
            {
                model.ListaSoftware = softwareDataAccess.GetListaSoftwareByIdLaboratorio(int.Parse(idLaboratorio));
            }
            else if (!String.IsNullOrEmpty(nombreSoftware))
            {
                model.ListaSoftware = softwareDataAccess.GetListaSoftwareByNombre(nombreSoftware);
            }
            else if (!String.IsNullOrEmpty(tipoSoftware))
            {
                model.ListaSoftware = softwareDataAccess.GetListaSoftwareByTipo(tipoSoftware);
            }

            // Code from Software Controller
            if (model.ListaSoftware != null && model.ListaSoftware.Count > 0)
            {
                for (int i = 0; i < model.ListaSoftware.Count; i++)
                {
                    model.ListaSoftware[i].ListaSoftwareXLaboratorio = softwareDataAccess.GetListaSoftwareXLaboratorioByIdSoftware(model.ListaSoftware[i].IdSoftware);
                    model.ListaSoftware[i].ListaSoftwareXCarrera = softwareDataAccess.GetListaSoftwareXCarreraByIdSoftware(model.ListaSoftware[i].IdSoftware);

                    if (model.ListaSoftware[i].ListaSoftwareXLaboratorio != null && model.ListaSoftware[i].ListaSoftwareXLaboratorio.Count > 0)
                    {
                        for (int j = 0; j < model.ListaSoftware[i].ListaSoftwareXLaboratorio.Count; j++)
                        {
                            Laboratorio laboratorio = new Laboratorio();
                            laboratorio.IdLaboratorio = model.ListaSoftware[i].ListaSoftwareXLaboratorio[j].IdLaboratorio;
                            laboratorio.NombreLaboratorio = model.ListaSoftware[i].ListaSoftwareXLaboratorio[j].NombreLaboratorio;
                            laboratorio.IdFacultad = model.ListaSoftware[i].ListaSoftwareXLaboratorio[j].IdFacultad;
                            laboratorio.NombreFacultad = model.ListaSoftware[i].ListaSoftwareXLaboratorio[j].NombreFacultad;

                            if (model.ListaSoftware[i].ListaLaboratorios == null || model.ListaSoftware[i].ListaLaboratorios.Count == 0)
                            {
                                model.ListaSoftware[i].ListaLaboratorios = new List<Laboratorio>();
                            }
                            model.ListaSoftware[i].ListaLaboratorios.Add(laboratorio);
                        }
                    }

                    if (model.ListaSoftware[i].ListaSoftwareXCarrera != null && model.ListaSoftware[i].ListaSoftwareXCarrera.Count > 0)
                    {
                        for (int k = 0; k < model.ListaSoftware[i].ListaSoftwareXCarrera.Count; k++)
                        {
                            Carrera carrera = new Carrera();
                            carrera.IdCarrera = model.ListaSoftware[i].ListaSoftwareXCarrera[k].IdCarrera;
                            carrera.NombreCarrera = model.ListaSoftware[i].ListaSoftwareXCarrera[k].NombreCarrera;
                            carrera.IdFacultad = model.ListaSoftware[i].ListaSoftwareXCarrera[k].IdFacultad;
                            carrera.NombreFacultad = model.ListaSoftware[i].ListaSoftwareXCarrera[k].NombreFacultad;

                            if (model.ListaSoftware[i].ListaCarreras == null || model.ListaSoftware[i].ListaCarreras.Count == 0)
                            {
                                model.ListaSoftware[i].ListaCarreras = new List<Carrera>();
                            }
                            model.ListaSoftware[i].ListaCarreras.Add(carrera);
                        }
                    }

                    model.ListaSoftware[i].IdFacultad = model.ListaSoftware[i].ListaLaboratorios[0].IdFacultad;
                    model.ListaSoftware[i].NombreFacultad = model.ListaSoftware[i].ListaLaboratorios[0].NombreFacultad;
                }
            }
        }

        [AllowAnonymous]
        public ActionResult ReporteSoftwareContent(string idFacultad, string idLaboratorio, string nombreSoftware, string tipoSoftware)
        {
            SoftwareViewModel model = new SoftwareViewModel();
            this.GetListaSoftwaresReporte(model, idFacultad, idLaboratorio, nombreSoftware, tipoSoftware);

            return PartialView(model);
        }

        public ActionResult DescargarReporteInventarioSoftware(string idFacultad, string idLaboratorio, string nombreSoftware, string tipoSoftware)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                return new ActionAsPdf("ReporteSoftwareContent", new { idFacultad = idFacultad,
                    idLaboratorio = idLaboratorio,
                    nombreSoftware = nombreSoftware,
                    tipoSoftware = tipoSoftware,
                }) { FileName = "ReporteInventarioSoftwareLacing.pdf" };
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
        #endregion
    }
}