using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface ILaboratorioDataAccess
    {
        void CreateLaboratorio(Laboratorio laboratorio);
        List<Laboratorio> GetListaLaboratorios();
        Laboratorio GetLaboratorioById(int idLaboratorio);
        void UpdateLaboratorio(Laboratorio laboratorio);
        void DeleteLaboratorio(int idLaboratorio);
        List<AdministradorXLaboratorio> GetListaAdministradoresByIdLaboratorio(int idLaboratorio);
        List<Administrador> GetListaAdministradoresRestantes(int idLaboratorio);
        List<Laboratorio> GetListaLaboratoriosByIdFacultad(int? idFacultad);
        Laboratorio GetLaboratorioByNombreLaboratorio(string nombreLaboratorio);
    }
}
