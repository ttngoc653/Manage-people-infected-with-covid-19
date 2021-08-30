using _1760081.Controllers;
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
    public partial class FormThemNguoiLienQuan : Form
    {
        private String global_sUserName;

        public FormThemNguoiLienQuan()
        {
            InitializeComponent();
            txtHT.Validating += TxtHT_Validating;
            txtCMND.Validating += TxtCMND_Validating;
            txtNamSinh.Validating += TxtNamSinh_Validating;
            cbbTinh.Validating += CbbTinh_Validating;
            cbbQuan.Validating += CbbQuan_Validating;
            cbbPhuong.Validating += CbbPhuong_Validating;
            txtSoNhaDuong.Validating += TxtSoNhaDuong_Validating;
            comboBoxTT.Validating += ComboBoxTT_Validating;
            cbbNoiDieuTriCachLy.Validating += CbbNoiDieuTriCachLy_Validating;
            cbbNguoiLienQuan.SelectedValueChanged += CbbNguoiLienQuan_SelectedValueChanged;
            //comboBoxDiaChi.Validating += ComboBoxDiaChi_Validating;

            cbbTinh.SelectedValueChanged += CbbTinh_SelectedValueChanged;
            cbbQuan.SelectedValueChanged += CbbQuan_SelectedValueChanged;

            this.Load += Nguoinhiemcovid_Load;

            txtNguoiLienQuan.TextChanged += TxtNguoiLienQuan_TextChanged;

            btnAdd.Click += BtnAdd_Click;
        }

        private void ComboBoxTT_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderTinhTrang.SetError(ctrl, "Chua chon tinh trang");
            }
            else
            {
                errorProviderTinhTrang.SetError(ctrl, "");
            }
        }

        private void CbbNguoiLienQuan_SelectedValueChanged(object sender, EventArgs e)
        {
            txtNguoiLienQuan.Text = cbbNguoiLienQuan.Text.Split(new char[' ']).ElementAt(0);
        }

        private void TxtNguoiLienQuan_TextChanged(object sender, EventArgs e)
        {
            string sKey = txtNguoiLienQuan.Text;
            List<String> dsNguoiLay = Controllers.CtrlNguoiLienQuan.TimKiem(sKey);
            cbbNguoiLienQuan.Items.Clear();
            cbbNguoiLienQuan.Items.AddRange(dsNguoiLay.ToArray());
            cbbNguoiLienQuan.DroppedDown = true;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Ward ward = CtrlKhuVuc.LayPhuongXa(cbbPhuong.Text.Trim(), cbbQuan.Text.Trim(), cbbTinh.Text.Trim());

                Models.NguoiLienQuan nguoiLienQuan = new Models.NguoiLienQuan
                {
                    Cmnd = txtCMND.Text.Trim(),
                    HoTen = txtHT.Text.Trim(),
                    NamSinh = short.Parse(txtNamSinh.Text.Trim()),
                    SoNhaDuong = txtSoNhaDuong.Text.Trim(),
                    PhuongXa = ward.Id,
                    Ward = ward
                };

                if (txtNguoiLienQuan.Text.Trim().Length > 0)
                {
                    Models.NguoiLienQuan nguoiLay = CtrlNguoiLienQuan.TimKiemTheoCmnd(txtNguoiLienQuan.Text.Trim());

                    nguoiLienQuan.NguoiLienQuan2 = nguoiLay;
                    nguoiLienQuan.NguoiLay = nguoiLay.Cmnd;
                }

                Models.NoiDieuTriCachLy iNoiDieuTriCachLy = Controllers.CtrlNoiDieuTri.CoTheTiepNhanThemBenhNhan(cbbNoiDieuTriCachLy.Text.Trim());
                if (iNoiDieuTriCachLy==null)
                {
                    throw new Exception("Noi cach ly khong the tiep nhan them benh nhan.");
                }

                nguoiLienQuan.LichSuTinhTrangNhiems.Add(new Models.LichSuTinhTrangNhiem { 
                    Cmnd=nguoiLienQuan.Cmnd,
                    LaHienTai=true,
                    NoiCachLy=iNoiDieuTriCachLy.id,
                    ThoiGianCapNhat=DateTime.Now,
                    TinhTrang=comboBoxTT.Text.Trim(),
                    NoiDieuTriCachLy=iNoiDieuTriCachLy
                });

                bool giaTriTraVe = Controllers.CtrlNguoiLienQuan.Them(nguoiLienQuan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Vui long kiem tra lai thong tin.");
            }
        }

        private void CbbPhuong_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderPhuong.SetError(ctrl, "Chua chon phuong");
            }
            else
            {
                errorProviderPhuong.SetError(ctrl, "");
            }
        }

        private void CbbQuan_SelectedValueChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            cbbPhuong.Items.Clear();

            cbbPhuong.Items.AddRange(Controllers.CtrlKhuVuc.LayDanhSachTenPhuongXa(cbbTinh.Text.Trim(), ctrl.Text.Trim()).ToArray());

            cbbPhuong.SelectedIndex = 0;
        }

        private void CbbTinh_SelectedValueChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            cbbQuan.Items.Clear();

            cbbQuan.Items.AddRange(Controllers.CtrlKhuVuc.LayDanhSachTenQuanHuyen(cbbTinh.Text.Trim()).ToArray());
            cbbQuan.SelectedIndex = 0;
        }

        private void CbbQuan_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderSoNhaDuong.SetError(ctrl, "Chua chon quan huyen");
            }
            else
            {
                errorProviderSoNhaDuong.SetError(ctrl, "");
            }
        }

        private void TxtSoNhaDuong_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderSoNhaDuong.SetError(ctrl, "Chua nhap so nha va duong");
            }
            else
            {
                errorProviderSoNhaDuong.SetError(ctrl, "");
            }
        }

        private void CbbTinh_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderNoiDieuTri.SetError(ctrl, "Chua chon tinh/thanh pho");
            }
            else
            {
                errorProviderNoiDieuTri.SetError(ctrl, "");
            }
        }

        private void Nguoinhiemcovid_Load(object sender, EventArgs e)
        {
            cbbTinh.Items.Clear();
            cbbTinh.Items.Add("");

            cbbNguoiLienQuan.Items.Clear();
            cbbNoiDieuTriCachLy.Items.Clear();

            cbbTinh.Items.AddRange(Controllers.CtrlKhuVuc.LayDanhSachTenTinhThanhPho().ToArray());
        }

        private void CbbNoiDieuTriCachLy_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length==0)
            {
                errorProviderNoiDieuTri.SetError(ctrl, "Chua chon noi dieu tri");
            }
            else
            {
                errorProviderNoiDieuTri.SetError(ctrl, "");
            }
        }

        private void TxtHT_Validating(object sender, CancelEventArgs e)
        {

            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderHoTen.SetError(ctrl, "Ban phai nhap ho ten.");

            }
            else
            {
                errorProviderHoTen.SetError(ctrl, "");
            }


        }
        private void TxtCMND_Validating(object sender, CancelEventArgs e)
        {

            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderCMND.SetError(ctrl, "Ban phai nhap cmnd hoac cccd.");

            }
            else
            {
                errorProviderCMND.SetError(ctrl, "");
            }


        }
        private void TxtNamSinh_Validating(object sender, CancelEventArgs e)
        {

            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderNamSinh.SetError(ctrl, "Ban phai nhap nam sinh.");

            }
            else
            {
                errorProviderNamSinh.SetError(ctrl, "");
            }


        }

    }
}
