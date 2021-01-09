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
    public class HorarioDataAccess : RepositoryBase, IHorarioDataAccess
    {
        public void CreateHorario(Horario horario)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_HORARIO]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, horario.IdDocente);
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, horario.IdLaboratorio);
                Database.AddInParameter(command, "@ID_SUBGRUPO", DbType.Int32, horario.IdSubgrupo);
                Database.AddInParameter(command, "@DIA", DbType.Int32, horario.Dia);
                Database.AddInParameter(command, "@HORAS", DbType.Int32, horario.Horas);
                Database.AddInParameter(command, "@HORA_INICIO", DbType.String, horario.HoraInicio);
                Database.AddInParameter(command, "@HORA_FIN", DbType.String, horario.HoraFin);
                Database.AddInParameter(command, "@FECHA_RECUPERACION", DbType.DateTime, horario.FechaRecuperacion);
                Database.AddInParameter(command, "@MINUTOS_HORA", DbType.Int32, horario.MinutosHora);

                Database.ExecuteNonQuery(command);
            }
        }

        public void DeleteHorario(int idHorario)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_HORARIO]"))
            {
                Database.AddInParameter(command, "@ID_HORARIO", DbType.Int32, idHorario);

                Database.ExecuteNonQuery(command);
            }
        }

        public Horario GetHorarioById(int idHorario)
        {
            Horario horario = new Horario();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_HORARIO_BY_ID]"))
            {
                Database.AddInParameter(command, "@ID_HORARIO", DbType.Int32, idHorario);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        horario.IdHorario = DataUtil.DbValueToDefault<int>(reader["idHorario"]);
                        horario.IdDocente = DataUtil.DbValueToDefault<int>(reader["idDocente"]);
                        horario.NombreDocente = DataUtil.DbValueToDefault<string>(reader["nombreDocente"]);
                        horario.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                        horario.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                        horario.IdSubgrupo = DataUtil.DbValueToDefault<int>(reader["idSubgrupo"]);
                        horario.NumeroSubgrupo = DataUtil.DbValueToDefault<string>(reader["numeroSubgrupo"]);
                        horario.TipoSubgrupo = DataUtil.DbValueToDefault<string>(reader["tipoSubgrupo"]);
                        horario.IdGrupo = DataUtil.DbValueToDefault<int>(reader["idGrupo"]);
                        horario.NumeroGrupo = DataUtil.DbValueToDefault<string>(reader["numeroGrupo"]);
                        horario.IdCurso = DataUtil.DbValueToDefault<int>(reader["idCurso"]);
                        horario.CodigoCurso = DataUtil.DbValueToDefault<string>(reader["codigoCurso"]);
                        horario.NombreCurso = DataUtil.DbValueToDefault<string>(reader["nombreCurso"]);
                        horario.NumeroCiclo = DataUtil.DbValueToDefault<string>(reader["numeroCiclo"]);
                        horario.NumeroMalla = DataUtil.DbValueToDefault<string>(reader["numeroMalla"]);
                        horario.IdCarrera = DataUtil.DbValueToDefault<int>(reader["idCarrera"]);
                        horario.NombreCarrera = DataUtil.DbValueToDefault<string>(reader["nombreCarrera"]);
                        horario.IdFacultadLaboratorio = DataUtil.DbValueToDefault<int>(reader["idFacultadLaboratorio"]);
                        horario.IdFacultadCurso = DataUtil.DbValueToDefault<int>(reader["idFacultadCurso"]);
                        horario.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);
                        horario.Dia = DataUtil.DbValueToDefault<int>(reader["dia"]);
                        horario.Horas = DataUtil.DbValueToDefault<int>(reader["horas"]);
                        horario.HoraInicio = DataUtil.DbValueToDefault<TimeSpan>(reader["horaInicio"]).ToString(@"hh\:mm");
                        horario.HoraFin = DataUtil.DbValueToDefault<TimeSpan>(reader["horaFin"]).ToString(@"hh\:mm");
                        horario.FechaRecuperacion = DataUtil.DbValueToDefault<DateTime>(reader["fechaRecuperacion"]);
                        horario.MinutosHora = DataUtil.DbValueToDefault<int>(reader["minutosHora"]);
                        //horario.TipoCiclo = DataUtil.DbValueToDefault<string>(reader["tipoCiclo"]);

                    }
                }
            }
            
            return horario;
        }

        public List<Horario> GetListaHorarios()
        {
            List<Horario> listaHorarios = new List<Horario>();

            using (IDataReader reader =  Database.ExecuteReader("[dbo].[SP_GET_LISTA_HORARIOS]"))
            {
                while (reader.Read())
                {
                    Horario horario = new Horario();

                    horario.IdHorario = DataUtil.DbValueToDefault<int>(reader["idHorario"]);
                    horario.IdDocente = DataUtil.DbValueToDefault<int>(reader["idDocente"]);
                    horario.NombreDocente = DataUtil.DbValueToDefault<string>(reader["nombreDocente"]);
                    horario.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                    horario.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                    horario.IdSubgrupo = DataUtil.DbValueToDefault<int>(reader["idSubgrupo"]);
                    horario.NumeroSubgrupo = DataUtil.DbValueToDefault<string>(reader["numeroSubgrupo"]);
                    horario.TipoSubgrupo = DataUtil.DbValueToDefault<string>(reader["tipoSubgrupo"]);
                    horario.IdGrupo = DataUtil.DbValueToDefault<int>(reader["idGrupo"]);
                    horario.NumeroGrupo = DataUtil.DbValueToDefault<string>(reader["numeroGrupo"]);
                    horario.IdCurso = DataUtil.DbValueToDefault<int>(reader["idCurso"]);
                    horario.CodigoCurso = DataUtil.DbValueToDefault<string>(reader["codigoCurso"]);
                    horario.NombreCurso = DataUtil.DbValueToDefault<string>(reader["nombreCurso"]);
                    horario.NumeroCiclo = DataUtil.DbValueToDefault<string>(reader["numeroCiclo"]);
                    horario.NumeroMalla = DataUtil.DbValueToDefault<string>(reader["numeroMalla"]);
                    horario.IdCarrera = DataUtil.DbValueToDefault<int>(reader["idCarrera"]);
                    horario.NombreCarrera = DataUtil.DbValueToDefault<string>(reader["nombreCarrera"]);
                    horario.IdFacultadLaboratorio = DataUtil.DbValueToDefault<int>(reader["idFacultadLaboratorio"]);
                    horario.IdFacultadCurso = DataUtil.DbValueToDefault<int>(reader["idFacultadCurso"]);
                    horario.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);
                    horario.Dia = DataUtil.DbValueToDefault<int>(reader["dia"]);
                    horario.Horas = DataUtil.DbValueToDefault<int>(reader["horas"]);
                    horario.HoraInicio = DataUtil.DbValueToDefault<TimeSpan>(reader["horaInicio"]).ToString(@"hh\:mm");
                    horario.HoraFin = DataUtil.DbValueToDefault<TimeSpan>(reader["horaFin"]).ToString(@"hh\:mm");
                    horario.FechaRecuperacion = DataUtil.DbValueToDefault<DateTime>(reader["fechaRecuperacion"]);
                    //horario.TipoCiclo = DataUtil.DbValueToDefault<string>(reader["tipoCiclo"]);

                    listaHorarios.Add(horario);
                }
            }

            return listaHorarios;
        }

        public void UpdateHorario(Horario horario)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_HORARIO]"))
            {
                Database.AddInParameter(command, "@ID_HORARIO", DbType.Int32, horario.IdHorario);
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, horario.IdDocente);
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, horario.IdLaboratorio);
                Database.AddInParameter(command, "@ID_SUBGRUPO", DbType.Int32, horario.IdSubgrupo);
                Database.AddInParameter(command, "@DIA", DbType.Int32, horario.Dia);
                Database.AddInParameter(command, "@HORAS", DbType.Int32, horario.Horas);
                Database.AddInParameter(command, "@HORA_INICIO", DbType.String, horario.HoraInicio);
                Database.AddInParameter(command, "@HORA_FIN", DbType.String, horario.HoraFin);
                Database.AddInParameter(command, "@FECHA_RECUPERACION", DbType.DateTime, horario.FechaRecuperacion);
                Database.AddInParameter(command, "@MINUTOS_HORA", DbType.Int32, horario.MinutosHora);

                Database.ExecuteNonQuery(command);
            }
        }

        public int GetHorarioExiste(int idLaboratorio, int dia, string horaInicio, string horaFin, int idHorario)
        {
            int cantidad = 0;

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_HORARIO_EXISTE]"))
            {
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, idLaboratorio);
                Database.AddInParameter(command, "@DIA", DbType.Int32, dia);
                Database.AddInParameter(command, "@HORA_INICIO", DbType.String, horaInicio);
                Database.AddInParameter(command, "@HORA_FIN", DbType.String, horaFin);
                Database.AddInParameter(command, "@ID_HORARIO", DbType.String, idHorario);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        cantidad = int.Parse(reader[0].ToString());
                    }
                }
            }

            return cantidad;

        }
    }
}
