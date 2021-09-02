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
            dgvMain.CellDoubleClick += DgvMain_CellDoubleClick;
            txtSearch.TextChanged += TxtSearch_TextChanged;

            btnThongKe.Enabled = false;

            btnSort.Click += BtnSort_Click;
        }

        private void BtnSort_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicNameHeaderText = new Dictionary<string, string>();

            try
            {
                foreach (DataGridViewColumn column in dgvMain.Columns)
                {
                    dicNameHeaderText.Add(column.HeaderText, column.Name);
                }

                FormCustomSort frm = new FormCustomSort(dicNameHeaderText);

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Dictionary<string, Models.SortType> listCanSort = (Dictionary<string, Models.SortType>)frm.GetCustomSortResult();

                    List<string> listItem = listCanSort.Keys.ToList();

                    for (int i = listItem.Count-1; i >= 0; i--)
                    {
                        if (listCanSort[listItem[i]]==  Models.SortType.A_Z)
                        {
                            dgvMain.Sort(dgvMain.Columns[listItem[i]], ListSortDirection.Ascending);
                        }
                        if (listCanSort[listItem[i]] == Models.SortType.Z_A)
                        {
                            dgvMain.Sort(dgvMain.Columns[listItem[i]], ListSortDirection.Descending);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            bool hasText = false;
            string sKey = txtSearch.Text;
            object sText;
            DuaDanhSachNguoiLienQuanVaoBang();
            for (int iRow = 0; iRow < dgvMain.Rows.Count && txtSearch.Text.Length > 0; iRow++)
            {
                for (int iColumn = 0; iColumn < dgvMain.Rows[iRow].Cells.Count; iColumn++)
                {
                    sText = dgvMain.Rows[iRow].Cells[iColumn].Value;
                    if (sText != null && sText.ToString().IndexOf(sKey) >= 0)
                    {
                        hasText = true;
                        break;
                    }
                }

                if (hasText == false)
                {
                    dgvMain.Rows.RemoveAt(iRow);
                    iRow = iRow - 1;
                    hasText = false;
                }
            }
        }

        private void DgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                string sCmnd = dgvMain.Rows[e.RowIndex].Cells[1].Value.ToString();

                manager.FormChiTietNguoiLienQuan frm = new manager.FormChiTietNguoiLienQuan(g_sUserName, sCmnd);
                frm.ShowDialog();

            }
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
                DuaDanhSachNguoiLienQuanVaoBang();
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
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn("dinhdanh", "So CMND/CCCD"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn("namsinh", "Nam sinh"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn("sonhaduong", "So nha, duong"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn("phuongxa", "Phuong/Xa"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn("quanhuyen", "Quan/Huyen"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn("tinhthanh", "Tinh/Thanh pho"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn("trangthai", "Trang thai hien tai"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn("noidangdieutricachlyhientai", "Noi dang dieu tri cach ly hien tai"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn("capnhatluc", "Cap nhat luc"));
            dgvMain.Columns.Add(Forms.FormUtil.CreateDataGridColumn("laytu", "Lay tu"));
        }

        private void DuaDanhSachNguoiLienQuanVaoBang()
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

                listString.Add(ward.Type + " " + ward.Name);
                listString.Add(district.Type + " " + district.Name);
                listString.Add(province.Type + " " + province.Name);

                Models.LichSuTinhTrangNhiem tinhTrangNhiem = Controllers.CtrlNguoiLienQuan.TinhTrangHienTai(item.Cmnd);
                if (tinhTrangNhiem != null)
                {
                    listString.Add(tinhTrangNhiem.TinhTrang);

                    if (tinhTrangNhiem.NoiCachLy != null)
                    {
                        Models.NoiDieuTriCachLy noiDieuTriCachLy = Controllers.CtrlNoiDieuTri.LayTatCa().Where(obj => obj.id == tinhTrangNhiem.NoiCachLy).FirstOrDefault();

                        listString.Add(noiDieuTriCachLy.Ten);
                    }
                    else
                    {
                        listString.Add("");
                    }
                    listString.Add(tinhTrangNhiem.ThoiGianCapNhat.ToString("yyyy-MM-dd HH:mm:ss"));
                }

                if (item.NguoiLay!=null)
                {
                    listString.Add(item.NguoiLay);
                }
                else
                {
                    listString.Add("");
                }

                int row = dgvMain.Rows.Add(listString.ToArray());

                foreach (DataGridViewCell cell in dgvMain.Rows[row].Cells)
                {
                    cell.ToolTipText = "Nhấp 2 lần liên tiếp để xem chi tiết hoặc cập nhật tình trạng của " + item.HoTen;
                }
            }
        }
        #endregion
    }
}
