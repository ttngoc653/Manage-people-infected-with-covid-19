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

        public FormThongKe(string sUsername)
        {
            InitializeComponent();

            g_sUsername = sUsername;

            this.Load += FormThongKe_Load;
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
