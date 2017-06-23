using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineSimulator
{
    public class EnumUtilities
    {
        public static Dictionary<string, T> EnumToDict<T>()
        {
            Dictionary<string, T> result = new Dictionary<string, T>();
            T[] entries = (T[])Enum.GetValues(typeof(T));
            foreach (var entry in entries)
                result.Add(entry.ToString(), entry);
            return result;
        }
    }
}
