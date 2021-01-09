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
    public class ReporteDataAccess : RepositoryBase, IReporteDataAccess
    {
        public List<ReporteGeneral> GetReporteGeneral(DateTime dateInicio, DateTime dateFin, int? idDocente)
        {
            List<ReporteGeneral> listaReporte = new List<ReporteGeneral>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_REPORTE_GENERAL]"))
            {
                Database.AddInParameter(command, "@FECHA_INICIO", DbType.Date, dateInicio.ToString("dd/MM/yyyy"));
                Database.AddInParameter(command, "@FECHA_FIN", DbType.Date, dateFin.ToString("dd/MM/yyyy"));
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, idDocente);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        ReporteGeneral reporte = new ReporteGeneral();

                        reporte.Fecha = DataUtil.DbValueToDefault<DateTime>(reader["FECHA"]).ToString("dd/MM/yyyy");
                        reporte.Laboratorio = DataUtil.DbValueToDefault<string>(reader["LABORATORIO"]);
                        reporte.Docente = DataUtil.DbValueToDefault<string>(reader["APELLIDOSYNOMBRES"]);
                        reporte.Curso = DataUtil.DbValueToDefault<string>(reader["CURSO"]);
                        reporte.Carrera = DataUtil.DbValueToDefault<string>(reader["CARRERA"]);
                        reporte.HoraInicio = DataUtil.DbValueToDefault<TimeSpan>(reader["HORA_INICIO"]).ToString(@"hh\:mm");
                        if (reader["HORA_INGRESO"].ToString() == "")
                        {
                            reporte.HoraIngreso = "";
                        }
                        else
                        {
                            reporte.HoraIngreso = DataUtil.DbValueToDefault<TimeSpan>(reader["HORA_INGRESO"]).ToString(@"hh\:mm");
                        }
                        reporte.HoraFin = DataUtil.DbValueToDefault<TimeSpan>(reader["HORA_FIN"]).ToString(@"hh\:mm");
                        if (reader["HORA_SALIDA"].ToString() == "")
                        {
                            reporte.HoraSalida = "";
                        }
                        else
                        {
                            reporte.HoraSalida = DataUtil.DbValueToDefault<TimeSpan>(reader["HORA_SALIDA"]).ToString(@"hh\:mm");
                        }                        
                        reporte.Estado = DataUtil.DbValueToDefault<string>(reader["ESTADO"]);
                        reporte.Observacion = DataUtil.DbValueToDefault<string>(reader["OBSERVACIONES"]);
                        reporte.Tipo = DataUtil.DbValueToDefault<string>(reader["TIPO"]);
                        reporte.DiferenciaEntrada = DataUtil.DbValueToDefault<int>(reader["DIFERENCIA_ENTRADA"]);

                        listaReporte.Add(reporte);
                    }
                }
            }

            return listaReporte;
        }
    }
}
