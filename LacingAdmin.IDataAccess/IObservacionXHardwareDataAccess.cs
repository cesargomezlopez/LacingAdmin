﻿using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface IObservacionXHardwareDataAccess
    {
        void CreateObservacionTipoSoftware(ObservacionXHardware observacionXHardware);

        void CreateObservacionTipoHardware(ObservacionXHardware observacionXHardware);

        void CreateObservacionTipoEquipoGeneral(ObservacionXHardware observacionXHardware);

        void DeleteObservacion(int idObservacion);

        void UpdateObservacionTipoHardware(ObservacionXHardware observacionXHardware);

        void UpdateObservacionTipoSoftware(ObservacionXHardware observacionXHardware);

        List<ObservacionXHardware> GetListaObservacionesXHardwareByIdAndTipo(int idHardware, string tipo);
    }
}