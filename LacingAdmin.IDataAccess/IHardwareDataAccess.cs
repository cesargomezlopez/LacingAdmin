using LacingAdmin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.IDataAccess
{
    public interface IHardwareDataAccess
    {
        List<Hardware> GetListaEquiposComputo();
    }
}
