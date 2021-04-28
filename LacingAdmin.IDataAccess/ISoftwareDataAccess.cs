using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface ISoftwareDataAccess
    {
        List<Software> GetListaSoftwares();
        List<SoftwareXLaboratorio> GetListaSoftwareXLaboratorioByIdSoftware(int idSoftware);
        List<SoftwareXCarrera> GetListaSoftwareXCarreraByIdSoftware(int idSoftware);
        void DeleteSoftwareByIdSoftware(int idSoftware);
        void CreateSoftware(Software software);
        void EditarSoftware(Software software);
        Software GetSoftwareById(int idSoftware);

        #region Report Methods
        List<Software> GetListaSoftwareByIdFacultad(int idFacultad);
        List<Software> GetListaSoftwareByIdLaboratorio(int idLaboratorio);
        List<Software> GetListaSoftwareByNombre(string nombreSoftware);
        List<Software> GetListaSoftwareByTipo(string tipoSoftware);
        #endregion
    }
}
