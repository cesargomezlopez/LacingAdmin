using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface IAdministradorDataAccess
    {
        Administrador GetAdministradorByNombreUsuario(string nombreUsuario);
        List<Administrador> GetListaAdministradores();
        void CreateAdministrador(Administrador administrador);
        void UpdateAdministrador(Administrador administrador);
        void DeleteAdministrador(int idAdministrador);
    }
}
