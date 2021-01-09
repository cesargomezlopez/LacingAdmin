using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface IDocenteXCarreraDataAccess
    {
        void CreateDocenteXCarrera(int idDocente, int idCarrera);
        void DeleteDocenteXCarrera(int idDocenteXCarrera);
    }
}
