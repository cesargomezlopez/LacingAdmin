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
    public class CursoDataAccess : RepositoryBase, ICursoDataAccess
    {
        public void CreateCurso(Curso curso)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_CURSO]"))
            {
                Database.AddInParameter(command, "@ID_CARRERA", DbType.Int32, curso.IdCarrera);
                Database.AddInParameter(command, "@CODIGO_CURSO", DbType.String, curso.CodigoCurso);
                Database.AddInParameter(command, "@NUMERO_MALLA", DbType.String, curso.NumeroMalla);
                Database.AddInParameter(command, "@NUMERO_CICLO", DbType.String, curso.NumeroCiclo);
                Database.AddInParameter(command, "@NOMBRE_CURSO", DbType.String, curso.NombreCurso);

                Database.ExecuteNonQuery(command);
            }
        }

        public void DeleteCurso(int idCurso)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_CURSO]"))
            {
                Database.AddInParameter(command, "@ID_CURSO", DbType.Int32, idCurso);

                Database.ExecuteNonQuery(command);
            }
        }

        public Curso GetCursoById(int idCurso)
        {
            Curso curso = new Curso();
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_CURSO_BY_ID]"))
            {
                Database.AddInParameter(command, "@ID_CURSO", DbType.Int32, idCurso);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        curso.IdCurso = DataUtil.DbValueToDefault<int>(reader["idCurso"]);
                        curso.IdCarrera = DataUtil.DbValueToDefault<int>(reader["idCarrera"]);
                        curso.CodigoCurso = DataUtil.DbValueToDefault<string>(reader["codigoCurso"]);
                        curso.NumeroMalla = DataUtil.DbValueToDefault<string>(reader["numeroMalla"]);
                        curso.NumeroCiclo = DataUtil.DbValueToDefault<string>(reader["numeroCiclo"]);
                        curso.NombreCurso = DataUtil.DbValueToDefault<string>(reader["nombreCurso"]);
                        curso.NombreCarrera = DataUtil.DbValueToDefault<string>(reader["nombreCarrera"]);
                    }
                }
            }

            return curso;
        }

        public List<Curso> GetListaCursos()
        {
            List<Curso> listaCursos = new List<Curso>();

            using (IDataReader reader = Database.ExecuteReader("[dbo].[SP_GET_LISTA_CURSOS]"))
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
                    curso.NombreCarrera = DataUtil.DbValueToDefault<string>(reader["nombreCarrera"]);

                    listaCursos.Add(curso);
                }
            }

            return listaCursos;
        }

        public void UpdateCurso(Curso curso)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_CURSO]"))
            {
                Database.AddInParameter(command, "@ID_CURSO", DbType.Int32, curso.IdCurso);
                Database.AddInParameter(command, "@ID_CARRERA", DbType.Int32, curso.IdCarrera);
                Database.AddInParameter(command, "@CODIGO_CURSO", DbType.String, curso.CodigoCurso);
                Database.AddInParameter(command, "@NUMERO_MALLA", DbType.String, curso.NumeroMalla);
                Database.AddInParameter(command, "@NUMERO_CICLO", DbType.String, curso.NumeroCiclo);
                Database.AddInParameter(command, "@NOMBRE_CURSO", DbType.String, curso.NombreCurso);

                Database.ExecuteNonQuery(command);
            }
        }

        public void CreateGrupo(Grupo grupo)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_GRUPO]"))
            {
                Database.AddInParameter(command, "@ID_CURSO", DbType.Int32, grupo.IdCurso);
                Database.AddInParameter(command, "@NUMERO_GRUPO", DbType.String, grupo.NumeroGrupo);

                Database.ExecuteNonQuery(command);
            }
        }

        public List<Grupo> GetListaGruposByIdCurso(int idCurso)
        {
            List<Grupo> listaGrupos = new List<Grupo>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_GRUPOS_BY_ID_CURSO]"))
            {
                Database.AddInParameter(command, "@ID_CURSO", DbType.Int32, idCurso);
                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Grupo grupo = new Grupo();

                        grupo.IdGrupo = DataUtil.DbValueToDefault<int>(reader["idGrupo"]);
                        grupo.IdCurso = DataUtil.DbValueToDefault<int>(reader["idCurso"]);
                        grupo.NumeroGrupo = DataUtil.DbValueToDefault<string>(reader["numeroGrupo"]);
                        grupo.CantidadSubgrupos = DataUtil.DbValueToDefault<int>(reader["cantidadSubgrupos"]);

                        listaGrupos.Add(grupo);
                    }
                }
            }            

            return listaGrupos;
        }
        public void DeleteGrupo(int idGrupo)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_GRUPO]"))
            {
                Database.AddInParameter(command, "@ID_GRUPO", DbType.Int32, idGrupo);

                Database.ExecuteNonQuery(command);
            }
        }


        public void CreateSubgrupo(Subgrupo subgrupo)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_SUBGRUPO]"))
            {
                Database.AddInParameter(command, "@ID_GRUPO", DbType.Int32, subgrupo.IdGrupo);
                Database.AddInParameter(command, "@NUMERO_SUBGRUPO", DbType.String, subgrupo.NumeroSubgrupo);
                Database.AddInParameter(command, "@TIPO_SUBGRUPO", DbType.String, subgrupo.TipoSubgrupo);

                Database.ExecuteNonQuery(command);
            }
        }

        public List<Subgrupo> GetListaSubgruposByIdGrupo(int idGrupo)
        {
            List<Subgrupo> listaSubgrupos = new List<Subgrupo>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_SUBGRUPOS_BY_ID_GRUPO]"))
            {
                Database.AddInParameter(command, "@ID_GRUPO", DbType.Int32, idGrupo);
                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Subgrupo subgrupo = new Subgrupo();

                        subgrupo.IdSubgrupo = DataUtil.DbValueToDefault<int>(reader["idSubgrupo"]);
                        subgrupo.IdGrupo = DataUtil.DbValueToDefault<int>(reader["idGrupo"]);
                        subgrupo.NumeroSubgrupo = DataUtil.DbValueToDefault<string>(reader["numeroSubgrupo"]);
                        subgrupo.TipoSubgrupo = DataUtil.DbValueToDefault<string>(reader["tipoSubgrupo"]);

                        listaSubgrupos.Add(subgrupo);
                    }
                }
            }

            return listaSubgrupos;
        }

        public void EditarSubgrupo(Subgrupo subgrupo)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_SUBGRUPO]"))
            {
                Database.AddInParameter(command, "@ID_GRUPO", DbType.Int32, subgrupo.IdGrupo);
                Database.AddInParameter(command, "@ID_SUBGRUPO", DbType.Int32, subgrupo.IdSubgrupo);
                Database.AddInParameter(command, "@NUMERO_SUBGRUPO", DbType.String, subgrupo.NumeroSubgrupo);
                Database.AddInParameter(command, "@TIPO_SUBGRUPO", DbType.String, subgrupo.TipoSubgrupo);

                Database.ExecuteNonQuery(command);
            }
        }

        public void DeleteSubgrupo(int idSubgrupo)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_SUBGRUPO]"))
            {
                Database.AddInParameter(command, "@ID_SUBGRUPO", DbType.Int32, idSubgrupo);

                Database.ExecuteNonQuery(command);
            }
        }

        public int GetIdCursoByIdSubgrupo(int idSubgrupo)
        {
            int resultado = 0;
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_ID_CURSO_BY_ID_SUBGRUPO]"))
            {
                Database.AddInParameter(command, "@ID_SUBGRUPO", DbType.Int32, idSubgrupo);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        resultado = DataUtil.DbValueToDefault<int>(reader["idCurso"]);
                    }
                }
            }

            return resultado;
        }

        public int GetIdGrupoByIdSubgrupo(int idSubgrupo)
        {
            int resultado = 0;
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_ID_GRUPO_BY_ID_SUBGRUPO]"))
            {
                Database.AddInParameter(command, "@ID_SUBGRUPO", DbType.Int32, idSubgrupo);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        resultado = DataUtil.DbValueToDefault<int>(reader["idGrupo"]);
                    }
                }
            }

            return resultado;
        }

        public List<Curso> GetListaCursosByIdCarrera(int? idCarrera)
        {
            List<Curso> listaCursos = new List<Curso>();
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_CURSO_BY_ID_CARRERA]"))
            {
                Database.AddInParameter(command, "@ID_CARRERA", DbType.Int32, idCarrera);

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

        public Subgrupo GetSubgrupoByIdGrupoNumeroSubgrupo(int idGrupo, string numeroSubgrupo)
        {
            Subgrupo subgrupo = new Subgrupo();
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_SUBGRUPO_BY_ID_GRUPO_NUMERO_SUBGRUPO]"))
            {
                Database.AddInParameter(command, "@ID_GRUPO", DbType.Int32, idGrupo);
                Database.AddInParameter(command, "@ID_SUBGRUPO", DbType.String, numeroSubgrupo);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        subgrupo.IdSubgrupo = DataUtil.DbValueToDefault<int>(reader["idSubgrupo"]);
                        subgrupo.IdGrupo = DataUtil.DbValueToDefault<int>(reader["idGrupo"]);
                        subgrupo.NumeroSubgrupo = DataUtil.DbValueToDefault<string>(reader["numeroSubgrupo"]);
                        subgrupo.TipoSubgrupo = DataUtil.DbValueToDefault<string>(reader["tipoSubgrupo"]);
                    }
                }
            }

            return subgrupo;
        }
    }
}
