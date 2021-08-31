using _1760081.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760081.Forms.manager
{
    public partial class FormThemNguoiLienQuan : Form
    {
        private String g_sUserName;

        public FormThemNguoiLienQuan(string sUserName)
        {
            InitializeComponent();
            g_sUserName = sUserName;
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
            txtNguoiLay.TextChanged += CbbNguoiLienQuan_TextChanged;
            //comboBoxDiaChi.Validating += ComboBoxDiaChi_Validating;

            cbbTinh.SelectedValueChanged += CbbTinh_SelectedValueChanged;
            cbbQuan.SelectedValueChanged += CbbQuan_SelectedValueChanged; txtNguoiLay.LostFocus += TxtNguoiLay_LostFocus;

            this.Load += Nguoinhiemcovid_Load;

            btnAdd.Click += BtnAdd_Click;
        }

        private void TxtNguoiLay_LostFocus(object sender, EventArgs e)
        {
            cbbNguoiLienQuan.DroppedDown = false;
        }

        private void CbbNguoiLienQuan_Validating (object sender, CancelEventArgs e)
        {
            if (txtNguoiLay.Text.Trim ().Length > 0 && Controllers.CtrlNguoiLienQuan.TimKiemTheoCmnd (txtNguoiLay.Text.Trim ()) == null)
            {
                errorProviderGeneral.SetError (cbbNguoiLienQuan, "Nguoi lay khong ton tai.");
            }
            else
            {
                errorProviderGeneral.SetError (cbbNguoiLienQuan, "");
            }
        }

        private void ComboBoxTT_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderGeneral.SetError(ctrl, "Chua chon tinh trang");
            }
            else
            {
                errorProviderGeneral.SetError(ctrl, "");
            }
        }

        private void CbbNguoiLienQuan_SelectedValueChanged(object sender, EventArgs e)
        {
            txtNguoiLay.TextChanged -= CbbNguoiLienQuan_TextChanged;

            string sSelected = cbbNguoiLienQuan.Text;
            txtNguoiLay.Text = sSelected.Split(' ').ElementAt(0);

            txtNguoiLay.TextChanged += CbbNguoiLienQuan_TextChanged;
            txtNguoiLay.Focus();
            txtNguoiLay.SelectionStart = txtNguoiLay.Text.Length;
        }

        private void CbbNguoiLienQuan_TextChanged(object sender, EventArgs e)
        {
            string sKey = txtNguoiLay.Text.Trim();
            List<String> dsNguoiLay = Controllers.CtrlNguoiLienQuan.TimKiem(sKey);
            cbbNguoiLienQuan.Items.Clear();
            cbbNguoiLienQuan.Items.AddRange(dsNguoiLay.ToArray());

            cbbNguoiLienQuan.DroppedDown = true;
            Cursor.Current = Cursors.Default;
            cbbNguoiLienQuan.SelectionStart = sKey.Length;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CbbNguoiLienQuan_Validating(txtNguoiLay, null);

            foreach (Control ctrl in this.Controls)
            {
                string sValidate = errorProviderGeneral.GetError (ctrl);
                if (sValidate.Length != 0)
                {
                    MessageBox.Show ("Co thong tin sai. Vui long kiem tra lai thong tin.");
                    return;
                }
            }

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
                };

                if (cbbNguoiLienQuan.Text.Trim().Length > 0)
                {
                    Models.NguoiLienQuan nguoiLay = CtrlNguoiLienQuan.TimKiemTheoCmnd(cbbNguoiLienQuan.Text.Trim());

                    nguoiLienQuan.NguoiLay = nguoiLay.Cmnd;
                }

                Models.NoiDieuTriCachLy iNoiDieuTriCachLy = Controllers.CtrlNoiDieuTri.CoTheTiepNhanThemBenhNhan(cbbNoiDieuTriCachLy.Text.Trim());
                if (iNoiDieuTriCachLy==null)
                {
                    throw new Exception("Noi cach ly khong the tiep nhan them benh nhan.");
                }

                nguoiLienQuan.LichSuTinhTrangNhiems.Add(new Models.LichSuTinhTrangNhiem
                {
                    Cmnd = nguoiLienQuan.Cmnd,
                    LaHienTai = true,
                    NoiCachLy = iNoiDieuTriCachLy.id,
                    ThoiGianCapNhat = DateTime.Now,
                    TinhTrang = comboBoxTT.Text.Trim(),
                    NoiDieuTriCachLy = iNoiDieuTriCachLy
                });

                if (Controllers.CtrlNguoiLienQuan.Them(nguoiLienQuan))
                {

                }
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
                errorProviderGeneral.SetError(ctrl, "Chua chon phuong");
            }
            else
            {
                errorProviderGeneral.SetError(ctrl, "");
            }
        }

        private void CbbQuan_SelectedValueChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            cbbPhuong.Items.Clear();

            cbbPhuong.Items.AddRange(Controllers.CtrlKhuVuc.LayDanhSachTenPhuongXa(cbbTinh.Text.Trim(), ctrl.Text.Trim()).ToArray());
        }

        private void CbbTinh_SelectedValueChanged(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            cbbQuan.Items.Clear();

            cbbQuan.Items.AddRange(Controllers.CtrlKhuVuc.LayDanhSachTenQuanHuyen(cbbTinh.Text.Trim()).ToArray());
        }

        private void CbbQuan_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderGeneral.SetError(ctrl, "Chua chon quan huyen");
            }
            else
            {
                errorProviderGeneral.SetError(ctrl, "");
            }
        }

        private void TxtSoNhaDuong_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderGeneral.SetError(ctrl, "Chua nhap so nha va duong");
            }
            else
            {
                errorProviderGeneral.SetError(ctrl, "");
            }
        }

        private void CbbTinh_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderGeneral.SetError(ctrl, "Chua chon tinh/thanh pho");
            }
            else
            {
                errorProviderGeneral.SetError(ctrl, "");
            }
        }

        private void Nguoinhiemcovid_Load(object sender, EventArgs e)
        {
            cbbTinh.Items.Clear();
            cbbTinh.Items.Add("");

            cbbNguoiLienQuan.Items.Clear();
            cbbNoiDieuTriCachLy.Items.Clear();

            cbbTinh.Items.AddRange(Controllers.CtrlKhuVuc.LayDanhSachTenTinhThanhPho().ToArray());
            cbbNoiDieuTriCachLy.Items.AddRange (Controllers.CtrlNoiDieuTri.LayTatCa ().Select (obj => obj.Ten).ToArray());
        }

        private void CbbNoiDieuTriCachLy_Validating(object sender, CancelEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (ctrl.Text.Length==0)
            {
                errorProviderGeneral.SetError(ctrl, "Chua chon noi dieu tri");
            }
            else
            {
                errorProviderGeneral.SetError(ctrl, "");
            }
        }

        private void TxtHT_Validating(object sender, CancelEventArgs e)
        {

            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderGeneral.SetError(ctrl, "Ban phai nhap ho ten.");

            }
            else
            {
                errorProviderGeneral.SetError(ctrl, "");
            }


        }
        private void TxtCMND_Validating(object sender, CancelEventArgs e)
        {

            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderGeneral.SetError(ctrl, "Ban phai nhap cmnd hoac cccd.");
            }
            else if (!(new Regex("^(([0-9]{10})|([0-9]{12}))$")).IsMatch(ctrl.Text.Trim()))
            {
                errorProviderGeneral.SetError (ctrl, "So cmnd hoac cccd khong hop le.");
            }
            else
            {
                errorProviderGeneral.SetError(ctrl, "");
            }


        }
        private void TxtNamSinh_Validating(object sender, CancelEventArgs e)
        {

            Control ctrl = (Control)sender;
            if (ctrl.Text.Length == 0)
            {
                errorProviderGeneral.SetError(ctrl, "Ban phai nhap nam sinh.");
            }
            else if (!(new Regex("^((19|20)([0-9]{2}))$").IsMatch(ctrl.Text.Trim())))
            {
                errorProviderGeneral.SetError (ctrl, "Nam sinh khong hop le.");
            }
            else
            {
                errorProviderGeneral.SetError(ctrl, "");
            }


        }

    }
}
