using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface IHardwareDataAccess
    {
        // Equipos de Computo
        List<Hardware> GetListaEquiposComputo();

        void DeleteEquipoComputoByUsuario(string usuario);

        List<Hardware> GetEquiposComputoByUsuario(string usuario);

        void CreateHardware(List<Hardware> hardwareList);

        void UpdateHardware(List<Hardware> hardwareList);

        // Equipos General
        List<Hardware> GetListaEquiposGeneral();

        Hardware GetHardwareById(int idHardware);
        void DeleteEquipoComputoById(int idHardware);


        // Reporte de Inventario
        List<Hardware> GetListaHardwareByLaboratorioAndTipo(int idLaboratorio, string flgEquipoComputo);

        List<Hardware> GetListaHardwareByLaboratorioAndTipoAndNombreUsuario(int idLaboratorio, string flgEquipoComputo, string nombreUsuario);
    }
}
