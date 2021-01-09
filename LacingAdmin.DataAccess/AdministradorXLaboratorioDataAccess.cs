using LacingAdmin.DataAccess.Base;
using LacingAdmin.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.DataAccess
{
    public class AdministradorXLaboratorioDataAccess : RepositoryBase, IAdministradorXLaboratorioDataAccess
    {
        public void CreateAdministradorLaboratorio(int idAdministrador, int idLaboratorio)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_ADMINISTRADOR_X_LABORATORIO]"))
            {
                Database.AddInParameter(command, "@ID_ADMINISTRADOR", DbType.Int32, idAdministrador);
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, idLaboratorio);

                Database.ExecuteNonQuery(command);
            }
        }

        public void DeleteAdministradorLaboratorio(int idAdministradorLaboratorio)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_ADMINISTRADOR_LABORATORIO]"))
            {
                Database.AddInParameter(command, "@ID_ADMINISTRADOR_LABORATORIO", DbType.Int32, idAdministradorLaboratorio);

                Database.ExecuteNonQuery(command);
            }
        }
    }
}
