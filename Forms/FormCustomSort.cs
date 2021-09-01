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
        private Dictionary<string, SortType> result;
        private Dictionary<string, string> input;

        public FormCustomSort(Dictionary<string,string> mapColumnNameText)
        {
            InitializeComponent();

            input = mapColumnNameText;

            lbxQuery.Items.Clear();
            lbxSort.Items.Clear();
            foreach (KeyValuePair<string,string> item in input)
            {
                lbxQuery.Items.Add(item.Value);
            }

            btnAdd.Click += Btn_Click;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Dictionary<string, SortType></returns>
        public object CustomSortResult()
        {
            return result;
        }
    }
}
