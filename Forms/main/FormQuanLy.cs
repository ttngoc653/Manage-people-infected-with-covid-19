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
    public partial class FormQuanLy : Form
    {
        private String g_sUserName;

        public FormQuanLy(string userName, string quyen)
        {
            if (quyen!="1")
            {
                MessageBox.Show("Khong co quyen vao trang chu cua quan ly.\nVui long vao lai chuong trinh va dang nhap lai vao tai khoan khac.");
                Application.Exit();
                return;
            }

            InitializeComponent();

            g_sUserName = userName;
            this.Text += " - Chao mung quan ly " + userName;
            this.FormClosed += FormQuanLy_FormClosed;
            this.Load += FormQuanLy_Load;
            btnReload.Click += BtnReload_Click;
            btnThemNguoiLienQuan.Click += BtnThemNguoiLienQuan_Click;

            txtSearch.Enabled = false;
            btnThongKe.Enabled = false;
        }

        private void BtnThemNguoiLienQuan_Click (object sender, EventArgs e)
        {
            manager.FormThemNguoiLienQuan frm = new manager.FormThemNguoiLienQuan (g_sUserName);
            frm.ShowDialog ();
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            InitializeTableGridListNguoiLienQuan();

            BtnReload_Click (btnReload, null);
        }

        private void FormQuanLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnReload_Click (object sender, EventArgs e)
        {
            try
            {
                dgvMain.Rows.Clear();

                List<Models.NguoiLienQuan> nguoiLienQuans = Controllers.CtrlNguoiLienQuan.LayToanBo();

                foreach (Models.NguoiLienQuan item in nguoiLienQuans)
                {
                    List<string> listString = new List<string>();

                    listString.Add(item.HoTen);
                    listString.Add(item.Cmnd);
                    listString.Add(item.NamSinh.ToString());
                    listString.Add(item.SoNhaDuong);

                    Models.Ward ward = Controllers.CtrlKhuVuc.LayPhuongXa(item.PhuongXa);
                    Models.District district = Controllers.CtrlKhuVuc.LayQuanHuyen(ward.DistrictID);
                    Models.Province province = Controllers.CtrlKhuVuc.LayTinhThanh(district.ProvinceId);

                    listString.Add(ward.Name);
                    listString.Add(district.Name);
                    listString.Add(province.Name);

                    Models.LichSuTinhTrangNhiem tinhTrangNhiem = Controllers.CtrlNguoiLienQuan.TinhTrangHienTai(item.Cmnd);
                    if (tinhTrangNhiem == null)
                    {

                    }
                    else
                    {
                        listString.Add(tinhTrangNhiem.TinhTrang);

                        Models.NoiDieuTriCachLy noiDieuTriCachLy = Controllers.CtrlNoiDieuTri.LayTatCa().Where(obj => obj.id == tinhTrangNhiem.NoiCachLy).FirstOrDefault();

                        listString.Add(noiDieuTriCachLy.Ten);
                        listString.Add(tinhTrangNhiem.ThoiGianCapNhat.ToString());
                    }

                    dgvMain.Rows.Add(listString.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region Utils
        private void InitializeTableGridListNguoiLienQuan()
        {
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn("hoten", "Ho ten"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn ("dinhdanh", "So CMND/CCCD"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn ("namsinh", "Nam sinh"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn ("sonhaduong", "So nha, duong"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn ("phuongxa", "Phuong/Xa"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn ("quanhuyen", "Quan/Huyen"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn ("tinhthanh", "Tinh/Thanh pho"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn ("trangthai", "Trang thai hien tai"));
            dgvMain.Columns.Add (Forms.FormUtil.CreateDataGridColumn ("noidangdieutricachlyhientai", "Noi dang dieu tri cach ly hien tai"));
            dgvMain.Columns.Add (Forms.FormUtil.CreateDataGridColumn ("capnhatluc", "Cap nhat luc"));
        }
        #endregion
    }
}
