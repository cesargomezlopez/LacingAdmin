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
    public class SoftwareController : BaseController
    {
        private readonly IHardwareDataAccess hardwareDataAccess;
        private readonly ISoftwareDataAccess softwareDataAccess;
        private readonly IFacultadDataAccess facultadDataAccess;
        private readonly ILaboratorioDataAccess laboratorioDataAccess;
        private readonly ICarreraDataAccess carreraDataAccess;

        public SoftwareController(IHardwareDataAccess _hardwareDataAccess,
            ISoftwareDataAccess _softwareDataAccess,
            IFacultadDataAccess _facultadDataAccess,
            ILaboratorioDataAccess _laboratorioDataAccess,
            ICarreraDataAccess _carreraDataAccess
            )
        {
            softwareDataAccess = _softwareDataAccess;
            hardwareDataAccess = _hardwareDataAccess;
            hardwareDataAccess = _hardwareDataAccess;
            facultadDataAccess = _facultadDataAccess;
            laboratorioDataAccess = _laboratorioDataAccess;
            carreraDataAccess = _carreraDataAccess;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                SoftwareViewModel model = new SoftwareViewModel();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        public ActionResult ListaSoftwaresView()
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                SoftwareViewModel model = new SoftwareViewModel();
                model.ListaSoftware = softwareDataAccess.GetListaSoftwares();

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
                SoftwareViewModel model = new SoftwareViewModel();

                model.ListaFacultadesLaboratorioForm = facultadDataAccess.GetListaFacultades();

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Crear(Software software)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                this.setSoftwareValues(software);
                softwareDataAccess.CreateSoftware(software);

                return RedirectToAction("Index", "Software", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        public void setSoftwareValues(Software software)
        {
            software.ListaCarreras = new List<Carrera>();
            software.ListaLaboratorios = new List<Laboratorio>();

            List<Carrera> listaCarrerasExistentes = carreraDataAccess.GetListaCarreras();
            string[] listaCarrerasSeleccionadas = software.CarrerasStringList.Split('\n');

            foreach (string carreraSeleccionada in listaCarrerasSeleccionadas)
            {
                foreach (Carrera carreraExistente in listaCarrerasExistentes)
                {
                    if (carreraSeleccionada.Equals(carreraExistente.NombreCarrera))
                    {
                        software.ListaCarreras.Add(carreraExistente);
                    }
                }
            }

            List<Laboratorio> listaLaboratoriosExistentes = laboratorioDataAccess.GetListaLaboratorios();
            string[] listaLaboratoriosSeleccionados = software.LaboratoriosStringList.Split('\n');

            foreach (string laboratoriosSeleccionado in listaLaboratoriosSeleccionados)
            {
                foreach (Laboratorio laboratorioExistente in listaLaboratoriosExistentes)
                {
                    if (laboratoriosSeleccionado.Equals(laboratorioExistente.NombreLaboratorio))
                    {
                        software.ListaLaboratorios.Add(laboratorioExistente);
                    }
                }
            }
        }

        [HttpGet]
        public ActionResult Editar(string idSoftware)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                SoftwareViewModel model = new SoftwareViewModel();

                model.Software = softwareDataAccess.GetSoftwareById(int.Parse(idSoftware));
                model.Software.IdFacultad = 1;

                model.Software.ListaSoftwareXCarrera = softwareDataAccess.GetListaSoftwareXCarreraByIdSoftware(int.Parse(idSoftware));
                foreach (SoftwareXCarrera item in model.Software.ListaSoftwareXCarrera)
                {
                    model.Software.CarrerasStringList += item.NombreCarrera + "\n";
                }
                if (model.Software.CarrerasStringList.Length > 1)
                {
                    model.Software.CarrerasStringList = model.Software.CarrerasStringList.Remove(model.Software.CarrerasStringList.Length - 1);
                }

                model.Software.ListaSoftwareXLaboratorio = softwareDataAccess.GetListaSoftwareXLaboratorioByIdSoftware(int.Parse(idSoftware));
                foreach (SoftwareXLaboratorio item in model.Software.ListaSoftwareXLaboratorio)
                {
                    model.Software.LaboratoriosStringList += item.NombreLaboratorio + "\n";
                }
                if (model.Software.LaboratoriosStringList.Length > 1)
                {
                    model.Software.LaboratoriosStringList = model.Software.LaboratoriosStringList.Remove(model.Software.LaboratoriosStringList.Length - 1);
                }

                model.ListaFacultadesLaboratorioForm = facultadDataAccess.GetListaFacultades();

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Editar(Software software)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                this.setSoftwareValues(software);
                softwareDataAccess.EditarSoftware(software);

                return RedirectToAction("Index", "Software", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }

        [HttpPost]
        public ActionResult Eliminar(string idSoftware)
        {
            if (SecurityHelper.GetAdministradorID() > 0 && (SecurityHelper.GetAdministradorRol() == "Administrador General"
                    || SecurityHelper.GetAdministradorRol() == "Técnico"
                    || SecurityHelper.GetAdministradorRol() == "Practicante"))
            {
                softwareDataAccess.DeleteSoftwareByIdSoftware(int.Parse(idSoftware));
                return RedirectToAction("Index", "Software", new { Area = "" });
            }
            else
            {
                return RedirectToAction("Index", "Login", new { Area = "" });
            }
        }
    }
}