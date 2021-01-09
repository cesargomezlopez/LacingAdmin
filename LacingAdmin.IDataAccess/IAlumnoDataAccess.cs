using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface IAlumnoDataAccess
    {
        #region Administrador
        void CreateAlumno(Alumno alumno);
        List<Alumno> GetListaAlumno();
        Alumno GetAlumnoById(int idAlumno);
        void UpdateAlumno(Alumno alumno);
        void DeleteAlumno(int idAlumno);
        #endregion

        #region Alumno
        Alumno GetAlumnoByNombreUsuario(string nombreUsuario);
        List<Horario> GetListaHorariosAlumno(int idAlumno);
        List<Asistencia> GetListaAsistenciasAlumno(int idAlumno);
        #endregion
    }
}
