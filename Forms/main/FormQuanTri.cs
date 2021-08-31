using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760081.Forms.main
{
    public partial class FormQuanTri : Form
    {
        private string g_sUsername;

        public FormQuanTri (string sUsername, string sQuyen)
        {
            if (sQuyen!="2")
            {
                MessageBox.Show ("Khong co quyen vao trang chu cua quan tri.\nVui long vao lai chuong trinh va dang nhap lai vao tai khoan khac.");
                Application.Exit ();
            }

            InitializeComponent ();
            g_sUsername = sUsername;
            this.FormClosed += FormQuanTri_FormClosed;
            btnNoiDieuTri.Click += BtnNoiDieuTri_Click;
            btnTaiKhoan.Click += BtnTaiKhoan_Click;

            lblChaoMung.Text = "Chao mung quan tri " + g_sUsername;
        }

        private void BtnTaiKhoan_Click (object sender, EventArgs e)
        {
            Controllers.CtrlTaiKhoan.GhiNhatKy (g_sUsername, "Vao phan phan ly tai khoan");

            Forms.admin.FormQuanLyTaiKhoan frm = new admin.FormQuanLyTaiKhoan (g_sUsername);
            frm.ShowDialog ();
        }

        private void BtnNoiDieuTri_Click (object sender, EventArgs e)
        {
            Controllers.CtrlTaiKhoan.GhiNhatKy (g_sUsername, "Vao phan phan ly noi dieu tri/cach ly");

            Forms.admin.FormQuanLyNoiDieuTriCachLy frm = new admin.FormQuanLyNoiDieuTriCachLy (g_sUsername);
            frm.ShowDialog ();
        }

        private void FormQuanTri_FormClosed (object sender, FormClosedEventArgs e)
        {
            Controllers.CtrlTaiKhoan.GhiNhatKy (g_sUsername, "Thoat chuong trinh");

            Application.Exit ();
        }
    }
}
