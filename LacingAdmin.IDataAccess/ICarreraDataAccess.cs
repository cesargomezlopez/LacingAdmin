using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface ICarreraDataAccess
    {
        void CreateCarrera(Carrera carrera);
        List<Carrera> GetListaCarreras();
        Carrera GetCarreraById(int idCarrera);
        void UpdateCarrera(Carrera carrera);
        void DeleteCarrera(int idCarrera);
        List<Carrera> GetListaCarrerasByIdFacultad(int? idFacultad);
        Carrera GetCarreraByNombreCarrera(string nombreCarrera);
    }
}
