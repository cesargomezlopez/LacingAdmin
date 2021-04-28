using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using LacingAdmin.IDataAccess;
using LacingAdmin.DataAccess;

namespace LacingAdmin.Web.App_Start
{
    public static class DIConfig
    {
        public static void ConfigureInjector()
        {
            var container = new Container();

            container.Options.DefaultLifestyle = new WebRequestLifestyle();
            container.Register<IAdministradorDataAccess, AdministradorDataAccess>();
            container.Register<IFacultadDataAccess, FacultadDataAccess>();
            container.Register<ICarreraDataAccess, CarreraDataAccess>();
            container.Register<ILaboratorioDataAccess, LaboratorioDataAccess>();
            container.Register<ICursoDataAccess, CursoDataAccess>();
            container.Register<IDocenteDataAccess, DocenteDataAccess>();
            container.Register<IAdministradorXLaboratorioDataAccess, AdministradorXLaboratorioDataAccess>();
            container.Register<IDocenteXCarreraDataAccess, DocenteXCarrerDataAccess>();
            container.Register<IHorarioDataAccess, HorarioDataAccess>();
            container.Register<IAlumnoDataAccess, AlumnoDataAccess>();
            container.Register<IAsistenciaDataAccess, AsistenciaDataAccess>();
            container.Register<IReporteDataAccess, ReporteDataAccess>();
            container.Register<IConsultaDataAccess, ConsultaDataAccess>();
            container.Register<IHardwareDataAccess, HardwareDataAccess>();
            container.Register<ISoftwareDataAccess, SoftwareDataAccess>();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}