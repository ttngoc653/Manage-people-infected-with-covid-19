using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760081.main
{
    public partial class FormQuanLy : Form
    {
        private String g_sUserName;

        public FormQuanLy(string userName, string quyen)
        {
            if (quyen!="1")
            {
                MessageBox.Show("Khong co quyen vao trang chu cua quan tri.\nVui long vao lai chuong trinh va dang nhap lai vao tai khoan khac.");
                Application.Exit();
                return;
            }

            InitializeComponent();

            g_sUserName = userName;
            this.Text += " - Chao mung quan ly " + userName;
            this.FormClosed += FormQuanLy_FormClosed;
            this.Load += FormQuanLy_Load;
            this.Activated += FormQuanLy_Activated;
            btnThemNguoiLienQuan.Click += BtnThemNguoiLienQuan_Click;
        }

        private void FormQuanLy_Activated (object sender, EventArgs e)
        {

        }

        private void BtnThemNguoiLienQuan_Click (object sender, EventArgs e)
        {
            main.FormThemNguoiLienQuan frm = new FormThemNguoiLienQuan (g_sUserName);
            frm.ShowDialog ();
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            InitializeTableGridListNguoiLienQuan();
        }

        private void FormQuanLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region Utils
        private void InitializeTableGridListNguoiLienQuan()
        {
            dgvMain.Columns.Add(CreateDataGridColumn("hoten", "Ho ten"));
            dgvMain.Columns.Add(CreateDataGridColumn("dinhdanh", "So CMND/CCCD"));
            dgvMain.Columns.Add(CreateDataGridColumn("namsinh", "Nam sinh"));
            dgvMain.Columns.Add(CreateDataGridColumn("sonhaduong", "So nha, duong"));
            dgvMain.Columns.Add(CreateDataGridColumn("phuongxa", "Phuong/Xa"));
            dgvMain.Columns.Add(CreateDataGridColumn("quanhuyen", "Quan/Huyen"));
            dgvMain.Columns.Add(CreateDataGridColumn("tinhthanh", "Tinh/Thanh pho"));
            dgvMain.Columns.Add(CreateDataGridColumn("trangthai", "Trang thai hien tai"));
            dgvMain.Columns.Add(CreateDataGridColumn("noidangdieutricachlyhientai", "Noi dang dieu tri cach ly hien tai"));
        }

        private DataGridViewTextBoxColumn CreateDataGridColumn(string name, string text)
        {
            DataGridViewTextBoxColumn viewTextBoxColumn = new DataGridViewTextBoxColumn();
            viewTextBoxColumn.HeaderText = text;
            viewTextBoxColumn.Name = name;
            viewTextBoxColumn.ToolTipText = "Nhap de sap xep theo cot";
            return viewTextBoxColumn;
        }

        private void AddListNguoiNhiemToDataGrid (string sKey)
        {

        }
        #endregion
    }
}
