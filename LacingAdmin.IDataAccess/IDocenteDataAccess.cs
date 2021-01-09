using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface IDocenteDataAccess
    {
        #region Administrador
        void CreateDocente(Docente docente);
        List<Docente> GetListaDocentes();
        Docente GetDocenteById(int idDocente);
        void UpdateDocente(Docente docente);
        void DeleteDocente(int idDocente);
        List<DocenteXCarrera> GetListaCarrerasByIdDocente(int idDocente);
        List<Facultad> GetListaFacultadesRestantes(int idDocente);
        List<Carrera> GetListaCarrerasRestantes(int idDocente);
        #endregion

        #region Docente
        Docente GetDocenteByNombreUsuario(string nombreUsuario);
        List<Horario> GetListaHorariosDocente(int idDocente);
        List<Asistencia> GetListaAsistenciasDocente(int idDocente, int? idCurso);

        List<Curso> GetListaCursosDocente(int idDocente);
        List<Asistencia> GetListaAsistenciasAlumnosByIdSubgrupo(int? idSubgrupo, DateTime dateInicio, DateTime dateFin);
        #endregion
    }
}
