using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface ICursoDataAccess
    {
        void CreateCurso(Curso curso);
        List<Curso> GetListaCursos();
        Curso GetCursoById(int idCurso);
        void UpdateCurso(Curso curso);
        void DeleteCurso(int idCurso);

        void CreateGrupo(Grupo grupo);
        List<Grupo> GetListaGruposByIdCurso(int idCurso);
        void DeleteGrupo(int idGrupo);
        void CreateSubgrupo(Subgrupo subgrupo);
        List<Subgrupo> GetListaSubgruposByIdGrupo(int idGrupo);
        void EditarSubgrupo(Subgrupo subgrupo);
        void DeleteSubgrupo(int idSubgrupo);

        int GetIdCursoByIdSubgrupo(int idSubgrupo);
        int GetIdGrupoByIdSubgrupo(int idSubgrupo);

        List<Curso> GetListaCursosByIdCarrera(int? idCarrera);
        Subgrupo GetSubgrupoByIdGrupoNumeroSubgrupo(int idGrupo, string numeroSubgrupo);
    }
}
