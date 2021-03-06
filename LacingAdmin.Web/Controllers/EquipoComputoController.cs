﻿using LacingAdmin.IDataAccess;
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
    public class EquipoComputoController : BaseController
    {
        private readonly IHardwareDataAccess hardwareDataAccess;
        private readonly IFacultadDataAccess facultadDataAccess;
        private readonly ILaboratorioDataAccess laboratorioDataAccess;
        private readonly IObservacionXHardwareDataAccess observacionXHardwareDataAccess;

        public EquipoComputoController(IHardwareDataAccess _hardwareDataAccess,
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

        public ActionResult ListaEquiposComputoView()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();
                model.ListaEquiposComputo = hardwareDataAccess.GetListaEquiposComputo();    
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

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Crear(Hardware equipoComputoCpu, Hardware equipoComputoMonitor, Hardware equipoComputoTeclado, Hardware equipoComputoMouse, string idLaboratorio)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();
                model.equipoComputoCpu = equipoComputoCpu;
                model.equipoComputoMonitor = equipoComputoMonitor;
                model.equipoComputoTeclado = equipoComputoTeclado;
                model.equipoComputoMouse = equipoComputoMouse;

                model.equipoComputoCpu.IdLaboratorio = int.Parse(idLaboratorio);
                model.equipoComputoMonitor.IdLaboratorio = int.Parse(idLaboratorio);
                model.equipoComputoTeclado.IdLaboratorio = int.Parse(idLaboratorio);
                model.equipoComputoMouse.IdLaboratorio = int.Parse(idLaboratorio);

                List<Hardware> equiposComputoList = new List<Hardware>();
                equiposComputoList.Add(model.equipoComputoCpu);
                equiposComputoList.Add(model.equipoComputoMonitor);
                equiposComputoList.Add(model.equipoComputoTeclado);
                equiposComputoList.Add(model.equipoComputoMouse);

                hardwareDataAccess.CreateHardware(equiposComputoList);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult Editar(string usuario)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();

                model.ListaEquiposComputoGetByUsuario = hardwareDataAccess.GetEquiposComputoByUsuario(usuario);
                for (int i = 0; i < model.ListaEquiposComputoGetByUsuario.Count; i++)
                {
                    string tipoEquipoComputo = model.ListaEquiposComputoGetByUsuario[i].TipoEquipo;
                    if (tipoEquipoComputo.Equals("CPU"))
                    {
                        model.equipoComputoCpu = model.ListaEquiposComputoGetByUsuario[i];
                    }
                    else if (tipoEquipoComputo.Equals("MONITOR"))
                    {
                        model.equipoComputoMonitor = model.ListaEquiposComputoGetByUsuario[i];
                    }
                    else if (tipoEquipoComputo.Equals("TECLADO"))
                    {
                        model.equipoComputoTeclado = model.ListaEquiposComputoGetByUsuario[i];
                    }
                    else if (tipoEquipoComputo.Equals("MOUSE"))
                    {
                        model.equipoComputoMouse = model.ListaEquiposComputoGetByUsuario[i];
                    }
                }

                model.ListaFacultadesLaboratorio = facultadDataAccess.GetListaFacultades();
                model.ListaLaboratorios = laboratorioDataAccess.GetListaLaboratorios();
                ViewBag.nombreUsuarioEquipoAEditar = model.equipoComputoCpu.Usuario;

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Editar(Hardware equipoComputoCpu, Hardware equipoComputoMonitor, Hardware equipoComputoTeclado, Hardware equipoComputoMouse, string idLaboratorio, string nombreUsuarioEquipoAEditar)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                EquipoComputoViewModel model = new EquipoComputoViewModel();
                model.equipoComputoCpu = equipoComputoCpu;
                model.equipoComputoMonitor = equipoComputoMonitor;
                model.equipoComputoTeclado = equipoComputoTeclado;
                model.equipoComputoMouse = equipoComputoMouse;

                model.equipoComputoCpu.IdLaboratorio = int.Parse(idLaboratorio);
                model.equipoComputoMonitor.IdLaboratorio = int.Parse(idLaboratorio);
                model.equipoComputoTeclado.IdLaboratorio = int.Parse(idLaboratorio);
                model.equipoComputoMouse.IdLaboratorio = int.Parse(idLaboratorio);

                model.ListaEquiposComputoGetByUsuario = hardwareDataAccess.GetEquiposComputoByUsuario(nombreUsuarioEquipoAEditar);
                for (int i = 0; i < model.ListaEquiposComputoGetByUsuario.Count; i++)
                {
                    string tipoEquipoComputo = model.ListaEquiposComputoGetByUsuario[i].TipoEquipo;
                    if (tipoEquipoComputo.Equals("CPU"))
                    {
                        model.equipoComputoCpu.IdHardware = model.ListaEquiposComputoGetByUsuario[i].IdHardware;
                    }
                    else if (tipoEquipoComputo.Equals("MONITOR"))
                    {
                        model.equipoComputoMonitor.IdHardware = model.ListaEquiposComputoGetByUsuario[i].IdHardware;
                    }
                    else if (tipoEquipoComputo.Equals("TECLADO"))
                    {
                        model.equipoComputoTeclado.IdHardware = model.ListaEquiposComputoGetByUsuario[i].IdHardware;
                    }
                    else if (tipoEquipoComputo.Equals("MOUSE"))
                    {
                        model.equipoComputoMouse.IdHardware = model.ListaEquiposComputoGetByUsuario[i].IdHardware;
                    }
                }

                List<Hardware> equiposComputoList = new List<Hardware>();
                equiposComputoList.Add(model.equipoComputoCpu);
                equiposComputoList.Add(model.equipoComputoMonitor);
                equiposComputoList.Add(model.equipoComputoTeclado);
                equiposComputoList.Add(model.equipoComputoMouse);

                hardwareDataAccess.UpdateHardware(equiposComputoList);

                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Eliminar(string usuario)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                hardwareDataAccess.DeleteEquipoComputoByUsuario(usuario);
                return RedirectToAction("Index", "EquipoComputo", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult ActualizarEstadoHardware(int idHardware, string estado)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                hardwareDataAccess.UpdateEstadoHardwareById(idHardware, estado);
                return RedirectToAction("Index", "EquipoComputo", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpGet]
        public ActionResult ObservacionesView(int idHardware, int tipoEquipo)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                string tipoObservacion = tipoEquipo.Equals(1) ? "Software" : "Hardware";
                ObservacionXHardwareViewModel model = new ObservacionXHardwareViewModel();
                model.ObservacionXHardware = new ObservacionXHardware();
                model.ObservacionXHardware.IdHardware = idHardware;
                model.ObservacionXHardware.Tipo = tipoObservacion;
                model.TipoObservacion = tipoObservacion;
                model.ListaObservacionesXHardware = observacionXHardwareDataAccess.GetListaObservacionesXHardwareByIdAndTipo(idHardware, tipoObservacion);

                return PartialView(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult ObservacionesView(ObservacionXHardware observacion)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && SecurityHelper.GetAdministradorRol() == "Administrador General")
            {
                if (observacion.Tipo.Equals("Hardware"))
                {
                    observacionXHardwareDataAccess.CreateObservacionTipoHardware(observacion);
                }
                else if (observacion.Tipo.Equals("Software"))
                {
                    observacionXHardwareDataAccess.CreateObservacionTipoSoftware(observacion);
                }

                return RedirectToAction("Index", "EquipoComputo", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult EditarObservacion(ObservacionXHardware observacion)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                if (observacion.Tipo.Equals("Hardware"))
                {
                    observacionXHardwareDataAccess.UpdateObservacionTipoHardware(observacion);
                }
                else if (observacion.Tipo.Equals("Software"))
                {
                    observacionXHardwareDataAccess.UpdateObservacionTipoSoftware(observacion);
                }

                return RedirectToAction("Index", "EquipoComputo", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult EliminarObservacion(int idObservacion)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General" || SecurityHelper.GetAdministradorRol() == "Técnico"))
            {
                observacionXHardwareDataAccess.DeleteObservacion(idObservacion);
                return RedirectToAction("Index", "EquipoComputo", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        //[HttpGet]
        //public string ExisteNombreFacultad(string nombreFacultad)
        //{
        //    Facultad facultad = new Facultad();
        //    facultad = facultadDataAccess.GetFacultadByNombreFacultad(nombreFacultad);

        //    if (facultad.IdFacultad > 0)
        //    {
        //        return "existe";
        //    }
        //    else
        //    {
        //        return "noexiste";
        //    }
        //}
    }
}