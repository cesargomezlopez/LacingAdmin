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
    public class SoftwareDataAccess : RepositoryBase, ISoftwareDataAccess
    {
        public List<Software> GetListaSoftwares()
        {
            List<Software> listaSoftwares = new List<Software>();

            using (IDataReader reader = Database.ExecuteReader("[dbo].[SP_GET_LISTA_SOFTWARES]"))
            {
                while (reader.Read())
                {
                    Software software = new Software();

                    software.IdSoftware = DataUtil.DbValueToDefault<int>(reader["idSoftware"]);
                    software.Nombre = DataUtil.DbValueToDefault<string>(reader["nombre"]);
                    software.Version = DataUtil.DbValueToDefault<string>(reader["version"]);
                    software.Tipo = DataUtil.DbValueToDefault<string>(reader["tipo"]);

                    listaSoftwares.Add(software);
                }
            }

            return listaSoftwares;
        }
        public List<SoftwareXLaboratorio> GetListaSoftwareXLaboratorioByIdSoftware(int idSoftware)
        {
            List<SoftwareXLaboratorio> listaSoftwareXLaboratorio = new List<SoftwareXLaboratorio>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_SOFTWARE_X_LABORATORIO_BY_ID_SOFTWARE]"))
            {
                Database.AddInParameter(command, "@ID_SOFTWARE", DbType.Int32, idSoftware);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        SoftwareXLaboratorio softwareXLaboratorio = new SoftwareXLaboratorio();

                        softwareXLaboratorio.IdSoftwareXLaboratorio = DataUtil.DbValueToDefault<int>(reader["idSoftwareXLaboratorio"]);
                        softwareXLaboratorio.IdSoftware = DataUtil.DbValueToDefault<int>(reader["idSoftware"]);
                        softwareXLaboratorio.NombreSoftware = DataUtil.DbValueToDefault<string>(reader["nombre"]);
                        softwareXLaboratorio.VersionSoftware = DataUtil.DbValueToDefault<string>(reader["version"]);
                        softwareXLaboratorio.TipoSoftware = DataUtil.DbValueToDefault<string>(reader["tipo"]);
                        softwareXLaboratorio.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                        softwareXLaboratorio.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                        softwareXLaboratorio.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        softwareXLaboratorio.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);

                        listaSoftwareXLaboratorio.Add(softwareXLaboratorio);
                    }
                }
            }

            return listaSoftwareXLaboratorio;
        }
        public List<SoftwareXCarrera> GetListaSoftwareXCarreraByIdSoftware(int idSoftware)
        {
            List<SoftwareXCarrera> listaSoftwareXCarrera = new List<SoftwareXCarrera>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_SOFTWARE_X_CARRERA_BY_ID_SOFTWARE]"))
            {
                Database.AddInParameter(command, "@ID_SOFTWARE", DbType.Int32, idSoftware);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        SoftwareXCarrera softwareXCarrera = new SoftwareXCarrera();

                        softwareXCarrera.IdSoftwareXCarrera = DataUtil.DbValueToDefault<int>(reader["idSoftwareXCarrera"]);
                        softwareXCarrera.IdSoftware = DataUtil.DbValueToDefault<int>(reader["idSoftware"]);
                        softwareXCarrera.NombreSoftware = DataUtil.DbValueToDefault<string>(reader["nombre"]);
                        softwareXCarrera.VersionSoftware = DataUtil.DbValueToDefault<string>(reader["version"]);
                        softwareXCarrera.TipoSoftware = DataUtil.DbValueToDefault<string>(reader["tipo"]);
                        softwareXCarrera.IdCarrera = DataUtil.DbValueToDefault<int>(reader["idCarrera"]);
                        softwareXCarrera.NombreCarrera = DataUtil.DbValueToDefault<string>(reader["nombreCarrera"]);
                        softwareXCarrera.IdFacultad = DataUtil.DbValueToDefault<int>(reader["idFacultad"]);
                        softwareXCarrera.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);

                        listaSoftwareXCarrera.Add(softwareXCarrera);
                    }
                }
            }

            return listaSoftwareXCarrera;
        }
        public void DeleteSoftwareByIdSoftware(int idSoftware)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_SOFTWARE]"))
            {
                Database.AddInParameter(command, "@ID_SOFTWARE", DbType.Int32, idSoftware);

                Database.ExecuteNonQuery(command);
            }
        }

        public void CreateSoftware(Software software)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_SOFTWARE]"))
            {
                Database.AddInParameter(command, "@NOMBRE_SOFTWARE", DbType.String, software.Nombre);
                Database.AddInParameter(command, "@VERSION", DbType.String, software.Version);
                Database.AddInParameter(command, "@TIPO", DbType.String, software.Tipo);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        software.IdSoftware = DataUtil.DbValueToDefault<int>(reader["idSoftware"]);
                    }
                }
            }

            if (software.ListaLaboratorios != null && software.ListaLaboratorios.Count > 0)
            {
                for (int i = 0; i < software.ListaLaboratorios.Count; i++)
                {
                    using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_SOFTWARE_X_LABORATORIO]"))
                    {
                        Database.AddInParameter(command, "@ID_SOFTWARE", DbType.Int32, software.IdSoftware);
                        Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, software.ListaLaboratorios[i].IdLaboratorio);

                        Database.ExecuteNonQuery(command);
                    }
                }
            }

            if (software.ListaCarreras != null && software.ListaCarreras.Count > 0)
            {
                for (int i = 0; i < software.ListaCarreras.Count; i++)
                {
                    using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_SOFTWARE_X_CARRERA]"))
                    {
                        Database.AddInParameter(command, "@ID_SOFTWARE", DbType.Int32, software.IdSoftware);
                        Database.AddInParameter(command, "@ID_CARRERA", DbType.Int32, software.ListaCarreras[i].IdCarrera);

                        Database.ExecuteNonQuery(command);
                    }
                }
            }
        }

        public void EditarSoftware(Software software)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_SOFTWARE]"))
            {
                Database.AddInParameter(command, "@ID_SOFTWARE", DbType.Int32, software.IdSoftware);
                Database.AddInParameter(command, "@NOMBRE_SOFTWARE", DbType.String, software.Nombre);
                Database.AddInParameter(command, "@VERSION", DbType.String, software.Version);
                Database.AddInParameter(command, "@TIPO", DbType.String, software.Tipo);

                Database.ExecuteNonQuery(command);
            }

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_SOFTWARE_X_LABOTORIO_X_CARRERA]"))
            {
                Database.AddInParameter(command, "@ID_SOFTWARE", DbType.Int32, software.IdSoftware);

                Database.ExecuteNonQuery(command);
            }

            if (software.ListaLaboratorios != null && software.ListaLaboratorios.Count > 0)
            {
                for (int i = 0; i < software.ListaLaboratorios.Count; i++)
                {
                    using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_SOFTWARE_X_LABORATORIO]"))
                    {
                        Database.AddInParameter(command, "@ID_SOFTWARE", DbType.Int32, software.IdSoftware);
                        Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, software.ListaLaboratorios[i].IdLaboratorio);

                        Database.ExecuteNonQuery(command);
                    }
                }
            }

            if (software.ListaCarreras != null && software.ListaCarreras.Count > 0)
            {
                for (int i = 0; i < software.ListaCarreras.Count; i++)
                {
                    using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_SOFTWARE_X_CARRERA]"))
                    {
                        Database.AddInParameter(command, "@ID_SOFTWARE", DbType.Int32, software.IdSoftware);
                        Database.AddInParameter(command, "@ID_CARRERA", DbType.Int32, software.ListaCarreras[i].IdCarrera);

                        Database.ExecuteNonQuery(command);
                    }
                }
            }
        }

            public Software GetSoftwareById(int idSoftware)
        {
            Software software = new Software();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_SOFTWARE_BY_ID]"))
            {
                Database.AddInParameter(command, "@ID_SOFTWARE", DbType.Int32, idSoftware);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        software.IdSoftware = DataUtil.DbValueToDefault<int>(reader["idSoftware"]);
                        software.Nombre = DataUtil.DbValueToDefault<string>(reader["nombre"]);
                        software.Version = DataUtil.DbValueToDefault<string>(reader["version"]);
                        software.Tipo = DataUtil.DbValueToDefault<string>(reader["tipo"]);
                    }
                }
            }

            return software;
        }


        #region Report Methods
        public List<Software> GetListaSoftwareByIdFacultad(int idFacultad)
        {
            List<Software> listaSoftwares = new List<Software>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_SOFTWARES_BY_ID_FACULTAD]"))
            {
                Database.AddInParameter(command, "@ID_FACULTAD", DbType.Int32, idFacultad);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Software software = new Software();

                        software.IdSoftware = DataUtil.DbValueToDefault<int>(reader["idSoftware"]);
                        software.Nombre = DataUtil.DbValueToDefault<string>(reader["nombre"]);
                        software.Version = DataUtil.DbValueToDefault<string>(reader["version"]);
                        software.Tipo = DataUtil.DbValueToDefault<string>(reader["tipo"]);

                        listaSoftwares.Add(software);
                    }
                }
            }

            return listaSoftwares;
        }

        public List<Software> GetListaSoftwareByIdLaboratorio(int idLaboratorio)
        {
            List<Software> listaSoftwares = new List<Software>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_SOFTWARES_BY_ID_LABORATORIO]"))
            {
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, idLaboratorio);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Software software = new Software();

                        software.IdSoftware = DataUtil.DbValueToDefault<int>(reader["idSoftware"]);
                        software.Nombre = DataUtil.DbValueToDefault<string>(reader["nombre"]);
                        software.Version = DataUtil.DbValueToDefault<string>(reader["version"]);
                        software.Tipo = DataUtil.DbValueToDefault<string>(reader["tipo"]);

                        listaSoftwares.Add(software);
                    }
                }
            }

            return listaSoftwares;
        }

        public List<Software> GetListaSoftwareByNombre(string nombreSoftware)
        {
            List<Software> listaSoftwares = new List<Software>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_SOFTWARES_BY_NOMBRE_SOFTWARE]"))
            {
                Database.AddInParameter(command, "@NOMBRE_SOFTWARE", DbType.String, nombreSoftware);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Software software = new Software();

                        software.IdSoftware = DataUtil.DbValueToDefault<int>(reader["idSoftware"]);
                        software.Nombre = DataUtil.DbValueToDefault<string>(reader["nombre"]);
                        software.Version = DataUtil.DbValueToDefault<string>(reader["version"]);
                        software.Tipo = DataUtil.DbValueToDefault<string>(reader["tipo"]);

                        listaSoftwares.Add(software);
                    }
                }
            }

            return listaSoftwares;
        }

        public List<Software> GetListaSoftwareByTipo(string tipoSoftware)
        {
            List<Software> listaSoftwares = new List<Software>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_SOFTWARES_BY_TIPO]"))
            {
                Database.AddInParameter(command, "@TIPO", DbType.String, tipoSoftware);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Software software = new Software();

                        software.IdSoftware = DataUtil.DbValueToDefault<int>(reader["idSoftware"]);
                        software.Nombre = DataUtil.DbValueToDefault<string>(reader["nombre"]);
                        software.Version = DataUtil.DbValueToDefault<string>(reader["version"]);
                        software.Tipo = DataUtil.DbValueToDefault<string>(reader["tipo"]);

                        listaSoftwares.Add(software);
                    }
                }
            }

            return listaSoftwares;
        }
        #endregion
    }
}
