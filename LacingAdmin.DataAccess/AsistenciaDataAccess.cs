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
    public class AsistenciaDataAccess : RepositoryBase, IAsistenciaDataAccess
    {
        public void CreateAsistencia(Asistencia asistencia)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_ASISTENCIA]"))
            {
                Database.AddInParameter(command, "@TIPO_ASISTENCIA", DbType.Int32, asistencia.TipoAsistencia);
                Database.AddInParameter(command, "@ID_HORARIO", DbType.Int32, asistencia.IdHorario);
                Database.AddInParameter(command, "@DIA", DbType.Int32, asistencia.Dia);
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, asistencia.IdLaboratorio);
                Database.AddInParameter(command, "@NOMBRE_LABORATORIO", DbType.String, asistencia.NombreLaboratorio);
                Database.AddInParameter(command, "@ID_FACULTAD", DbType.Int32, asistencia.IdFacultad);
                Database.AddInParameter(command, "@NOMBRE_FACULTAD", DbType.String, asistencia.NombreFacultad);
                Database.AddInParameter(command, "@ID_CARRERA", DbType.Int32, asistencia.IdCarrera);
                Database.AddInParameter(command, "@NOMBRE_CARRERA", DbType.String, asistencia.NombreCarrera);
                Database.AddInParameter(command, "@ID_CURSO", DbType.Int32, asistencia.IdCurso);
                Database.AddInParameter(command, "@CODIGO_CURSO", DbType.String, asistencia.CodigoCurso);
                Database.AddInParameter(command, "@NUMERO_MALLA", DbType.String, asistencia.NumeroMalla);
                Database.AddInParameter(command, "@NUMERO_CICLO", DbType.String, asistencia.NumeroCiclo);
                Database.AddInParameter(command, "@NOMBRE_CURSO", DbType.String, asistencia.NombreCurso);
                Database.AddInParameter(command, "@ID_GRUPO", DbType.Int32, asistencia.IdGrupo);
                Database.AddInParameter(command, "@NUMERO_GRUPO", DbType.String, asistencia.NumeroGrupo);
                Database.AddInParameter(command, "@ID_SUBGRUPO", DbType.Int32, asistencia.IdSubgrupo);
                Database.AddInParameter(command, "@NUMERO_SUBGRUPO", DbType.String, asistencia.NumeroSubgrupo);
                Database.AddInParameter(command, "@TIPO_SUBGRUPO", DbType.String, asistencia.TipoSubgrupo);
                Database.AddInParameter(command, "@ID_DOCENTE", DbType.Int32, asistencia.IdDocente);
                Database.AddInParameter(command, "@NOMBRE_USUARIO_DOCENTE", DbType.String, asistencia.NombreUsuarioDocente);
                Database.AddInParameter(command, "@NOMBRE_DOCENTE", DbType.String, asistencia.NombreDocente);
                Database.AddInParameter(command, "@ID_ALUMNO", DbType.Int32, asistencia.IdAlumno);
                Database.AddInParameter(command, "@NOMBRE_USUARIO_ALUMNO", DbType.String, asistencia.NombreUsuarioAlumno);
                Database.AddInParameter(command, "@NOMBRE_ALUMNO", DbType.String, asistencia.NombreAlumno);
                Database.AddInParameter(command, "@HORA_INICIO", DbType.String, asistencia.HoraInicio);
                //Database.AddInParameter(command, "@DIFERENCIA_ENTRADA", DbType.String, asistencia.DiferenciaEntrada);
                Database.AddInParameter(command, "@HORA_FIN", DbType.String, asistencia.HoraFin);
                Database.AddInParameter(command, "@HORA_SALIDA", DbType.String, asistencia.HoraSalida);
                Database.AddInParameter(command, "@DIFERENCIA_SALIDA", DbType.Int32, asistencia.DiferenciaSalida);
                Database.AddInParameter(command, "@OBSERVACION", DbType.String, asistencia.Observacion);
                Database.AddInParameter(command, "@FECHA_RECUPERACION", DbType.DateTime, DateTime.Now);
                Database.AddInParameter(command, "@ID_ADMINISTRADOR", DbType.Int32, asistencia.IdAdministrador);
                Database.AddInParameter(command, "@NOMBRE_USUARIO_ADMINISTRADOR", DbType.String, asistencia.NombreUsuarioAdministrador);
                Database.AddInParameter(command, "@NOMBRE_ADMINISTRADOR", DbType.String, asistencia.NombreAdministrador);
                Database.AddInParameter(command, "@CANTIDAD_HORAS", DbType.Int32, asistencia.CantidadHoras);
                Database.AddInParameter(command, "@MINUTOS_HORA", DbType.String, asistencia.MinutosHora);

                Database.ExecuteNonQuery(command);
            }
        }
    }
}
