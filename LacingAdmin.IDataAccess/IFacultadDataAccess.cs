using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface IFacultadDataAccess
    {
        void CreateFacultad(Facultad facultad);
        List<Facultad> GetListaFacultades();
        Facultad GetFacultadById(int idFacultad);
        void UpdateFacultad(Facultad facultad);
        void DeleteFacultad(int idFacultad);
        Facultad GetFacultadByNombreFacultad(string nombreFacultad);
    }
}
