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
    public class AdministradorDataAccess : RepositoryBase, IAdministradorDataAccess
    {        
        public Administrador GetAdministradorByNombreUsuario(string nombreUsuario)
        {
            Administrador administrador = new Administrador();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_ADMINISTRADOR_BY_NOMBRE_USUARIO]"))
            {
                Database.AddInParameter(command, "@NOMBRE_USUARIO", DbType.String, nombreUsuario);
                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        administrador.IdAdministrador = DataUtil.DbValueToDefault<int>(reader["idAdministrador"]);
                        administrador.NombreUsuario = DataUtil.DbValueToDefault<string>(reader["nombreUsuario"]);
                        administrador.Contraseña = DataUtil.DbValueToDefault<string>(reader["contraseña"]);
                        administrador.Nombres = DataUtil.DbValueToDefault<string>(reader["nombres"]);
                        administrador.Paterno = DataUtil.DbValueToDefault<string>(reader["paterno"]);
                        administrador.Materno = DataUtil.DbValueToDefault<string>(reader["materno"]);
                        administrador.Rol = DataUtil.DbValueToDefault<string>(reader["rol"]);
                        administrador.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                        administrador.NombreCompleto = String.Format("{0} {1}, {2}", administrador.Paterno, administrador.Materno, administrador.Nombres);
                    }
                }
            }
            return administrador;
        }

        public List<Administrador> GetListaAdministradores()
        {
            List<Administrador> listaAdministradores = new List<Administrador>();

            using (IDataReader reader = Database.ExecuteReader("[dbo].[SP_GET_LISTA_ADMINISTRADORES]"))
            {
                while (reader.Read())
                {
                    Administrador administrador = new Administrador();

                    administrador.IdAdministrador = DataUtil.DbValueToDefault<int>(reader["idAdministrador"]);
                    administrador.NombreUsuario = DataUtil.DbValueToDefault<string>(reader["nombreUsuario"]);
                    administrador.Contraseña = DataUtil.DbValueToDefault<string>(reader["contraseña"]);
                    administrador.Nombres = DataUtil.DbValueToDefault<string>(reader["nombres"]);
                    administrador.Paterno = DataUtil.DbValueToDefault<string>(reader["paterno"]);
                    administrador.Materno = DataUtil.DbValueToDefault<string>(reader["materno"]);
                    administrador.Rol = DataUtil.DbValueToDefault<string>(reader["rol"]);
                    administrador.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                    administrador.NombreCompleto = String.Format("{0} {1}, {2}", administrador.Paterno, administrador.Materno, administrador.Nombres);
                    if (administrador.Estado == "1")
                    {
                        administrador.NombreEstado = "Activo";
                    }
                    else
                    {
                        administrador.NombreEstado = "Desactivo";
                    }

                    listaAdministradores.Add(administrador);
                }
            }
            return listaAdministradores;
        }
        public void CreateAdministrador(Administrador administrador)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_ADMINISTRADOR]"))
            {
                Database.AddInParameter(command, "@NOMBRE_USUARIO", DbType.String, administrador.NombreUsuario);
                Database.AddInParameter(command, "@CONTRASEÑA", DbType.String, administrador.Contraseña);
                Database.AddInParameter(command, "@NOMBRES", DbType.String, administrador.Nombres);
                Database.AddInParameter(command, "@PATERNO", DbType.String, administrador.Paterno);
                Database.AddInParameter(command, "@MATERNO", DbType.String, administrador.Materno);
                Database.AddInParameter(command, "@ROL", DbType.String, administrador.Rol);
                Database.AddInParameter(command, "@ESTADO", DbType.String, administrador.Estado);

                Database.ExecuteNonQuery(command);
            }
        }

        public void UpdateAdministrador(Administrador administrador)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_ADMINISTRADOR]"))
            {
                Database.AddInParameter(command, "@ID_ADMINISTRADOR", DbType.Int32, administrador.IdAdministrador);
                Database.AddInParameter(command, "@NOMBRE_USUARIO", DbType.String, administrador.NombreUsuario);
                Database.AddInParameter(command, "@CONTRASEÑA", DbType.String, administrador.Contraseña);
                Database.AddInParameter(command, "@NOMBRES", DbType.String, administrador.Nombres);
                Database.AddInParameter(command, "@PATERNO", DbType.String, administrador.Paterno);
                Database.AddInParameter(command, "@MATERNO", DbType.String, administrador.Materno);
                Database.AddInParameter(command, "@ROL", DbType.String, administrador.Rol);
                Database.AddInParameter(command, "@ESTADO", DbType.String, administrador.Estado);

                Database.ExecuteNonQuery(command);
            }
        }

        public void DeleteAdministrador(int idAdministrador)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_ADMINISTRADOR]"))
            {
                Database.AddInParameter(command, "@ID_ADMINISTRADOR", DbType.Int32, idAdministrador);

                Database.ExecuteNonQuery(command);
            }
        }
    }
}
