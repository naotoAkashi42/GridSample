using gridSample.Core;
using gridSample.Design;
using gridSample.Ui;
using System;
using System.Collections.Generic;
using Utilities;

namespace gridSample.Coodinator
{
    internal class MainFormAgent : IMainFormNeed
    {
        private readonly GridDataValidator _validator;
        private readonly List<GridData> _dataList = new List<GridData>();
        private const int DATA_COUNT = 5;

        public MainFormAgent()
        {
            _validator = new GridDataValidator();
            InitDataList();
        }

        public int ColCount => Enum.GetValues(typeof(ColumnType)).Length;

        public int RowCount => DATA_COUNT;

        public ValidateResult TrySetInput(int dataIndex, string text, ColumnType type)
        {
            var editData = _dataList[dataIndex];
            var func = _validator.GetValidateFunc(type);
            if (!func(text)) return ValidateResult.CreateError("値が不正です。");

            SetValue(editData, text, type);
            return ValidateResult.CreateSuccess();
        }

        private void InitDataList()
        {
            for (var count = 0; count < DATA_COUNT; count++)
            {
                _dataList.Add(new GridData());
            }
        }

        private void SetValue(GridData target, string text, ColumnType type)
        {
            switch (type)
            {
                case ColumnType.Id:
                    target.Id = text.ToId();
                    break;
                case ColumnType.Name:
                    break;
                default:
                    break;
            }
        }

        private class GridDataValidator
        {
            private Dictionary<ColumnType, Func<string, bool>> _validateFuncTable = new Dictionary<ColumnType, Func<string, bool>>();

            public GridDataValidator()
            {
                _validateFuncTable.Add(ColumnType.Id, Id.Validate);
                _validateFuncTable.Add(ColumnType.Name, Name.Validate);
            }

            public Func<string, bool> GetValidateFunc(ColumnType type)
            {
                return _validateFuncTable[type];
            }
        }
    }
}
