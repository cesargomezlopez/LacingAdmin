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
    public class FacultadDataAccess : RepositoryBase, IFacultadDataAccess
    {
        public void CreateFacultad(Facultad facultad)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_FACULTAD]"))
            {
                Database.AddInParameter(command, "@NOMBRE_FACULTAD", DbType.String, facultad.NombreFacultad);
                Database.AddInParameter(command, "@ESTADO", DbType.String, facultad.Estado);

                Database.ExecuteNonQuery(command);
            }
        }

        public void DeleteFacultad(int idFacultad)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_FACULTAD]"))
            {
                Database.AddInParameter(command, "@ID_FACULTAD", DbType.Int32, idFacultad);

                Database.ExecuteNonQuery(command);
            }
        }

        public Facultad GetFacultadById(int idFacultad)
        {
            Facultad facultad = new Facultad();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_FACULTAD_BY_ID]"))
            {
                Database.AddInParameter(command, "@ID_FACULTAD", DbType.Int32, idFacultad);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        facultad.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        facultad.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);
                        facultad.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                    }
                }
            }

            return facultad;
        }

        public List<Facultad> GetListaFacultades()
        {
            List<Facultad> listaFacultad = new List<Facultad>();

            using (IDataReader reader = Database.ExecuteReader("[dbo].[SP_GET_LISTA_FACULTADES]"))
            {
                while (reader.Read())   
                {
                    Facultad facultad = new Facultad();

                    facultad.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                    facultad.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);
                    facultad.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                    if (facultad.Estado == "1")
                    {
                        facultad.NombreEstado = "Activo";
                    }
                    else
                    {
                        facultad.NombreEstado = "Desactivo";
                    }

                    listaFacultad.Add(facultad);
                }
            }

            return listaFacultad;
        }

        public void UpdateFacultad(Facultad facultad)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_FACULTAD]"))
            {
                Database.AddInParameter(command, "@ID_FACULTAD", DbType.Int32, facultad.IdFacultad);
                Database.AddInParameter(command, "@NOMBRE_FACULTAD", DbType.String, facultad.NombreFacultad);
                Database.AddInParameter(command, "@ESTADO", DbType.String, facultad.Estado);

                Database.ExecuteNonQuery(command);
            }
        }

        public Facultad GetFacultadByNombreFacultad(string nombreFacultad)
        {
            Facultad facultad = new Facultad();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_FACULTAD_BY_NOMBRE_FACULTAD]"))
            {
                Database.AddInParameter(command, "@NOMBRE_FACULTAD", DbType.String, nombreFacultad);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        facultad.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        facultad.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);
                        facultad.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                    }
                }
            }

            return facultad;
        }
    }
}
