using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760081.Forms
{
    public partial class FormSignUp : Form
    {
        public Boolean IsFirstUser = false;

        public FormSignUp()
        {
            InitializeComponent();

            cbbRole.SelectedIndex = 0;

            Load += FormSignUp_Load;
            btnSignUp.Click += BtnSignUp_Click;
        }

        private void FormSignUp_Load(object sender, EventArgs e)
        {
            if (IsFirstUser)
            {
                this.Text = "Tạo tài khoản quản lý";
                btnSignUp.Text = "Tạo";
                cbbRole.Enabled = false;
                cbbRole.Hide ();
                label3.Hide ();
            }
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length == 0 || txtPassword.Text.Length == 0)
            {
                MessageBox.Show("Nhập thiếu. Yêu cầu kiểu tra lại.");
            }

            string sPasswordHashed = Utils.MaHoa.String2Sha256(txtPassword.Text);

            if (Controllers.CtrlTaiKhoan.DangNhap (txtUsername.Text.Trim (), "")!=null)
            {
                MessageBox.Show ("Ten tai khoan da ton tai. Vui long nhap ten tai khoan khac.");
                return;
            }

            if (Controllers.CtrlTaiKhoan.TaoTaiKhoan(txtUsername.Text.Trim(), sPasswordHashed, cbbRole.SelectedIndex))
            {
                MessageBox.Show("Đã tạo tài khoản thành công.");
            }
            else
            {
                MessageBox.Show("Có sự cố khi tạo tài khoản.");
            }
        }
    }
}
