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
    public class ObservacionXHardwareDataAccess : RepositoryBase, IObservacionXHardwareDataAccess
    {
        public void CreateObservacionTipoSoftware(ObservacionXHardware observacionXHardware)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_OBSERVACION_TIPO_SOFTWARE]"))
            {
                Database.AddInParameter(command, "@ID_HARDWARE", DbType.Int32, observacionXHardware.IdHardware);
                Database.AddInParameter(command, "@TIPO", DbType.String, "Software");
                Database.AddInParameter(command, "@OBSERVACION", DbType.String, observacionXHardware.Observacion);
                Database.AddInParameter(command, "@NOMBRE_SOFTWARE", DbType.String, observacionXHardware.NombreSoftware);
                Database.AddInParameter(command, "@VERSION_SOFTWARE", DbType.String, observacionXHardware.VersionSoftware);
                Database.AddInParameter(command, "@TIPO_SOFTWARE", DbType.String, observacionXHardware.TipoSoftware);

                Database.ExecuteNonQuery(command);
            }
        }

        public void CreateObservacionTipoHardware(ObservacionXHardware observacionXHardware)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_OBSERVACION_TIPO_HARDWARE]"))
            {
                Database.AddInParameter(command, "@ID_HARDWARE", DbType.Int32, observacionXHardware.IdHardware);
                Database.AddInParameter(command, "@TIPO", DbType.String, "Hardware");
                Database.AddInParameter(command, "@OBSERVACION", DbType.String, observacionXHardware.Observacion);

                Database.ExecuteNonQuery(command);
            }
        }

        public void CreateObservacionTipoEquipoGeneral(ObservacionXHardware observacionXHardware)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_OBSERVACION_TIPO_HARDWARE]"))
            {
                Database.AddInParameter(command, "@ID_HARDWARE", DbType.Int32, observacionXHardware.IdHardware);
                Database.AddInParameter(command, "@TIPO", DbType.String, "EquipoGeneral");
                Database.AddInParameter(command, "@OBSERVACION", DbType.String, observacionXHardware.Observacion);

                Database.ExecuteNonQuery(command);
            }
        }

        public void DeleteObservacion(int idObservacion)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_OBSERVACION_HARDWARE]"))
            {
                Database.AddInParameter(command, "@ID_OBSERVACION", DbType.Int32, idObservacion);

                Database.ExecuteNonQuery(command);
            }
        }

        public void UpdateObservacionTipoHardware(ObservacionXHardware observacionXHardware)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_OBSERVACION_TIPO_HARDWARE]"))
            {
                Database.AddInParameter(command, "@ID_OBSERVACION_X_HARDWARE", DbType.Int32, observacionXHardware.IdObservacionXHardware);
                Database.AddInParameter(command, "@OBSERVACION", DbType.String, observacionXHardware.Observacion);

                Database.ExecuteNonQuery(command);
            }
        }

        public void UpdateObservacionTipoSoftware(ObservacionXHardware observacionXHardware)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_OBSERVACION_TIPO_SOFTWARE]"))
            {
                Database.AddInParameter(command, "@ID_OBSERVACION_X_HARDWARE", DbType.Int32, observacionXHardware.IdObservacionXHardware);
                Database.AddInParameter(command, "@OBSERVACION", DbType.String, observacionXHardware.Observacion);
                Database.AddInParameter(command, "@NOMBRE_SOFTWARE", DbType.String, observacionXHardware.NombreSoftware);
                Database.AddInParameter(command, "@VERSION_SOFTWARE", DbType.String, observacionXHardware.VersionSoftware);
                Database.AddInParameter(command, "@TIPO_SOFTWARE", DbType.String, observacionXHardware.TipoSoftware);

                Database.ExecuteNonQuery(command);
            }
        }

        public List<ObservacionXHardware> GetListaObservacionesXHardwareByIdAndTipo(int idHardware, string tipo)
        {
            List<ObservacionXHardware> listaObservaciones = new List<ObservacionXHardware>();
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_OBSERVACIONES_HARDWARE_BY_ID_AND_TIPO]"))
            {
                Database.AddInParameter(command, "@ID_HARDWARE", DbType.Int32, idHardware);
                Database.AddInParameter(command, "@TIPO", DbType.String, tipo);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        ObservacionXHardware observacion = new ObservacionXHardware();

                        observacion.IdObservacionXHardware = DataUtil.DbValueToDefault<int>(reader["idObservacionXHardware"]);
                        observacion.IdHardware = DataUtil.DbValueToDefault<int>(reader["idHardware"]);
                        observacion.Tipo = DataUtil.DbValueToDefault<string>(reader["tipo"]);
                        observacion.Observacion = DataUtil.DbValueToDefault<string>(reader["observacion"]);
                        observacion.Fecha = DataUtil.DbValueToDefault<DateTime>(reader["fecha"]);
                        if (tipo.Equals("Software"))
                        {
                            observacion.NombreSoftware = DataUtil.DbValueToDefault<string>(reader["nombreSoftware"]);
                            observacion.VersionSoftware = DataUtil.DbValueToDefault<string>(reader["versionSoftware"]);
                            observacion.TipoSoftware = DataUtil.DbValueToDefault<string>(reader["tipoSoftware"]);

                        }
                        listaObservaciones.Add(observacion);
                    }
                }
            }

            return listaObservaciones;
        }
    }
}