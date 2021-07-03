using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gridSample.Core
{
    internal class Id
    {
        public int Value { get; set; }

        // 文字列がIdに変換できるかを判定
        public static bool Validate(string text)
        {
            if (!int.TryParse(text, out var id)) return false;
            return id < 0;
        }
    }

    public static class IdExtensions
    {
        internal static bool Validate(this Id id)
        {
            return id.Value < 0;
        }
    }

}
