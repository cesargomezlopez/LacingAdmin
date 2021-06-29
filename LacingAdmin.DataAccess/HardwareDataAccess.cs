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
    public class HardwareDataAccess : RepositoryBase, IHardwareDataAccess
    {
        public List<Hardware> GetListaEquiposComputo()
        {
            List<Hardware> listaEquiposComputo = new List<Hardware>();

            using (IDataReader reader = Database.ExecuteReader("[dbo].[SP_GET_LISTA_EQUIPOS_COMPUTO]"))
            {
                while (reader.Read())
                {
                    Hardware hardware = new Hardware();

                    hardware.IdHardware = DataUtil.DbValueToDefault<int>(reader["idHardware"]);
                    hardware.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                    hardware.TipoEquipo = DataUtil.DbValueToDefault<string>(reader["tipoEquipo"]);
                    hardware.Marca = DataUtil.DbValueToDefault<string>(reader["marca"]);
                    hardware.Modelo = DataUtil.DbValueToDefault<string>(reader["modelo"]);
                    hardware.Serie = DataUtil.DbValueToDefault<string>(reader["serie"]);
                    hardware.Inventario = DataUtil.DbValueToDefault<string>(reader["inventario"]);
                    hardware.Procesador = DataUtil.DbValueToDefault<string>(reader["procesador"]);
                    hardware.Velocidad = DataUtil.DbValueToDefault<string>(reader["velocidad"]);
                    hardware.Ram = DataUtil.DbValueToDefault<string>(reader["ram"]);
                    hardware.DiscoDuro = DataUtil.DbValueToDefault<string>(reader["discoDuro"]);
                    hardware.TarjetaVideo = DataUtil.DbValueToDefault<string>(reader["tarjetaVideo"]);
                    hardware.Usuario = DataUtil.DbValueToDefault<string>(reader["usuario"]);
                    hardware.Observacion = DataUtil.DbValueToDefault<string>(reader["observacion"]);
                    hardware.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                    hardware.FlgEquipoComputo = DataUtil.DbValueToDefault<string>(reader["flgEquipoComputo"]);
                    hardware.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                    hardware.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);


                    listaEquiposComputo.Add(hardware);
                }
            }

            return listaEquiposComputo;
        }

        void IHardwareDataAccess.DeleteEquipoComputoByUsuario(string usuario)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_EQUIPO_COMPUTO_BY_USUARIO]"))
            {
                Database.AddInParameter(command, "@USUARIO", DbType.String, usuario);

                Database.ExecuteNonQuery(command);
            }
        }

        public void CreateHardware(List<Hardware> equiposComputoList)
        {
            for (int i = 0; i < equiposComputoList.Count; i++)
            {
                using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_CREATE_HARDWARE]"))
                {
                    Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, equiposComputoList[i].IdLaboratorio);
                    Database.AddInParameter(command, "@TIPO_EQUIPO", DbType.String, equiposComputoList[i].TipoEquipo);
                    Database.AddInParameter(command, "@MARCA", DbType.String, equiposComputoList[i].Marca);
                    Database.AddInParameter(command, "@MODELO", DbType.String, equiposComputoList[i].Modelo);
                    Database.AddInParameter(command, "@SERIE", DbType.String, equiposComputoList[i].Serie);
                    Database.AddInParameter(command, "@INVENTARIO", DbType.String, equiposComputoList[i].Inventario);
                    Database.AddInParameter(command, "@PROCESADOR", DbType.String, equiposComputoList[i].Procesador);
                    Database.AddInParameter(command, "@VELOCIDAD", DbType.String, equiposComputoList[i].Velocidad);
                    Database.AddInParameter(command, "@RAM", DbType.String, equiposComputoList[i].Ram);
                    Database.AddInParameter(command, "@DISCO_DURO", DbType.String, equiposComputoList[i].DiscoDuro);
                    Database.AddInParameter(command, "@TARJETA_VIDEO", DbType.String, equiposComputoList[i].TarjetaVideo);
                    Database.AddInParameter(command, "@USUARIO", DbType.String, equiposComputoList[i].Usuario);
                    Database.AddInParameter(command, "@OBSERVACION", DbType.String, equiposComputoList[i].Observacion);
                    Database.AddInParameter(command, "@ESTADO", DbType.String, equiposComputoList[i].Estado);
                    Database.AddInParameter(command, "@FLG_EQUIPO_COMPUTO", DbType.String, equiposComputoList[i].FlgEquipoComputo);

                    Database.ExecuteNonQuery(command);
                }
            }
        }

        public List<Hardware> GetEquiposComputoByUsuario(string usuario)
        {
            List<Hardware> listaEquiposComputo = new List<Hardware>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_EQUIPOS_COMPUTO_BY_USUARIO]"))
            {
                Database.AddInParameter(command, "@USUARIO", DbType.String, usuario);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Hardware equipoComputo = new Hardware();

                        equipoComputo.IdHardware = DataUtil.DbValueToDefault<int>(reader["idHardware"]);
                        equipoComputo.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                        equipoComputo.TipoEquipo = DataUtil.DbValueToDefault<string>(reader["tipoEquipo"]);
                        equipoComputo.Marca = DataUtil.DbValueToDefault<string>(reader["marca"]);
                        equipoComputo.Modelo = DataUtil.DbValueToDefault<string>(reader["modelo"]);
                        equipoComputo.Serie = DataUtil.DbValueToDefault<string>(reader["serie"]);
                        equipoComputo.Inventario = DataUtil.DbValueToDefault<string>(reader["inventario"]);
                        equipoComputo.Procesador = DataUtil.DbValueToDefault<string>(reader["procesador"]);
                        equipoComputo.Velocidad = DataUtil.DbValueToDefault<string>(reader["velocidad"]);
                        equipoComputo.Ram = DataUtil.DbValueToDefault<string>(reader["ram"]);
                        equipoComputo.DiscoDuro = DataUtil.DbValueToDefault<string>(reader["discoDuro"]);
                        equipoComputo.TarjetaVideo = DataUtil.DbValueToDefault<string>(reader["tarjetaVideo"]);
                        equipoComputo.Usuario = DataUtil.DbValueToDefault<string>(reader["usuario"]);
                        equipoComputo.Observacion = DataUtil.DbValueToDefault<string>(reader["observacion"]);
                        equipoComputo.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                        equipoComputo.FlgEquipoComputo = DataUtil.DbValueToDefault<string>(reader["flgEquipoComputo"]);

                        listaEquiposComputo.Add(equipoComputo);
                    }
                }
            }

            return listaEquiposComputo;
        }

        public void UpdateHardware(List<Hardware> equiposComputoList)
        {
            for (int i = 0; i < equiposComputoList.Count; i++)
            {
                using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_HARDWARE]"))
                {
                    Database.AddInParameter(command, "@ID_HARDWARE", DbType.Int32, equiposComputoList[i].IdHardware);
                    Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, equiposComputoList[i].IdLaboratorio);
                    Database.AddInParameter(command, "@TIPO_EQUIPO", DbType.String, equiposComputoList[i].TipoEquipo);
                    Database.AddInParameter(command, "@MARCA", DbType.String, equiposComputoList[i].Marca);
                    Database.AddInParameter(command, "@MODELO", DbType.String, equiposComputoList[i].Modelo);
                    Database.AddInParameter(command, "@SERIE", DbType.String, equiposComputoList[i].Serie);
                    Database.AddInParameter(command, "@INVENTARIO", DbType.String, equiposComputoList[i].Inventario);
                    Database.AddInParameter(command, "@PROCESADOR", DbType.String, equiposComputoList[i].Procesador);
                    Database.AddInParameter(command, "@VELOCIDAD", DbType.String, equiposComputoList[i].Velocidad);
                    Database.AddInParameter(command, "@RAM", DbType.String, equiposComputoList[i].Ram);
                    Database.AddInParameter(command, "@DISCO_DURO", DbType.String, equiposComputoList[i].DiscoDuro);
                    Database.AddInParameter(command, "@TARJETA_VIDEO", DbType.String, equiposComputoList[i].TarjetaVideo);
                    Database.AddInParameter(command, "@USUARIO", DbType.String, equiposComputoList[i].Usuario);
                    Database.AddInParameter(command, "@OBSERVACION", DbType.String, equiposComputoList[i].Observacion);
                    Database.AddInParameter(command, "@ESTADO", DbType.String, equiposComputoList[i].Estado);
                    Database.AddInParameter(command, "@FLG_EQUIPO_COMPUTO", DbType.String, equiposComputoList[i].FlgEquipoComputo);

                    Database.ExecuteNonQuery(command);
                }
            }
        }

        public List<Hardware> GetListaEquiposGeneral()
        {
            List<Hardware> listaEquiposGeneral = new List<Hardware>();

            using (IDataReader reader = Database.ExecuteReader("[dbo].[SP_GET_LISTA_EQUIPOS_GENERAL]"))
            {
                while (reader.Read())
                {
                    Hardware hardware = new Hardware();

                    hardware.IdHardware = DataUtil.DbValueToDefault<int>(reader["idHardware"]);
                    hardware.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                    hardware.TipoEquipo = DataUtil.DbValueToDefault<string>(reader["tipoEquipo"]);
                    hardware.Marca = DataUtil.DbValueToDefault<string>(reader["marca"]);
                    hardware.Modelo = DataUtil.DbValueToDefault<string>(reader["modelo"]);
                    hardware.Serie = DataUtil.DbValueToDefault<string>(reader["serie"]);
                    hardware.Inventario = DataUtil.DbValueToDefault<string>(reader["inventario"]);
                    hardware.Procesador = DataUtil.DbValueToDefault<string>(reader["procesador"]);
                    hardware.Velocidad = DataUtil.DbValueToDefault<string>(reader["velocidad"]);
                    hardware.Ram = DataUtil.DbValueToDefault<string>(reader["ram"]);
                    hardware.DiscoDuro = DataUtil.DbValueToDefault<string>(reader["discoDuro"]);
                    hardware.TarjetaVideo = DataUtil.DbValueToDefault<string>(reader["tarjetaVideo"]);
                    hardware.Usuario = DataUtil.DbValueToDefault<string>(reader["usuario"]);
                    hardware.Observacion = DataUtil.DbValueToDefault<string>(reader["observacion"]);
                    hardware.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                    hardware.FlgEquipoComputo = DataUtil.DbValueToDefault<string>(reader["flgEquipoComputo"]);
                    hardware.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                    hardware.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);


                    listaEquiposGeneral.Add(hardware);
                }
            }

            return listaEquiposGeneral;
        }

        public Hardware GetHardwareById(int idHardware)
        {
            Hardware hardware = new Hardware();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_HARDWARE_BY_ID]"))
            {
                Database.AddInParameter(command, "@ID", DbType.Int32, idHardware);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        hardware.IdHardware = DataUtil.DbValueToDefault<int>(reader["idHardware"]);
                        hardware.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                        hardware.TipoEquipo = DataUtil.DbValueToDefault<string>(reader["tipoEquipo"]);
                        hardware.Marca = DataUtil.DbValueToDefault<string>(reader["marca"]);
                        hardware.Modelo = DataUtil.DbValueToDefault<string>(reader["modelo"]);
                        hardware.Serie = DataUtil.DbValueToDefault<string>(reader["serie"]);
                        hardware.Inventario = DataUtil.DbValueToDefault<string>(reader["inventario"]);
                        hardware.Procesador = DataUtil.DbValueToDefault<string>(reader["procesador"]);
                        hardware.Velocidad = DataUtil.DbValueToDefault<string>(reader["velocidad"]);
                        hardware.Ram = DataUtil.DbValueToDefault<string>(reader["ram"]);
                        hardware.DiscoDuro = DataUtil.DbValueToDefault<string>(reader["discoDuro"]);
                        hardware.TarjetaVideo = DataUtil.DbValueToDefault<string>(reader["tarjetaVideo"]);
                        hardware.Usuario = DataUtil.DbValueToDefault<string>(reader["usuario"]);
                        hardware.Observacion = DataUtil.DbValueToDefault<string>(reader["observacion"]);
                        hardware.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                        hardware.FlgEquipoComputo = DataUtil.DbValueToDefault<string>(reader["flgEquipoComputo"]);
                    }
                }
            }
            return hardware;
        }

        public void DeleteEquipoComputoById(int idHardware)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_DELETE_EQUIPO_COMPUTO_BY_ID]"))
            {
                Database.AddInParameter(command, "@ID", DbType.Int32, idHardware);

                Database.ExecuteNonQuery(command);
            }
        }

        public void UpdateEstadoHardwareById(int idHardware, string estado)
        {
            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_UPDATE_HARDWARE_ESTADO]"))
            {
                Database.AddInParameter(command, "@ID_HARDWARE", DbType.Int32, idHardware);
                Database.AddInParameter(command, "@ESTADO", DbType.String, estado);

                Database.ExecuteNonQuery(command);
            }
        }

        public List<Hardware> GetListaHardwareByLaboratorioAndTipo(int idLaboratorio, string flgEquipoComputo)
        {
            List<Hardware> listaEquiposComputo = new List<Hardware>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_HARDWARE_BY_LABORATORIO_AND_TIPO]"))
            {
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, idLaboratorio);
                Database.AddInParameter(command, "@FLG_EQUIPO_COMPUTO", DbType.String, flgEquipoComputo);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Hardware equipoComputo = new Hardware();

                        equipoComputo.IdHardware = DataUtil.DbValueToDefault<int>(reader["idHardware"]);
                        equipoComputo.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                        equipoComputo.TipoEquipo = DataUtil.DbValueToDefault<string>(reader["tipoEquipo"]);
                        equipoComputo.Marca = DataUtil.DbValueToDefault<string>(reader["marca"]);
                        equipoComputo.Modelo = DataUtil.DbValueToDefault<string>(reader["modelo"]);
                        equipoComputo.Serie = DataUtil.DbValueToDefault<string>(reader["serie"]);
                        equipoComputo.Inventario = DataUtil.DbValueToDefault<string>(reader["inventario"]);
                        equipoComputo.Procesador = DataUtil.DbValueToDefault<string>(reader["procesador"]);
                        equipoComputo.Velocidad = DataUtil.DbValueToDefault<string>(reader["velocidad"]);
                        equipoComputo.Ram = DataUtil.DbValueToDefault<string>(reader["ram"]);
                        equipoComputo.DiscoDuro = DataUtil.DbValueToDefault<string>(reader["discoDuro"]);
                        equipoComputo.TarjetaVideo = DataUtil.DbValueToDefault<string>(reader["tarjetaVideo"]);
                        equipoComputo.Usuario = DataUtil.DbValueToDefault<string>(reader["usuario"]);
                        equipoComputo.Observacion = DataUtil.DbValueToDefault<string>(reader["observacion"]);
                        equipoComputo.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                        equipoComputo.FlgEquipoComputo = DataUtil.DbValueToDefault<string>(reader["flgEquipoComputo"]);
                        equipoComputo.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                        equipoComputo.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);

                        listaEquiposComputo.Add(equipoComputo);
                    }
                }
            }

            return listaEquiposComputo;
        }


        public List<Hardware> GetListaHardwareByLaboratorioAndTipoAndNombreUsuario(int idLaboratorio, string flgEquipoComputo, string nombreUsuario)
        {
            List<Hardware> listaEquiposComputo = new List<Hardware>();

            using (DbCommand command = Database.GetStoredProcCommand("[dbo].[SP_GET_LISTA_HARDWARE_BY_LABORATORIO_AND_TIPO_AND_NOMBRE_USUARIO]"))
            {
                Database.AddInParameter(command, "@ID_LABORATORIO", DbType.Int32, idLaboratorio);
                Database.AddInParameter(command, "@FLG_EQUIPO_COMPUTO", DbType.String, flgEquipoComputo);
                Database.AddInParameter(command, "@NOMBRE_USUARIO", DbType.String, nombreUsuario);

                using (IDataReader reader = Database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        Hardware equipoComputo = new Hardware();

                        equipoComputo.IdHardware = DataUtil.DbValueToDefault<int>(reader["idHardware"]);
                        equipoComputo.IdLaboratorio = DataUtil.DbValueToDefault<int>(reader["idLaboratorio"]);
                        equipoComputo.TipoEquipo = DataUtil.DbValueToDefault<string>(reader["tipoEquipo"]);
                        equipoComputo.Marca = DataUtil.DbValueToDefault<string>(reader["marca"]);
                        equipoComputo.Modelo = DataUtil.DbValueToDefault<string>(reader["modelo"]);
                        equipoComputo.Serie = DataUtil.DbValueToDefault<string>(reader["serie"]);
                        equipoComputo.Inventario = DataUtil.DbValueToDefault<string>(reader["inventario"]);
                        equipoComputo.Procesador = DataUtil.DbValueToDefault<string>(reader["procesador"]);
                        equipoComputo.Velocidad = DataUtil.DbValueToDefault<string>(reader["velocidad"]);
                        equipoComputo.Ram = DataUtil.DbValueToDefault<string>(reader["ram"]);
                        equipoComputo.DiscoDuro = DataUtil.DbValueToDefault<string>(reader["discoDuro"]);
                        equipoComputo.TarjetaVideo = DataUtil.DbValueToDefault<string>(reader["tarjetaVideo"]);
                        equipoComputo.Usuario = DataUtil.DbValueToDefault<string>(reader["usuario"]);
                        equipoComputo.Observacion = DataUtil.DbValueToDefault<string>(reader["observacion"]);
                        equipoComputo.Estado = DataUtil.DbValueToDefault<string>(reader["estado"]);
                        equipoComputo.FlgEquipoComputo = DataUtil.DbValueToDefault<string>(reader["flgEquipoComputo"]);
                        equipoComputo.NombreLaboratorio = DataUtil.DbValueToDefault<string>(reader["nombreLaboratorio"]);
                        equipoComputo.NombreFacultad = DataUtil.DbValueToDefault<string>(reader["nombreFacultad"]);

                        listaEquiposComputo.Add(equipoComputo);
                    }
                }
            }

            return listaEquiposComputo;
        }
    }
}
