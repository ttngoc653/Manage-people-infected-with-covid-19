using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760081.Forms.admin
{
    public partial class FormQuanLyTaiKhoan : Form
    {
        private string g_sUsername;

        public FormQuanLyTaiKhoan (string sUsername)
        {
            InitializeComponent ();

            g_sUsername = sUsername;

            this.Text += " của " + sUsername;
            gbxLichSu.Text = "Nhấp vào tài khoản bất kỳ để xem lịch sử";

            this.Load += FormQuanLyTaiKhoan_Load;
            
            txtUsername.Validating += TxtUsername_Validating;
            txtPassword.Validating += TxtPassword_Validating;

            dgvDanhSachTaiKhoan.CellClick += DgvDanhSachTaiKhoan_CellClick;
            dgvDanhSachTaiKhoan.CellContentClick += DgvDanhSachTaiKhoan_CellValueChanged;

            btnCreate.Click += BtnCreate_Click;
        }

        private void DgvDanhSachTaiKhoan_CellValueChanged (object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string sUserName = dgvDanhSachTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString ();
                string sChecked = dgvDanhSachTaiKhoan.Rows[e.RowIndex].Cells[1].Value.ToString ();
                Console.WriteLine (sChecked);
            }
        }

        private void BtnCreate_Click (object sender, EventArgs e)
        {
            foreach (Control item in gbxThem.Controls)
            {
                if (errorProvider1.GetError (item).Length > 0)
                {
                    MessageBox.Show ("Vui long kiem tra lai du lieu da nhap.");
                    item.Focus ();
                    return;
                }
            }

            if (Controllers.CtrlTaiKhoan.DaCoTaiKhoan (txtUsername.Text.Trim ()))
            {
                MessageBox.Show ("Ten dang nhap bi trung. Vui long kiem tra lai.");
            }

            try
            {
                string sPasswordHashed = Utils.MaHoa.String2Sha256 (txtPassword.Text.Trim ());

                if (Controllers.CtrlTaiKhoan.TaoTaiKhoan (txtUsername.Text.Trim (), sPasswordHashed, cbbQuyen.SelectedIndex + 1))
                {
                    MessageBox.Show ("Da tao tai khoan thanh cong.");
                }
                else
                {
                    MessageBox.Show ("Khong tao duoc tai khoan");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
        }

        private void DgvDanhSachTaiKhoan_CellClick (object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1&&e.ColumnIndex==-1)
            {
                LoadDanhSachTaiKhoan ();
            }
            if (e.RowIndex>-1)
            {
                dgvLichSuHoatDong.Rows.Clear ();

                string sUserName = dgvDanhSachTaiKhoan.Rows[e.RowIndex].Cells[0].Value.ToString ();
                gbxLichSu.Text = "Lich su hoat dong cua " + sUserName;

                List<Models.LichSuHoatDong> lichSuHoatDongs = Controllers.CtrlTaiKhoan.LayLichSuHoatDong (sUserName);

                foreach (Models.LichSuHoatDong item in lichSuHoatDongs)
                {
                    dgvLichSuHoatDong.Rows.Add (item.ThoiGian.ToString (), item.HanhDong);
                }
            }
        }

        private void FormQuanLyTaiKhoan_Load (object sender, EventArgs e)
        {
            cbbQuyen.Items.Add ("Quan ly");
            cbbQuyen.Items.Add ("Quan tri");
            cbbQuyen.SelectedIndex = 0;
            
            dgvDanhSachTaiKhoan.Columns.Add (Forms.FormUtil.CreateDataGridColumn ("userName", "TEN TAI KHOAN"));
            dgvDanhSachTaiKhoan.Columns.Add (Forms.FormUtil.CreateDataGridColumn ("khoa", "DA KHOA",true, DataTypeColumn.CheckBox));

            dgvLichSuHoatDong.Columns.Add (Forms.FormUtil.CreateDataGridColumn ("thoigian", "THOI GIAN"));
            dgvLichSuHoatDong.Columns.Add (Forms.FormUtil.CreateDataGridColumn ("noidung", "NOI DUNG"));

            ToolTip tooltip = new ToolTip ();
            tooltip.SetToolTip (grbUsers, "Nhap o goc tren trai bang tai khoan de cap nhat danh sach tai khoan.");

            LoadDanhSachTaiKhoan ();
        }

        private void TxtPassword_Validating (object sender, CancelEventArgs e)
        {
            if (txtPassword.Text.Length==0)
            {
                errorProvider1.SetError (txtPassword, "Mat khau khong duoc trong.");
            }
            else
            {
                errorProvider1.SetError (txtPassword, "");
            }
        }

        private void TxtUsername_Validating (object sender, CancelEventArgs e)
        {
            if (txtUsername.Text.Length == 0)
            {
                errorProvider1.SetError (txtUsername, "Ten tai khoan khong duoc trong.");
            }
            else
            {
                errorProvider1.SetError (txtUsername, "");
            }
        }

        private void LoadDanhSachTaiKhoan ()
        {
            dgvDanhSachTaiKhoan.Rows.Clear ();

            List<Models.TaiKhoan> taiKhoans = Controllers.CtrlTaiKhoan.LayToanBo ();
            foreach (Models.TaiKhoan item in taiKhoans)
            {
                dgvDanhSachTaiKhoan.Rows.Add (item.UserName, item.HasLock);
            }
        }
    }
}
