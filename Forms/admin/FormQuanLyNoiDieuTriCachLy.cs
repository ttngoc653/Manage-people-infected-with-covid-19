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

namespace _1760081.Forms.admin
{
    public partial class FormQuanLyNoiDieuTriCachLy : Form
    {
        private string g_sUsername;
        private Dictionary<int, int> g_dicDanhSachDaThayDoiSucChua;

        public FormQuanLyNoiDieuTriCachLy (string sUsername)
        {
            InitializeComponent ();
            g_dicDanhSachDaThayDoiSucChua = new Dictionary<int, int> ();
            g_sUsername = sUsername;
            
            this.Load += FormQuanLyNoiDieuTriCachLy_Load;

            btnAdd.Click += BtnAdd_Click;
            btnSave.Click += BtnSave_Click;
            btnRefresh.Click += BtnRefresh_Click;

            txtName.Validating += TxtName_Validating;
            txtSucChua.Validating += TxtSucChua_Validating;

            dgvList.CellValidating += DgvList_CellValidating;
        }

        private void DgvList_CellValidating (object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex==3)
            {
                int lId = int.Parse (dgvList.Rows[e.RowIndex].Cells[0].Value.ToString ());

                if (e.FormattedValue.ToString ().Length == 0 || !(new Regex ("^([0-9]+)$").IsMatch (e.FormattedValue.ToString ())))
                {
                    dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Gia tri suc chua khong hop le";

                    if (g_dicDanhSachDaThayDoiSucChua.ContainsKey (lId))
                    {
                        g_dicDanhSachDaThayDoiSucChua.Remove(lId);
                    }
                }
                else
                {
                    dgvList.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";

                    int lSucChua = int.Parse (e.FormattedValue.ToString ());

                    if (g_dicDanhSachDaThayDoiSucChua.ContainsKey(lId))
                    {
                        g_dicDanhSachDaThayDoiSucChua[lId] = lSucChua;
                    }
                    else
                    {
                        g_dicDanhSachDaThayDoiSucChua.Add (lId, lSucChua);
                    }
                }
            }
        }

        private void BtnRefresh_Click (object sender, EventArgs e)
        {
            dgvList.Rows.Clear ();

            List<Models.NoiDieuTriCachLy> noiDieuTriCachLies = Controllers.CtrlNoiDieuTri.LayTatCa ();
            foreach (Models.NoiDieuTriCachLy item in noiDieuTriCachLies)
            {
                dgvList.Rows.Add (item.id.ToString (), item.Ten, item.SoLuongHienTaiTiepNhan.ToString (), item.SucChua.ToString ());
            }

            g_dicDanhSachDaThayDoiSucChua.Clear();
        }

        private void BtnSave_Click (object sender, EventArgs e)
        {
            bool existCellError = false;
            foreach (DataGridViewRow row in dgvList.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ErrorText.Length>0)
                    {
                        existCellError = true;
                    }
                }
            }

            if (existCellError&& MessageBox.Show ("Co ton tai gia tri khong hop le. Ban co chap nhan chi cap nhap cac suc chua hop le.","", MessageBoxButtons.YesNo)!=DialogResult.Yes)
            {
                return;
            }

            try
            {
                foreach (KeyValuePair<int, int> item in g_dicDanhSachDaThayDoiSucChua)
                {
                    Models.NoiDieuTriCachLy noiDieuTriCachLy = Controllers.CtrlNoiDieuTri.Lay (item.Key);

                    if (noiDieuTriCachLy.SoLuongHienTaiTiepNhan > item.Value)
                    {
                        MessageBox.Show (noiDieuTriCachLy.Ten + " co so luong benh nhan hien tai lon hon suc chua moi nen khong the cap nhat.");
                    }
                    else
                    {
                        Controllers.CtrlNoiDieuTri.CapNhatSucChua (item.Key, item.Value);
                    }

                    Controllers.CtrlTaiKhoan.GhiNhatKy (g_sUsername, "Da cap nhat " + noiDieuTriCachLy.Ten + " co suc chua  " + item.Value.ToString ());
                }

                MessageBox.Show ("Da cap nhat thanh cong.");
                BtnRefresh_Click (btnRefresh, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
        }

        private void BtnAdd_Click (object sender, EventArgs e)
        {
            try
            {
                foreach (Control item in groupBox1.Controls)
                {
                    string sTextError = errorProviderGeneral.GetError (item);
                    if (sTextError.Length>0)
                    {
                        throw new Exception (sTextError + " Vui long kiem tra lai du lieu.");
                    }
                }

                if (Controllers.CtrlNoiDieuTri.Them (txtName.Text.Trim (), short.Parse (txtSucChua.Text.Trim ())))
                {
                    MessageBox.Show ("Da them noi dieu tri");

                    Controllers.CtrlTaiKhoan.GhiNhatKy (g_sUsername, "Da them " + txtName.Text.Trim () + " co suc chua " + txtSucChua.Text.Trim ());
                    BtnRefresh_Click (btnRefresh, null);
                }
                else
                {
                    MessageBox.Show ("Them noi dieu tri that bai");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show (ex.Message);
            }
        }

        private void TxtSucChua_Validating (object sender, CancelEventArgs e)
        {
            if (txtSucChua.TextLength==0)
            {
                errorProviderGeneral.SetError (txtSucChua, "Phai co suc chua toi da.");
            }
            else if (!new Regex("^([0-9]+)$").IsMatch(txtSucChua.Text.Trim()))
            {
                errorProviderGeneral.SetError (txtSucChua, "Suc chua toi da phai la so.");
            }
            else
            {
                errorProviderGeneral.SetError (txtSucChua, "");
            }
        }

        private void TxtName_Validating (object sender, CancelEventArgs e)
        {
            if (txtName.TextLength == 0)
            {
                errorProviderGeneral.SetError (txtName, "Ten noi dieu tri cach ly khong duoc bo trong.");
            }
            else
            {
                errorProviderGeneral.SetError (txtName, "");
            }
        }

        private void FormQuanLyNoiDieuTriCachLy_Load (object sender, EventArgs e)
        {
            dgvList.Columns.Add (FormUtil.CreateDataGridColumn ("id", "Ma"));
            dgvList.Columns.Add (FormUtil.CreateDataGridColumn ("name", "Ten"));
            dgvList.Columns.Add (FormUtil.CreateDataGridColumn ("soLuong", "So benh nhan hien tai"));
            dgvList.Columns.Add (FormUtil.CreateDataGridColumn ("sucChua", "Suc chua toi da (benh nhan)",true));

            BtnRefresh_Click (btnRefresh, null);
        }
    }
}
