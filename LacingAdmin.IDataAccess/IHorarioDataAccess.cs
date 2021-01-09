using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface IHorarioDataAccess
    {
        List<Horario> GetListaHorarios();

        Horario GetHorarioById(int idHorario);

        void CreateHorario(Horario horario);

        void UpdateHorario(Horario horario);

        void DeleteHorario(int idHorario);

        int GetHorarioExiste(int idLaboratorio, int dia, string horaInicio, string horaFin, int idHorario);
    }
}
