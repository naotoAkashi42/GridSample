using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridSample.Core
{
    internal class GridData
    {
        public Id Id { get; set; }
        public Name Name { get; set; }
    }

    public static class GridDataConvLogic
    {
        internal static Id ToId(this string text)
        {
            var value = int.Parse(text);
            return new Id() { Value = value };
        }
    }
}
