using gridSample.Design;
using System;
using System.Windows.Forms;
using Utilities;

namespace gridSample.Ui
{
    public partial class MainForm : Form
    {
        private readonly IMainFormNeed _need;
        internal MainForm(IMainFormNeed need)
        {
            _need = need;
            InitializeComponent();
            InitGridView();
            InitGridEvent();
        }

        private void InitGridView()
        {
            var cols = Enum.GetValues(typeof(ColumnType));
            foreach (ColumnType col in cols)
            {
                _dataGridView.Columns.Add("prop", col.ToDispString());
            }
            _dataGridView.RowCount = _need.RowCount;
            _dataGridView.ColumnCount = _need.ColCount;
        }

        private void InitGridEvent()
        {
            _dataGridView.CellValidated += _dataGridView_CellValidated;
        }

        private void _dataGridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var value = _dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            var text = value.ToString();
            var result = _need.TrySetInput(e.RowIndex, text, (ColumnType)e.ColumnIndex);
            if (result.Status is ResultType.Error)
            {
                MessageBox.Show(result.Message);
                value = string.Empty;
            }
        }
    }
}
