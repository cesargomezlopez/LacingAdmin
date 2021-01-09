using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface IAdministradorXLaboratorioDataAccess
    {
        void CreateAdministradorLaboratorio(int idAdministrador, int idLaboratorio);

        void DeleteAdministradorLaboratorio(int idAdministradorLaboratorio);
    }
}
