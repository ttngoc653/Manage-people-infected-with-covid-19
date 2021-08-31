using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760081.Forms
{
    class FormUtil
    {
        internal static DataGridViewColumn CreateDataGridColumn (string name, string text, bool canEdit = false, DataTypeColumn typeColumn= DataTypeColumn.TextBox)
        {
            DataGridViewColumn viewTextBoxColumn = new DataGridViewTextBoxColumn ();

            if (typeColumn== DataTypeColumn.CheckBox)
            {
                viewTextBoxColumn = new DataGridViewCheckBoxColumn ();
            }

            viewTextBoxColumn.HeaderText = text;
            viewTextBoxColumn.Name = name;
            viewTextBoxColumn.ReadOnly = !canEdit;
            viewTextBoxColumn.ToolTipText = "Nhap de sap xep theo cot";
            return viewTextBoxColumn;
        }
    }

    enum DataTypeColumn
    {
        TextBox,CheckBox
    }
}
