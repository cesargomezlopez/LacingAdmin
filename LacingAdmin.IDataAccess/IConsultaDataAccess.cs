using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface IConsultaDataAccess
    {
        List<Horario> GetListaHorariosXLaboratorio(int idLaboratorio);
        List<Horario> GetListaHorariosXDocente(int idDocente);
        List<Horario> GetListaHorariosXCurso(int idCurso);
    }
}
