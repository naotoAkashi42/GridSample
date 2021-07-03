using gridSample.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace gridSample.Ui
{
    internal interface IMainFormNeed
    {
        // 入力文字列をデータモデルに反映
        ValidateResult TrySetInput(int dataIndex, string text, ColumnType type);
        int ColCount { get; }
        int RowCount { get; }
    }
}
