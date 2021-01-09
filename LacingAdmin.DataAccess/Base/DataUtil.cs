using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LacingAdmin.DataAccess.Base
{
    public class DataUtil
    {
        public static Nullable<T> DbValueToNullable<T>(object dbValue) where T : struct
        {
            Nullable<T> returnValue = null;

            if ((dbValue != null) && (dbValue != DBNull.Value) && (dbValue != string.Empty))
            {
                returnValue = (T)Convert.ChangeType(dbValue, typeof(T));
            }

            return returnValue;
        }

        public static T DbValueToDefault<T>(object obj)
        {
            if (obj == null || obj == DBNull.Value || obj == string.Empty) return default(T);
            else { return (T)Convert.ChangeType(obj, typeof(T)); }
        }

        public static List<string> SplitData(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return new List<string>();
            }
            return text.Split('\\').ToList();
        }   
    }
}
