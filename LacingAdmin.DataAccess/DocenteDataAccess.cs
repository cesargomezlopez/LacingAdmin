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
    public class DocenteDataAccess : RepositoryBase, IDocenteDataAccess
    {
        #region Administrador
        public void CreateDocente(Docente docente)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_DOCENTE]"))
            {
                Database.AddInParameter(command, "@NOMBRE_USUARIO", DbType.Int32, docente.NombreUsuario);
                Database.AddInParameter(command, "@CONTRASEÑA", DbType.String, docente.Contraseña);
                Database.AddInParameter(command, "@NOMBRES", DbType.String, docente.Nombres);
                Database.AddInParameter(command, "@PATERNO", DbType.String, docente.Paterno);
                Database.AddInParameter(command, "@MATERNO", DbType.String, docente.Materno);

                Database.ExecuteNonQuery(command);
            }
        }

        public void DeleteDocente(int idDocente)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_DOCENTE]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, idDocente);

                Database.ExecuteNonQuery(command);
            }
        }

        public Docente GetDocenteById(int idDocente)
        {
            Docente docente = new Docente();
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_DOCENTE_BY_ID]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, idDocente);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        docente.IdDocente = DataUtil.DbValueToDefault<int>(reader["idDocente"]);
                        docente.NombreUsuario = DataUtil.DbValueToDefault<string>(reader["nombreUsuario"]);
                        docente.Contraseña = DataUtil.DbValueToDefault<string>(reader["contraseña"]);
                        docente.Nombres = DataUtil.DbValueToDefault<string>(reader["nombres"]);
                        docente.Paterno = DataUtil.DbValueToDefault<string>(reader["paterno"]);
                        docente.Materno = DataUtil.DbValueToDefault<string>(reader["materno"]);
                        docente.NombreCompleto = String.Format("{0} {1}, {2}", docente.Paterno, docente.Materno, docente.Nombres);
                    }
                }
            }

            return docente;
        }

        public List<DocenteXCarrera> GetListaCarrerasByIdDocente(int idDocente)
        {
            List<DocenteXCarrera> listaCarrerasDocente = new List<DocenteXCarrera>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_CARRERAS_BY_ID_DOCENTE]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, idDocente);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        DocenteXCarrera docenteXCarrera = new DocenteXCarrera();

                        docenteXCarrera.IdDocenteXCarrera = DataUtil.DbValueToDefault<int>(reader["idDocenteXCarrera"]);
                        docenteXCarrera.IdDocente = DataUtil.DbValueToDefault<int>(reader["idDocente"]);
                        docenteXCarrera.IdCarrera = DataUtil.DbValueToDefault<int>(reader["idCarrera"]);
                        docenteXCarrera.NombreDocente = DataUtil.DbValueToDefault<string>(reader["nombresDocente"]);
                        docenteXCarrera.NombreCarrera = DataUtil.DbValueToDefault<string>(reader["nombreCarrera"]);
                        docenteXCarrera.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);

                        listaCarrerasDocente.Add(docenteXCarrera);
                    }
                }
            }

            return listaCarrerasDocente;
        }

        public List<Carrera> GetListaCarrerasRestantes(int idDocente)
        {
            List<Carrera> listaCarrerasRestantes = new List<Carrera>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_CARRERAS_BY_ID_DOCENTE_RESTANTES]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, idDocente);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Carrera carrera = new Carrera();

                        carrera.IdCarrera = DataUtil.DbValueToDefault<int>(reader["idCarrera"]);
                        carrera.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        carrera.NombreCarrera = DataUtil.DbValueToDefault<string>(reader["nombreCarrera"]);

                        listaCarrerasRestantes.Add(carrera);
                    }
                }
            }

            return listaCarrerasRestantes;
        }

        public List<Docente> GetListaDocentes()
        {
            List<Docente> listaDocentes = new List<Docente>();

            using (IDataReader reader = Database.ExecuteReader("[dbo].[SP_GET_LISTA_DOCENTES]"))
            {
                while (reader.Read())
                {
                    Docente docente = new Docente();

                    docente.IdDocente = DataUtil.DbValueToDefault<int>(reader["idDocente"]);
                    docente.NombreUsuario = DataUtil.DbValueToDefault<string>(reader["nombreUsuario"]);
                    docente.Contraseña = DataUtil.DbValueToDefault<string>(reader["contraseña"]);
                    docente.Nombres = DataUtil.DbValueToDefault<string>(reader["nombres"]);
                    docente.Paterno = DataUtil.DbValueToDefault<string>(reader["paterno"]);
                    docente.Materno = DataUtil.DbValueToDefault<string>(reader["materno"]);
                    docente.NombreCompleto = String.Format("{0} {1}, {2}", docente.Paterno, docente.Materno, docente.Nombres);
                    docente.CantidadCarreras = DataUtil.DbValueToDefault<int>(reader["cantidadCarreras"]);

                    listaDocentes.Add(docente);
                }
            }

            return listaDocentes;
        }

        public List<Facultad> GetListaFacultadesRestantes(int idDocente)
        {
            List<Facultad> listaFacultadesRestantes = new List<Facultad>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_FACULTADES_BY_ID_DOCENTE_RESTANTES]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, idDocente);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Facultad facultad = new Facultad();

                        facultad.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        facultad.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);
                        facultad.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);

                        listaFacultadesRestantes.Add(facultad);
                    }
                }
            }

            return listaFacultadesRestantes;
        }

        public void UpdateDocente(Docente docente)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_DOCENTE]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, docente.IdDocente);
                Database.AddInParameter(command, "@NOMBRE_USUARIO", DbType.Int32, docente.NombreUsuario);
                Database.AddInParameter(command, "@CONTRASEÑA", DbType.String, docente.Contraseña);
                Database.AddInParameter(command, "@NOMBRES", DbType.String, docente.Nombres);
                Database.AddInParameter(command, "@PATERNO", DbType.String, docente.Paterno);
                Database.AddInParameter(command, "@MATERNO", DbType.String, docente.Materno);

                Database.ExecuteNonQuery(command);
            }
        }

        #endregion

        #region Docente
        public Docente GetDocenteByNombreUsuario(string nombreUsuario)
        {
            Docente docente = new Docente();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_DOCENTE_BY_NOMBRE_USUARIO]"))
            {
                Database.AddInParameter(command, "@NOMBRE_USUARIO", DbType.String, nombreUsuario);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        docente.IdDocente = DataUtil.DbValueToDefault<int>(reader["idDocente"]);
                        docente.NombreUsuario = DataUtil.DbValueToDefault<string>(reader["nombreUsuario"]);
                        docente.Contraseña = DataUtil.DbValueToDefault<string>(reader["contraseña"]);
                        docente.Nombres = DataUtil.DbValueToDefault<string>(reader["nombres"]);
                        docente.Paterno = DataUtil.DbValueToDefault<string>(reader["paterno"]);
                        docente.Materno = DataUtil.DbValueToDefault<string>(reader["materno"]);
                    }
                }
            }

            return docente;
        }

        public List<Horario> GetListaHorariosDocente(int idDocente)
        {
            List<Horario> listaHorarios = new List<Horario>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_CURSOS_BY_ID_DOCENTE]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, idDocente);

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

        public List<Asistencia> GetListaAsistenciasDocente(int idDocente, int? idCurso)
        {
            List<Asistencia> listaAsistencias = new List<Asistencia>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_ASISTENCIAS_BY_ID_DOCENTE]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, idDocente);
                Database.AddInParameter(command, "@ID_CURSO", DbType.Int32, idCurso);

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
                        asistencia.HoraInicio = DataUtil.DbValueToDefault<TimeSpan>(reader["horaInicio"]).ToString("hh\\:mm");
                        asistencia.HoraEntrada = DataUtil.DbValueToDefault<TimeSpan>(reader["horaEntrada"]).ToString("hh\\:mm");
                        asistencia.DiferenciaEntrada = DataUtil.DbValueToDefault<int>(reader["diferenciaEntrada"]);
                        asistencia.HoraFin = DataUtil.DbValueToDefault<TimeSpan>(reader["horaFin"]).ToString("hh\\:mm");
                        asistencia.HoraSalida = DataUtil.DbValueToDefault<TimeSpan>(reader["horaSalida"]).ToString("hh\\:mm");
                        asistencia.DiferenciaSalida = DataUtil.DbValueToDefault<int>(reader["diferenciaSalida"]);
                        asistencia.Observacion = DataUtil.DbValueToDefault<string>(reader["observacion"]);
                        asistencia.FechaRecuperacion = DataUtil.DbValueToDefault<DateTime>(reader["fechaRecuperacion"]);
                        asistencia.IdAdministrador = DataUtil.DbValueToDefault<int>(reader["idAdministrador"]);
                        asistencia.NombreUsuarioAdministrador = DataUtil.DbValueToDefault<string>(reader["nombreUsuarioAdministrador"]);
                        asistencia.NombreAdministrador = DataUtil.DbValueToDefault<string>(reader["nombreAdministrador"]);
                        asistencia.EstadoAsistencia = DataUtil.DbValueToDefault<string>(reader["estadoAsistencia"]);

                        listaAsistencias.Add(asistencia);
                    }
                }
            }

            return listaAsistencias;
        }

        public List<Curso> GetListaCursosDocente(int idDocente)
        {
            List<Curso> listaCursos = new List<Curso>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_CURSOS_BY_ID_DOCENTE]"))
            {
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, idDocente);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Curso curso = new Curso();

                        curso.IdCurso = DataUtil.DbValueToDefault<int>(reader["idCurso"]);
                        curso.IdCarrera = DataUtil.DbValueToDefault<int>(reader["idCarrera"]);
                        curso.CodigoCurso = DataUtil.DbValueToDefault<string>(reader["codigoCurso"]);
                        curso.NumeroMalla = DataUtil.DbValueToDefault<string>(reader["numeroMalla"]);
                        curso.NumeroCiclo = DataUtil.DbValueToDefault<string>(reader["numeroCiclo"]);
                        curso.NombreCurso = DataUtil.DbValueToDefault<string>(reader["nombreCurso"]);

                        listaCursos.Add(curso);
                    }
                }
            }

            return listaCursos;
        }

        public List<Asistencia> GetListaAsistenciasAlumnosByIdSubgrupo(int? idSubgrupo, DateTime dateInicio, DateTime dateFin)
        {
            List<Asistencia> listaAsistencias = new List<Asistencia>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_ASISTENCIAS_ALUMNO_BY_ID_CURSO]"))
            {
                Database.AddInParameter(command, "@ID_SUBGRUPO", DbType.Int32, idSubgrupo);
                Database.AddInParameter(command, "@FECHA_INICIO", DbType.Date, dateInicio.ToString("dd/MM/yyyy"));
                Database.AddInParameter(command, "@FECHA_FIN", DbType.Date, dateFin.ToString("dd/MM/yyyy"));

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
                        asistencia.HoraInicio = DataUtil.DbValueToDefault<TimeSpan>(reader["horaInicio"]).ToString("hh\\:mm");
                        asistencia.HoraEntrada = DataUtil.DbValueToDefault<TimeSpan>(reader["horaEntrada"]).ToString("hh\\:mm");
                        asistencia.DiferenciaEntrada = DataUtil.DbValueToDefault<int>(reader["diferenciaEntrada"]);
                        asistencia.HoraFin = DataUtil.DbValueToDefault<TimeSpan>(reader["horaFin"]).ToString("hh\\:mm");
                        asistencia.HoraSalida = DataUtil.DbValueToDefault<TimeSpan>(reader["horaSalida"]).ToString("hh\\:mm");
                        asistencia.DiferenciaSalida = DataUtil.DbValueToDefault<int>(reader["diferenciaSalida"]);
                        asistencia.Observacion = DataUtil.DbValueToDefault<string>(reader["observacion"]);
                        asistencia.FechaRecuperacion = DataUtil.DbValueToDefault<DateTime>(reader["fechaRecuperacion"]);
                        asistencia.IdAdministrador = DataUtil.DbValueToDefault<int>(reader["idAdministrador"]);
                        asistencia.NombreUsuarioAdministrador = DataUtil.DbValueToDefault<string>(reader["nombreUsuarioAdministrador"]);
                        asistencia.NombreAdministrador = DataUtil.DbValueToDefault<string>(reader["nombreAdministrador"]);
                        asistencia.EstadoAsistencia = DataUtil.DbValueToDefault<string>(reader["estadoAsistencia"]);

                        listaAsistencias.Add(asistencia);
                    }
                }
            }

            return listaAsistencias;
        }
        #endregion
    }
}
