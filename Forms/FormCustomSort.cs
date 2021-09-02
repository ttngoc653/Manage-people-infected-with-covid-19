using _1760081.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760081.Forms
{
    public partial class FormCustomSort : Form
    {
        private Dictionary<string, SortType> g_dicColumnName_SortType;
        private Dictionary<string, string> g_dicHeaderText_ColumnName;

        public FormCustomSort(Dictionary<string,string> mapColumnNameText)
        {
            InitializeComponent();

            g_dicHeaderText_ColumnName = mapColumnNameText;
            g_dicColumnName_SortType = new Dictionary<string, SortType>();

            lbxQuery.Items.Clear();
            lbxSort.Items.Clear();
            foreach (KeyValuePair<string,string> item in g_dicHeaderText_ColumnName)
            {
                lbxQuery.Items.Add(item.Key);
            }

            btnAdd.Click += BtnAdd_Click;
            btnRemove.Click += BtnRemove_Click;
            btnAddAll.Click += BtnAddAll_Click;
            btnRemoveAll.Click += BtnRemoveAll_Click;

            btnApply.Click += BtnApply_Click;
        }

        private void BtnRemoveAll_Click(object sender, EventArgs e)
        {
            lbxSort.SelectedIndex = -1;

            List<string> listItemValue = new List<string>();

            foreach (object item in lbxSort.Items)
            {
                listItemValue.Add(item.ToString());
            }

            RemoveListSort(listItemValue);
        }

        private void BtnAddAll_Click(object sender, EventArgs e)
        {
            lbxQuery.SelectedIndex = -1;

            List<string> listItemValue = new List<string>();

            foreach (object item in lbxQuery.Items)
            {
                listItemValue.Add(item.ToString());
            }

            AddListSort(listItemValue);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection listItemSelected = lbxSort.SelectedItems;

            List<string> listItemValueSelected = new List<string>();
            foreach (var item in listItemSelected)
            {
                listItemValueSelected.Add(item.ToString());
            }

            lbxSort.SelectedItem = -1;

            RemoveListSort(listItemValueSelected);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection listSelected = lbxQuery.SelectedItems;

            List<string> listItemValueSelected = new List<string>();
            foreach (var item in listSelected)
            {
                listItemValueSelected.Add(item.ToString().Trim());
            }

            lbxQuery.SelectedIndex = -1;

            AddListSort(listItemValueSelected);
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Dictionary<string, SortType> List name of all column sort.</returns>
        public object GetCustomSortResult()
        {
            return g_dicColumnName_SortType;
        }

        private SortType GetSortTypeSelected()
        {
            Models.SortType result= SortType.A_Z;

            if (rbtAZ.Checked)
            {
                result = SortType.A_Z;
            }
            else if (rbtZA.Checked)
            {
                result = SortType.Z_A;
            }

            return result;
        }

        private void AddListSort(List<string> listItemValue)
        {
            Models.SortType sortTypeSelected = GetSortTypeSelected();

            foreach (string item in listItemValue)
            {
                g_dicColumnName_SortType.Add(g_dicHeaderText_ColumnName[item], sortTypeSelected);
                lbxSort.Items.Add(String.Format("{0} ({1})", item, sortTypeSelected.ToString()));

                lbxQuery.Items.Remove(item);
            }
        }

        private void RemoveListSort(List<string> listItemValue)
        {
            string sItemValue = "";
            foreach (string item in listItemValue)
            {
                lbxSort.Items.Remove(item);

                sItemValue = item.Split('(')[0].Trim();
                g_dicColumnName_SortType.Remove(g_dicHeaderText_ColumnName[sItemValue]);

                lbxQuery.Items.Add(sItemValue);
            }
        }
    }
}
