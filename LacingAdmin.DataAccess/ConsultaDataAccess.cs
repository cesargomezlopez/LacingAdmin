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
    public class ConsultaDataAccess : RepositoryBase, IConsultaDataAccess
    {
        public List<Horario> GetListaHorariosXLaboratorio(int idLaboratorio)
        {
            List<Horario> listaHorarios = new List<Horario>();
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_HORARIOS_X_LABORATORIO]"))
            {
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, idLaboratorio);

                using (IDataReader reader = Database.ExecuteReader(command))
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

                        listaHorarios.Add(horario);
                    }
                }
            }

            return listaHorarios;
        }

        public List<Horario> GetListaHorariosXDocente(int idDocente)
        {
            List<Horario> listaHorarios = new List<Horario>();
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_HORARIOS_X_DOCENTE]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, idDocente);

                using (IDataReader reader = Database.ExecuteReader(command))
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

                        listaHorarios.Add(horario);
                    }
                }
            }

            return listaHorarios;
        }

        public List<Horario> GetListaHorariosXCurso(int idCurso)
        {
            List<Horario> listaHorarios = new List<Horario>();
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_HORARIOS_X_CURSO]"))
            {
                Database.AddInParameter(command, "@ID_CURSO", DbType.Int32, idCurso);

                using (IDataReader reader = Database.ExecuteReader(command))
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

                        listaHorarios.Add(horario);
                    }
                }
            }

            return listaHorarios;
        }
    }
}
