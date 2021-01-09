using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.DataAccess.Base
{
    public class RepositoryBase
    {
        private Database _Database;

        internal Database Database
        {
            get { return _Database; }
            set { _Database = value; }
        }

        public RepositoryBase()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            Database = factory.Create("cn_LacingAdmin") as Database;
        }
    }
}
