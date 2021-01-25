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
    }
}
