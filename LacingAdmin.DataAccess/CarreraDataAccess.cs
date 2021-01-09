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
    public class CarreraDataAccess : RepositoryBase, ICarreraDataAccess
    {
        public void CreateCarrera(Carrera carrera)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_CARRERA]"))
            {
                Database.AddInParameter(command, "@ID_FACULTAD", DbType.Int32, carrera.IdFacultad);
                Database.AddInParameter(command, "@NOMBRE_CARRERA", DbType.String, carrera.NombreCarrera);

                Database.ExecuteNonQuery(command);
            }
        }

        public void DeleteCarrera(int idCarrera)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_CARRERA]"))
            {
                Database.AddInParameter(command, "@ID_CARRERA", DbType.Int32, idCarrera);

                Database.ExecuteNonQuery(command);
            }
        }

        public Carrera GetCarreraById(int idCarrera)
        {
            Carrera carrera = new Carrera();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_CARRERA_BY_ID]"))
            {
                Database.AddInParameter(command, "@ID_CARRERA", DbType.Int32, idCarrera);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        carrera.IdCarrera = DataUtil.DbValueToDefault<int>(reader["idCarrera"]);
                        carrera.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        carrera.NombreCarrera = DataUtil.DbValueToDefault<string>(reader["nombreCarrera"]);
                    }
                }
            }

            return carrera;
        }

        public List<Carrera> GetListaCarreras()
        {
            List<Carrera> listaCarreras = new List<Carrera>();

            using (IDataReader reader = Database.ExecuteReader("[dbo].[SP_GET_LISTA_CARRERAS]"))
            {
                while (reader.Read())
                {
                    Carrera carrera = new Carrera();

                    carrera.IdCarrera = DataUtil.DbValueToDefault<int>(reader["idCarrera"]);
                    carrera.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                    carrera.NombreCarrera = DataUtil.DbValueToDefault<string>(reader["nombreCarrera"]);
                    carrera.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);

                    listaCarreras.Add(carrera);
                }
            }

            return listaCarreras;
        }

        public List<Carrera> GetListaCarrerasByIdFacultad(int? idFacultad)
        {
            List<Carrera> listaCarreras = new List<Carrera>();
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_CARRERAS_BY_ID_FACULTAD]"))
            {
                Database.AddInParameter(command, "@ID_FACULTAD", DbType.Int32, idFacultad);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Carrera carrera = new Carrera();

                        carrera.IdCarrera = DataUtil.DbValueToDefault<int>(reader["idCarrera"]);
                        carrera.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        carrera.NombreCarrera = DataUtil.DbValueToDefault<string>(reader["nombreCarrera"]);

                        listaCarreras.Add(carrera);
                    }
                }
            }
            
            return listaCarreras;
        }

        public void UpdateCarrera(Carrera carrera)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_CARRERA]"))
            {
                Database.AddInParameter(command, "@ID_CARRERA", DbType.Int32, carrera.IdCarrera);
                Database.AddInParameter(command, "@ID_FACULTAD", DbType.Int32, carrera.IdFacultad);
                Database.AddInParameter(command, "@NOMBRE_CARRERA", DbType.String, carrera.NombreCarrera);

                Database.ExecuteNonQuery(command);
            }
        }

        public Carrera GetCarreraByNombreCarrera(string nombreCarrera)
        {
            Carrera carrera = new Carrera();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_CARRERA_BY_NOMBRE_CARRERA]"))
            {
                Database.AddInParameter(command, "@NOMBRE_CARRERA", DbType.String, nombreCarrera);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        carrera.IdCarrera = DataUtil.DbValueToDefault<int>(reader["idCarrera"]);
                        carrera.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        carrera.NombreCarrera = DataUtil.DbValueToDefault<string>(reader["nombreCarrera"]);
                    }
                }
            }

            return carrera;
        }
    }
}
