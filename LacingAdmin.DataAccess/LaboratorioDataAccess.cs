using LacingAdmin.DataAccess.Base;
using LacingAdmin.IDataAccess;
using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.DataAccess
{
    public class LaboratorioDataAccess : RepositoryBase, ILaboratorioDataAccess
    {
        public void CreateLaboratorio(Laboratorio laboratorio)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_LABORATORIO]"))
            {
                Database.AddInParameter(command, "@ID_FACULTAD", DbType.Int32, laboratorio.IdFacultad);
                Database.AddInParameter(command, "@NOMBRE_LABORATORIO", DbType.String, laboratorio.NombreLaboratorio);
                Database.AddInParameter(command, "@ESTADO", DbType.String, laboratorio.Estado);

                Database.ExecuteNonQuery(command);
            }
        }

        public void DeleteLaboratorio(int idLaboratorio)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_LABORATORIO]"))
            {
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, idLaboratorio);

                Database.ExecuteNonQuery(command);
            }
        }

        public Laboratorio GetLaboratorioById(int idLaboratorio)
        {
            Laboratorio laboratorio = new Laboratorio();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LABORATORIO_BY_ID]"))
            {
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, idLaboratorio);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        laboratorio.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                        laboratorio.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        laboratorio.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                        laboratorio.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                    }
                }
            }

            return laboratorio;
        }

        public List<Laboratorio> GetListaLaboratorios()
        {
            List<Laboratorio> listaLaboratorio = new List<Laboratorio>();

            using (IDataReader reader = Database.ExecuteReader("[dbo].[SP_GET_LISTA_LABORATORIOS]"))
            {
                while (reader.Read())
                {
                    Laboratorio laboratorio = new Laboratorio();

                    laboratorio.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                    laboratorio.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                    laboratorio.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                    laboratorio.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                    laboratorio.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);
                    if (laboratorio.Estado == "1")
                    {
                        laboratorio.NombreEstado = "Activo";
                    }
                    else
                    {
                        laboratorio.NombreEstado = "Desactivo";
                    }
                    laboratorio.CantidadAdministradores = DataUtil.DbValueToDefault<int>(reader["cantidadAdministradores"]);

                    listaLaboratorio.Add(laboratorio);
                }
            }

            return listaLaboratorio;
        }

        public List<AdministradorXLaboratorio> GetListaAdministradoresByIdLaboratorio(int idLaboratorio)
        {
            List<AdministradorXLaboratorio> listaAdministradoresXLaboratorio = new List<AdministradorXLaboratorio>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_ADMINISTRADORES_BY_ID_LABORATORIO]"))
            {
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.String, idLaboratorio);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        AdministradorXLaboratorio administradorXLaboratorio = new AdministradorXLaboratorio();

                        administradorXLaboratorio.IdAdministradorXLaboratorio = DataUtil.DbValueToDefault<int>(reader["idAdministradorXLaboratorio"]);
                        administradorXLaboratorio.IdAdministrador = DataUtil.DbValueToDefault<int>(reader["idAdministrador"]);
                        administradorXLaboratorio.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                        administradorXLaboratorio.NombresAdministrador = DataUtil.DbValueToDefault<string>(reader["nombresAdministrador"]);
                        administradorXLaboratorio.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);

                        listaAdministradoresXLaboratorio.Add(administradorXLaboratorio);
                    }
                }
            }
            
            return listaAdministradoresXLaboratorio;
        }

        public List<Administrador> GetListaAdministradoresRestantes(int idLaboratorio)
        {
            List<Administrador> listaAdministradoresRestantes = new List<Administrador>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_ADMINISTRADORES_BY_ID_LABORATORIO_RESTANTES]"))
            {
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.String, idLaboratorio);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Administrador administradorRestante = new Administrador();

                        administradorRestante.IdAdministrador = DataUtil.DbValueToDefault<int>(reader["idAdministrador"]);
                        administradorRestante.NombreCompleto = DataUtil.DbValueToDefault<string>(reader["nombresAdministrador"]);

                        listaAdministradoresRestantes.Add(administradorRestante);
                    }
                }
            }

            return listaAdministradoresRestantes;
        }

        public void UpdateLaboratorio(Laboratorio laboratorio)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_LABORATORIO]"))
            {
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, laboratorio.IdLaboratorio);
                Database.AddInParameter(command, "@ID_FACULTAD", DbType.Int32, laboratorio.IdFacultad);
                Database.AddInParameter(command, "@NOMBRE_LABORATORIO", DbType.String, laboratorio.NombreLaboratorio);
                Database.AddInParameter(command, "@ESTADO", DbType.String, laboratorio.Estado);

                Database.ExecuteNonQuery(command);
            }
        }

        public List<Laboratorio> GetListaLaboratoriosByIdFacultad(int? idFacultad)
        {
            List<Laboratorio> listaLaboratorio = new List<Laboratorio>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_LABORATORIOS_BY_ID_FACULTAD]"))
            {
                Database.AddInParameter(command, "@ID_FACULTAD", DbType.Int32, idFacultad);
                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Laboratorio laboratorio = new Laboratorio();

                        laboratorio.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                        laboratorio.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        laboratorio.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                        laboratorio.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);

                        listaLaboratorio.Add(laboratorio);
                    }
                }
            }

            return listaLaboratorio;
        }

        public Laboratorio GetLaboratorioByNombreLaboratorio(string nombreLaboratorio)
        {
            Laboratorio laboratorio = new Laboratorio();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LABORATORIO_BY_NOMBRE_LABORATORIO]"))
            {
                Database.AddInParameter(command, "@NOMBRE_LABORATORIO", DbType.String, nombreLaboratorio);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        laboratorio.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                        laboratorio.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        laboratorio.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                        laboratorio.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                    }
                }
            }

            return laboratorio;
        }
    }
}
