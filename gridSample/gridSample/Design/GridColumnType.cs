using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridSample.Design
{
    internal enum ColumnType
    {
        Id,
        Name,
    }

    public static class ColumnTypeExtension
    {
        private static Dictionary<ColumnType, string> _dic = new Dictionary<ColumnType, string>();
        static ColumnTypeExtension()
        {
            _dic.Add(ColumnType.Id, "ID");
            _dic.Add(ColumnType.Name, "Name");
        }

        internal static string ToDispString(this ColumnType col)
        {
            return _dic[col];
        }
    }
}
