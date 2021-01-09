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
    public class AlumnoDataAccess : RepositoryBase, IAlumnoDataAccess
    {
        #region Administrador
        public void CreateAlumno(Alumno alumno)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_ALUMNO]"))
            {
                Database.AddInParameter(command, "@NOMBRE_USUARIO", DbType.String, alumno.NombreUsuario);
                Database.AddInParameter(command, "@CONTRASEÑA", DbType.String, alumno.Contraseña);
                Database.AddInParameter(command, "@NOMBRES", DbType.String, alumno.Nombres);
                Database.AddInParameter(command, "@PATERNO", DbType.String, alumno.Paterno);
                Database.AddInParameter(command, "@MATERNO", DbType.String, alumno.Materno);

                Database.ExecuteNonQuery(command);
            }
        }

        public void DeleteAlumno(int idAlumno)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_ALUMNO]"))
            {
                Database.AddInParameter(command, "@ID_ALUMNO", DbType.Int32, idAlumno);

                Database.ExecuteNonQuery(command);
            }
        }

        public Alumno GetAlumnoById(int idAlumno)
        {
            Alumno alumno = new Alumno();
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_ALUMNO_BY_ID]"))
            {
                Database.AddInParameter(command, "@ID_ALUMNO", DbType.Int32, idAlumno);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        alumno.IdAlumno = DataUtil.DbValueToDefault<int>(reader["idAlumno"]);
                        alumno.NombreUsuario = DataUtil.DbValueToDefault<string>(reader["nombreUsuario"]);
                        alumno.Contraseña = DataUtil.DbValueToDefault<string>(reader["contraseña"]);
                        alumno.Nombres = DataUtil.DbValueToDefault<string>(reader["nombres"]);
                        alumno.Paterno = DataUtil.DbValueToDefault<string>(reader["paterno"]);
                        alumno.Materno = DataUtil.DbValueToDefault<string>(reader["materno"]);

                        alumno.NombreCompleto = alumno.Paterno + " " + alumno.Materno + ", " + alumno.Nombres;
                    }
                }
            }

            return alumno;
        }

        public List<Alumno> GetListaAlumno()
        {
            List<Alumno> listaAlumnos = new List<Alumno>();

            using (IDataReader reader = Database.ExecuteReader("[dbo].[SP_GET_LISTA_ALUMNOS]"))
            {
                while (reader.Read())
                {
                    Alumno alumno = new Alumno();

                    alumno.IdAlumno = DataUtil.DbValueToDefault<int>(reader["idAlumno"]);
                    alumno.NombreUsuario = DataUtil.DbValueToDefault<string>(reader["nombreUsuario"]);
                    alumno.Contraseña = DataUtil.DbValueToDefault<string>(reader["contraseña"]);
                    alumno.Nombres = DataUtil.DbValueToDefault<string>(reader["nombres"]);
                    alumno.Paterno = DataUtil.DbValueToDefault<string>(reader["paterno"]);
                    alumno.Materno = DataUtil.DbValueToDefault<string>(reader["materno"]);

                    alumno.NombreCompleto = alumno.Paterno + " " + alumno.Materno + ", " + alumno.Nombres;

                    listaAlumnos.Add(alumno);
                }
            }

            return listaAlumnos;
        }

        public void UpdateAlumno(Alumno alumno)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_ALUMNO]"))
            {
                Database.AddInParameter(command, "@ID_ALUMNO", DbType.String, alumno.IdAlumno);
                Database.AddInParameter(command, "@NOMBRE_USUARIO", DbType.String, alumno.NombreUsuario);
                Database.AddInParameter(command, "@CONTRASEÑA", DbType.String, alumno.Contraseña);
                Database.AddInParameter(command, "@NOMBRES", DbType.String, alumno.Nombres);
                Database.AddInParameter(command, "@PATERNO", DbType.String, alumno.Paterno);
                Database.AddInParameter(command, "@MATERNO", DbType.String, alumno.Materno);

                Database.ExecuteNonQuery(command);
            }
        }

        #endregion

        #region Alumno
        public Alumno GetAlumnoByNombreUsuario(string nombreUsuario)
        {
            Alumno alumno = new Alumno();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_ALUMNO_BY_NOMBRE_USUARIO]"))
            {
                Database.AddInParameter(command, "@NOMBRE_USUARIO", DbType.String, nombreUsuario);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        alumno.IdAlumno = DataUtil.DbValueToDefault<int>(reader["idAlumno"]);
                        alumno.NombreUsuario = DataUtil.DbValueToDefault<string>(reader["nombreUsuario"]);
                        alumno.Contraseña = DataUtil.DbValueToDefault<string>(reader["contraseña"]);
                        alumno.Nombres = DataUtil.DbValueToDefault<string>(reader["nombres"]);
                        alumno.Paterno = DataUtil.DbValueToDefault<string>(reader["paterno"]);
                        alumno.Materno = DataUtil.DbValueToDefault<string>(reader["materno"]);
                    }
                }
            }

            return alumno;
        }

        public List<Horario> GetListaHorariosAlumno(int idAlumno)
        {
            List<Horario> listaHorarios = new List<Horario>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_CURSOS_BY_ID_ALUMNO]"))
            {
                Database.AddInParameter(command, "@ID_ALUMNO", DbType.Int32, idAlumno);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Horario horario = new Horario();

                        horario.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                        horario.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                        horario.IdCurso = DataUtil.DbValueToDefault<int>(reader["idCurso"]);
                        horario.CodigoCurso = DataUtil.DbValueToDefault<string>(reader["codigoCurso"]);
                        horario.NombreCurso = DataUtil.DbValueToDefault<string>(reader["nombreCurso"]);
                        horario.IdGrupo = DataUtil.DbValueToDefault<int>(reader["idGrupo"]);
                        horario.NumeroGrupo = DataUtil.DbValueToDefault<string>(reader["numeroGrupo"]);
                        horario.IdSubgrupo = DataUtil.DbValueToDefault<int>(reader["idSubgrupo"]);
                        horario.NumeroSubgrupo = DataUtil.DbValueToDefault<string>(reader["numeroSubgrupo"]);
                        horario.TipoSubgrupo = DataUtil.DbValueToDefault<string>(reader["tipoSubgrupo"]);
                        horario.NombreDocente = DataUtil.DbValueToDefault<string>(reader["nombresDocente"]);
                        horario.IdHorario = DataUtil.DbValueToDefault<int>(reader["idHorario"]);
                        horario.Dia = DataUtil.DbValueToDefault<int>(reader["dia"]);
                        horario.HoraInicio = DataUtil.DbValueToDefault<TimeSpan>(reader["horaInicio"]).ToString("hh\\:mm");
                        horario.HoraFin = DataUtil.DbValueToDefault<TimeSpan>(reader["horaFin"]).ToString("hh\\:mm");
                        horario.FlagAsistenciaPendiente = DataUtil.DbValueToDefault<int>(reader["flagAsistenciaPendiente"]);

                        listaHorarios.Add(horario);
                    }
                }                
            }

            return listaHorarios;
        }

        public List<Asistencia> GetListaAsistenciasAlumno(int idAlumno)
        {
            List<Asistencia> listaAsistencias = new List<Asistencia>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_ASISTENCIAS_BY_ID_ALUMNO]"))
            {
                Database.AddInParameter(command, "@ID_ALUMNO", DbType.Int32, idAlumno);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Asistencia asistencia = new Asistencia();

                        asistencia.IdAsistencia = DataUtil.DbValueToDefault<int>(reader["idAsistencia"]);
                        asistencia.TipoAsistencia = DataUtil.DbValueToDefault<int>(reader["tipoAsistencia"]);
                        asistencia.IdHorario = DataUtil.DbValueToDefault<int>(reader["idHorario"]);
                        asistencia.Dia = DataUtil.DbValueToDefault<int>(reader["dia"]);
                        asistencia.FechaRegistro = DataUtil.DbValueToDefault<DateTime>(reader["fechaRegistro"]);
                        asistencia.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                        asistencia.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                        asistencia.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        asistencia.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);
                        asistencia.IdCarrera = DataUtil.DbValueToDefault<int>(reader["idCarrera"]);
                        asistencia.NombreCarrera = DataUtil.DbValueToDefault<string>(reader["nombreCarrera"]);
                        asistencia.IdCurso = DataUtil.DbValueToDefault<int>(reader["idCurso"]);
                        asistencia.CodigoCurso = DataUtil.DbValueToDefault<string>(reader["codigoCurso"]);
                        asistencia.NumeroMalla = DataUtil.DbValueToDefault<string>(reader["numeroMalla"]);
                        asistencia.NumeroCiclo = DataUtil.DbValueToDefault<string>(reader["numeroCiclo"]);
                        asistencia.NombreCurso = DataUtil.DbValueToDefault<string>(reader["nombreCurso"]);
                        asistencia.IdGrupo = DataUtil.DbValueToDefault<int>(reader["idGrupo"]);
                        asistencia.NumeroGrupo = DataUtil.DbValueToDefault<string>(reader["numeroGrupo"]);
                        asistencia.IdSubgrupo = DataUtil.DbValueToDefault<int>(reader["idSubgrupo"]);
                        asistencia.NumeroSubgrupo = DataUtil.DbValueToDefault<string>(reader["numeroSubgrupo"]);
                        asistencia.TipoSubgrupo = DataUtil.DbValueToDefault<string>(reader["tipoSubgrupo"]);
                        asistencia.IdDocente = DataUtil.DbValueToDefault<int>(reader["idDocente"]);
                        asistencia.NombreUsuarioDocente = DataUtil.DbValueToDefault<string>(reader["nombreUsuarioDocente"]);
                        asistencia.NombreDocente = DataUtil.DbValueToDefault<string>(reader["nombreDocente"]);
                        asistencia.IdAlumno = DataUtil.DbValueToDefault<int>(reader["idAlumno"]);
                        asistencia.NombreUsuarioAlumno = DataUtil.DbValueToDefault<string>(reader["nombreUsuarioAlumno"]);
                        asistencia.NombreAlumno = DataUtil.DbValueToDefault<string>(reader["nombreAlumno"]);
                        asistencia.HoraInicio = DataUtil.DbValueToDefault<string>(reader["horaInicio"]);
                        asistencia.HoraEntrada = DataUtil.DbValueToDefault<string>(reader["horaEntrada"]);
                        asistencia.DiferenciaEntrada = DataUtil.DbValueToDefault<int>(reader["diferenciaEntrada"]);
                        asistencia.HoraFin = DataUtil.DbValueToDefault<string>(reader["horaFin"]);
                        asistencia.HoraSalida = DataUtil.DbValueToDefault<string>(reader["horaSalida"]);
                        asistencia.DiferenciaSalida = DataUtil.DbValueToDefault<int>(reader["diferenciaSalida"]);
                        asistencia.Observacion = DataUtil.DbValueToDefault<string>(reader["observacion"]);
                        asistencia.FechaRecuperacion = DataUtil.DbValueToDefault<DateTime>(reader["fechaRecuperacion"]);
                        asistencia.IdAdministrador = DataUtil.DbValueToDefault<int>(reader["idAdministrador"]);
                        asistencia.NombreUsuarioAdministrador = DataUtil.DbValueToDefault<string>(reader["nombreUsuarioAdministrador"]);
                        asistencia.NombreAdministrador = DataUtil.DbValueToDefault<string>(reader["nombreAdministrador"]);

                        listaAsistencias.Add(asistencia);
                    }
                }
            }

            return listaAsistencias;
        }

        #endregion
    }
}
