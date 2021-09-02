using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760081.Forms.manager
{
    public partial class FormChiTietNguoiLienQuan : Form
    {
        private string g_sUserName;
        private string g_sIdNLQ;
        private Models.LichSuTinhTrangNhiem g_mTinhTrangHienTai = null;
        public FormChiTietNguoiLienQuan(string sUserName, string sMaNguoiLienQuan)
        {
            InitializeComponent();
            g_sUserName = sUserName;
            g_sIdNLQ = sMaNguoiLienQuan;

            this.Load += FormChiTietNguoiLienQuan_Load;
            btnReload.Click += BtnReload_Click;
            btnUpdate.Click += BtnUpdate_Click;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Models.NoiDieuTriCachLy noiDieuTriCachLySelected;

            try
            {
                if (cbbNoiDieuTri.SelectedIndex == 0)
                {
                    noiDieuTriCachLySelected = new Models.NoiDieuTriCachLy { id = -1 };
                }
                else
                {
                    noiDieuTriCachLySelected = Controllers.CtrlNoiDieuTri.Lay(cbbNoiDieuTri.Text);
                }

                if (noiDieuTriCachLySelected.id != g_mTinhTrangHienTai.NoiCachLy || g_mTinhTrangHienTai.TinhTrang != cbbTinhTrang.Text)
                {
                    int lMaNoiDieuTriCu = (int)g_mTinhTrangHienTai.NoiCachLy;

                    if ((noiDieuTriCachLySelected.id == -1 && g_mTinhTrangHienTai.NoiCachLy == null) || noiDieuTriCachLySelected.id==g_mTinhTrangHienTai.NoiCachLy)
                    {
                        Controllers.CtrlTinhTrangNhiem.CapNhat(g_mTinhTrangHienTai, cbbTinhTrang.Text);
                    }
                    else if (noiDieuTriCachLySelected.id==-1 && g_mTinhTrangHienTai.NoiCachLy!=null)
                    {
                        Controllers.CtrlTinhTrangNhiem.CapNhat(g_mTinhTrangHienTai, cbbTinhTrang.Text, null);
                        Controllers.CtrlNoiDieuTri.CapNhatSoLuongHienTai(lMaNoiDieuTriCu);
                    }
                    else if (Controllers.CtrlNoiDieuTri.CoTheTiepNhanThemBenhNhan(cbbNoiDieuTri.Text) == null)
                    {
                        throw new Exception(cbbNoiDieuTri.Text + " khong the tiep nhan benh nhan do qua tai.");
                    }
                    else
                    {
                        Controllers.CtrlTinhTrangNhiem.CapNhat(g_mTinhTrangHienTai, cbbTinhTrang.Text, noiDieuTriCachLySelected.id);

                        Controllers.CtrlNoiDieuTri.CapNhatSoLuongHienTai(lMaNoiDieuTriCu);
                        Controllers.CtrlNoiDieuTri.CapNhatSoLuongHienTai(noiDieuTriCachLySelected.id);
                    }

                    Controllers.CtrlTaiKhoan.GhiNhatKy(g_sUserName, "Cập nhật tình trạng " + g_sIdNLQ + " từ " + g_mTinhTrangHienTai.TinhTrang + " thành " + cbbTinhTrang.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            BtnReload_Click(btnReload, null);
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            List<Models.LichSuTinhTrangNhiem> lichSuTinhTrangNhiems = Controllers.CtrlTinhTrangNhiem.LayDanhSach(g_sIdNLQ);

            if (lichSuTinhTrangNhiems.Count>0)
            {
                g_mTinhTrangHienTai = lichSuTinhTrangNhiems.ElementAtOrDefault(0);
                KhoiTaoPhanCapNhat();
            }

            dgvLichSuTinhTrang.Rows.Clear();

            Models.NoiDieuTriCachLy noiDieuTriCachLy = null;
            foreach (Models.LichSuTinhTrangNhiem item in lichSuTinhTrangNhiems)
            {
                if (item.NoiCachLy==null)
                {
                    noiDieuTriCachLy.Ten = "";
                }
                else
                {
                    noiDieuTriCachLy = Controllers.CtrlNoiDieuTri.Lay((int)item.NoiCachLy);
                }
                dgvLichSuTinhTrang.Rows.Add(item.ThoiGianCapNhat.ToString("yyyy-MM-dd HH:mm:ss"), item.TinhTrang, noiDieuTriCachLy.Ten);
            }
        }

        private void FormChiTietNguoiLienQuan_Load(object sender, EventArgs e)
        {
            KhoiTaoThongTinCaNhan();
            KhoiTaoBangLichSuDieuTri();

            BtnReload_Click(btnReload, e);

            KhoiTaoPhanCapNhat();
        }

        private void KhoiTaoThongTinCaNhan()
        {
            Models.NguoiLienQuan nguoiLienQuan = Controllers.CtrlNguoiLienQuan.TimKiemTheoCmnd(g_sIdNLQ);

            if (nguoiLienQuan == null)
            {
                this.Hide();
                MessageBox.Show("Người liên quan " + g_sIdNLQ + " không tồn tại. Vui lòng kiểm tra lại.");
                this.Dispose();
            }

            Controllers.CtrlTaiKhoan.GhiNhatKy(g_sUserName, "Xem chi tiết" + nguoiLienQuan.Cmnd + " - " + nguoiLienQuan.HoTen);

           lblThongTin.Text = "Số CMND/CCCD: " + nguoiLienQuan.Cmnd;
            lblThongTin.Text += "\nHọ tên: " + nguoiLienQuan.HoTen;
            lblThongTin.Text += "\nNăm sinh: " + nguoiLienQuan.NamSinh;

            Models.Ward ward = Controllers.CtrlKhuVuc.LayPhuongXa(nguoiLienQuan.PhuongXa);
            Models.District district = Controllers.CtrlKhuVuc.LayQuanHuyen(ward.DistrictID);
            Models.Province province = Controllers.CtrlKhuVuc.LayTinhThanh(district.ProvinceId);

            lblThongTin.Text += "\nĐịa chỉ nơi ở: " + String.Format("{0}, {1} {2}, {3} {4}, {5} {6}", nguoiLienQuan.SoNhaDuong, ward.Type, ward.Name, district.Type, district.Name, province.Type, province.Name);

            if (nguoiLienQuan.NguoiLay!=null)
            {
                lblThongTin.Text += "\nLây từ: " + nguoiLienQuan.NguoiLay;
                btnInfoNguoiLay.Tag = nguoiLienQuan.NguoiLay;
            }
            else
            {
                btnInfoNguoiLay.Hide();
            }
        }

        private void KhoiTaoBangLichSuDieuTri()
        {
            dgvLichSuTinhTrang.Rows.Clear();
            dgvLichSuTinhTrang.Columns.Clear();

            dgvLichSuTinhTrang.Columns.Add(FormUtil.CreateDataGridColumn("ngaychuyen", "Thoi gian thay doi"));
            dgvLichSuTinhTrang.Columns.Add(FormUtil.CreateDataGridColumn("tinhtrang", "Tinh trang"));
            dgvLichSuTinhTrang.Columns.Add(FormUtil.CreateDataGridColumn("noicachly", "Noi cach ly"));
        }

        private void KhoiTaoPhanCapNhat()
        {
            List<string> vs = Controllers.CtrlNoiDieuTri.LayTatCa().Select(obj => obj.Ten).ToList();

            cbbTinhTrang.Items.Clear();
            cbbTinhTrang.Items.AddRange(new object[]{ "Âm tính", "F3", "F2", "F1", "F0", "Mất"});

            cbbNoiDieuTri.Items.Clear();
            cbbNoiDieuTri.Items.Add("");
            cbbNoiDieuTri.Items.AddRange(vs.ToArray());

            if (g_mTinhTrangHienTai!=null)
            {
                KhoiTaoCacPhanTuTinhTrang(g_mTinhTrangHienTai.TinhTrang);

                cbbTinhTrang.Text = g_mTinhTrangHienTai.TinhTrang;

                if (g_mTinhTrangHienTai.NoiCachLy==null)
                {
                    cbbNoiDieuTri.SelectedIndex = 0;
                }
                else
                {
                    Models.NoiDieuTriCachLy noiDieuTriCachLy = Controllers.CtrlNoiDieuTri.Lay((int)g_mTinhTrangHienTai.NoiCachLy);

                    cbbNoiDieuTri.Text = noiDieuTriCachLy.Ten;
                }
            }
        }

        private void KhoiTaoCacPhanTuTinhTrang(string sTinhTrang)
        {
            cbbTinhTrang.Items.Clear();

            switch (sTinhTrang)
            {
                case "":
                case "Âm tính":
                    cbbTinhTrang.Items.AddRange(new object[] { "Âm tính", "F3", "F2", "F0", "Mất" });
                    break;
                case "F3":
                    cbbTinhTrang.Items.AddRange(new object[] { "Âm tính", "F3", "F2", "F0", "Mất" });
                    break;
                case "F2":
                    cbbTinhTrang.Items.AddRange(new object[] { "Âm tính", "F2", "F1", "F0", "Mất" });
                    break;
                case "F1":
                    cbbTinhTrang.Items.AddRange(new object[] { "Âm tính", "F1", "F0", "Mất" });
                    break;
                case "F0":
                    cbbTinhTrang.Items.AddRange(new object[] { "Âm tính", "F0", "Mất" });
                    break;
                case "Mất":
                    cbbTinhTrang.Items.AddRange(new object[] { "Mất" });
                    break;
                default:
                    break;
            }
        }
    }
}
