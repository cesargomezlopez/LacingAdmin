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
    public class DocenteXCarrerDataAccess : RepositoryBase, IDocenteXCarreraDataAccess
    {
        public void CreateDocenteXCarrera(int idDocente, int idCarrera)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_DOCENTE_X_CARRERA]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, idDocente);
                Database.AddInParameter(command, "@ID_CARRERA", DbType.Int32, idCarrera);

                Database.ExecuteNonQuery(command);
            }
        }

        public void DeleteDocenteXCarrera(int idDocenteXCarrera)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_DOCENTE_X_CARRERA]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE_CARRERA", DbType.Int32, idDocenteXCarrera);

                Database.ExecuteNonQuery(command);
            }
        }
    }
}
