using Microsoft.Reporting.WinForms;
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
    public partial class FormThongKe : Form
    {
        private string g_sUsername;

        [Obsolete]
        public FormThongKe(string sUsername)
        {
            InitializeComponent();

            g_sUsername = sUsername;

            this.Load += FormThongKe_Load;

            dtpFrom.ValueChanged += Dtp_ValueChanged;
            dtpTo.ValueChanged += Dtp_ValueChanged;

            btnXemTKTT.Click += BtnXemTKTT_Click;
            btnTKChung.Click += BtnTKChung_Click;
        }

        [Obsolete]
        private void BtnTKChung_Click(object sender, EventArgs e)
        {
            try
            {
                Controllers.CtrlTaiKhoan.GhiNhatKy(g_sUsername, "Xem thống kê ca nhiễm ngày " + dtpIn.Text + " trong " + cbbTinhNgay.Text);

                ReportDataSource rds = new ReportDataSource("DataSetMain", Controllers.CtrlThongKe.GenThongKeSoLuongCaNhiem(cbbTinhNgay.SelectedIndex == 0 ? null : cbbTinhNgay.Text, dtpIn.Value));

                ReportParameter rpDiaPhuong = new ReportParameter("Param_DiaPhuong", cbbTinhNgay.Text.ToString());
                ReportParameter rpNgay = new ReportParameter("Param_Ngay", dtpIn.Text.ToString());

                this.reportViewer.LocalReport.ReportPath = "ReportThongKeNguoiNhiemTheoNgay.rdlc";
                reportViewer.LocalReport.DataSources.Add(rds);
                reportViewer.LocalReport.SetParameters(new ReportParameter[] {
                    rpDiaPhuong,
                    rpNgay
                });
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }
        }

        private void BtnXemTKTT_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control item in tabPage1.Controls)
                {
                    if (errorProvider.GetError(item).Length > 0)
                    {
                        MessageBox.Show("Vui lòng kiểm tra đầu vào.");
                        return;
                    }
                }

                Controllers.CtrlTaiKhoan.GhiNhatKy(g_sUsername, "Xem thống kê tình trạng từ " + dtpFrom.Text + " đến " + dtpTo.Text +" trong "+cbbTinh.Text);

                ReportDataSource rds = new ReportDataSource("DataSetMain", Controllers.CtrlThongKe.GenThongKeSoLuongTinhTrang(cbbTinh.SelectedIndex == 0 ? null : cbbTinh.Text, dtpFrom.Value, dtpTo.Value));

                ReportParameter rpDiaPhuong = new ReportParameter("Param_DiaPhuong", cbbTinh.Text.ToString());
                ReportParameter rpTuNgay = new ReportParameter("Param_TuNgay", dtpFrom.Text.ToString());
                ReportParameter rpDenNgay = new ReportParameter("Param_DenNgay", dtpTo.Text.ToString());

                this.reportViewer.LocalReport.ReportPath = "ReportThongKeTinhTrang.rdlc";
                reportViewer.LocalReport.DataSources.Add(rds);
                reportViewer.LocalReport.SetParameters(new ReportParameter[] {
                    rpDiaPhuong,
                    rpTuNgay,
                    rpDenNgay
                });
                reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer.ZoomPercent = 100;
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\n"+ex.StackTrace);
            }
        }

        private void Dtp_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFrom.Value>dtpTo.Value)
            {
                errorProvider.SetError(dtpFrom, "Ngày bắt đầu phải sau ngày kết thúc.");
                errorProvider.SetError(dtpTo, "Ngày bắt đầu phải sau ngày kết thúc.");
            }
            else
            {
                errorProvider.SetError(dtpFrom, "");
                errorProvider.SetError(dtpTo, "");
            }
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = Controllers.CtrlTinhTrangNhiem.LayThoiGianDauTien();

            List<string> provinces = Controllers.CtrlKhuVuc.LayDanhSachTenTinhThanhPho();

            cbbTinh.Items.Clear();
            cbbTinhNgay.Items.Clear();

            cbbTinh.Items.Add("Cả nước");
            cbbTinhNgay.Items.Add("Cả nước");

            cbbTinh.Items.AddRange(provinces.ToArray());
            cbbTinhNgay.Items.AddRange(provinces.ToArray());

            cbbTinh.SelectedIndex = 0;
            cbbTinhNgay.SelectedIndex = 0;
        }
    }
}
