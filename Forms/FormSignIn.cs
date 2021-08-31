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
    public partial class FormSignIn : Form
    {
        public FormSignIn()
        {
            InitializeComponent();

            Load += FormSignIn_Load;
            btnSignIn.Click += BtnSignIn_Click;
        }

        private void FormSignIn_Load(object sender, EventArgs e)
        {
            if (!Controllers.CtrlTaiKhoan.DaCoTaiKhoan())
            {
                manager.FormSignUp form = new manager.FormSignUp ();
                form.IsFirstUser = true;
                form.ShowDialog();
            }
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            Models.TaiKhoan tk = new Models.TaiKhoan();

            string sUsername = txtUsername.Text.Trim();
            string sPasswordHashed = Utils.MaHoa.String2Sha256(txtPassword.Text);

            tk = Controllers.CtrlTaiKhoan.DangNhap(sUsername, "");
            if (tk == null)
            {
                MessageBox.Show("Khong ton tai ten tai khoan. Vui long kiem tra lai.");
            }
            else if (tk.Password != sPasswordHashed)
            {
                Controllers.CtrlTaiKhoan.GhiNhatKy(sUsername, "Dang nhap that bai do sai mat khau.");
                MessageBox.Show("Sai mat khau.");
            }
            else if (tk.HasLock==true)
            {
                Controllers.CtrlTaiKhoan.GhiNhatKy(sUsername, "Dang nhap that bai do tai khoan da bi khoa.");

                MessageBox.Show("Tai khoan dang bi khoa. Vui lòng lien he quan tri de mo khoa.");
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Hide ();

                Form frm=new Form();
                if (tk.Role==1)
                {
                    frm = new main.FormQuanLy (tk.UserName.Trim (), tk.Role.ToString ());
                }
                else if(tk.Role==2)
                {
                    frm = new main.FormQuanTri (tk.UserName.Trim (), tk.Role.ToString ());
                }
                else
                {
                    MessageBox.Show ("Nguoi dung co quyen khong hop le. Vui long lien he quan tri xu ly.");
                    return;
                }

                Controllers.CtrlTaiKhoan.GhiNhatKy (sUsername, "Dang nhap thanh cong.");

                frm.Show ();
            }
        }
    }
}