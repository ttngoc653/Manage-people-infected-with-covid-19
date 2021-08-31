namespace _1760081.Forms.admin
{
    partial class FormQuanLyTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.gbxThem = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.grbUsers = new System.Windows.Forms.GroupBox();
            this.gbxLichSu = new System.Windows.Forms.GroupBox();
            this.dgvDanhSachTaiKhoan = new System.Windows.Forms.DataGridView();
            this.dgvLichSuHoatDong = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.cbbQuyen = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbxThem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grbUsers.SuspendLayout();
            this.gbxLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuHoatDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxThem
            // 
            this.gbxThem.Controls.Add(this.label3);
            this.gbxThem.Controls.Add(this.cbbQuyen);
            this.gbxThem.Controls.Add(this.btnCreate);
            this.gbxThem.Controls.Add(this.txtPassword);
            this.gbxThem.Controls.Add(this.label2);
            this.gbxThem.Controls.Add(this.label1);
            this.gbxThem.Controls.Add(this.txtUsername);
            this.gbxThem.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxThem.Location = new System.Drawing.Point(0, 0);
            this.gbxThem.Name = "gbxThem";
            this.gbxThem.Size = new System.Drawing.Size(800, 48);
            this.gbxThem.TabIndex = 0;
            this.gbxThem.TabStop = false;
            this.gbxThem.Text = "Thêm tài khoản";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 48);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grbUsers);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbxLichSu);
            this.splitContainer1.Size = new System.Drawing.Size(800, 402);
            this.splitContainer1.SplitterDistance = 607;
            this.splitContainer1.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(94, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(137, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // grbUsers
            // 
            this.grbUsers.Controls.Add(this.dgvDanhSachTaiKhoan);
            this.grbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbUsers.Location = new System.Drawing.Point(0, 0);
            this.grbUsers.Name = "grbUsers";
            this.grbUsers.Size = new System.Drawing.Size(607, 402);
            this.grbUsers.TabIndex = 0;
            this.grbUsers.TabStop = false;
            this.grbUsers.Text = "Danh sách tài khoản";
            // 
            // gbxLichSu
            // 
            this.gbxLichSu.Controls.Add(this.dgvLichSuHoatDong);
            this.gbxLichSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxLichSu.Location = new System.Drawing.Point(0, 0);
            this.gbxLichSu.Name = "gbxLichSu";
            this.gbxLichSu.Size = new System.Drawing.Size(189, 402);
            this.gbxLichSu.TabIndex = 0;
            this.gbxLichSu.TabStop = false;
            this.gbxLichSu.Text = "Lịch sử hoạt động của";
            // 
            // dgvDanhSachTaiKhoan
            // 
            this.dgvDanhSachTaiKhoan.AllowUserToAddRows = false;
            this.dgvDanhSachTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvDanhSachTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSachTaiKhoan.Location = new System.Drawing.Point(3, 16);
            this.dgvDanhSachTaiKhoan.Name = "dgvDanhSachTaiKhoan";
            this.dgvDanhSachTaiKhoan.Size = new System.Drawing.Size(601, 383);
            this.dgvDanhSachTaiKhoan.TabIndex = 0;
            // 
            // dgvLichSuHoatDong
            // 
            this.dgvLichSuHoatDong.AllowUserToAddRows = false;
            this.dgvLichSuHoatDong.AllowUserToDeleteRows = false;
            this.dgvLichSuHoatDong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuHoatDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichSuHoatDong.Location = new System.Drawing.Point(3, 16);
            this.dgvLichSuHoatDong.Name = "dgvLichSuHoatDong";
            this.dgvLichSuHoatDong.ReadOnly = true;
            this.dgvLichSuHoatDong.Size = new System.Drawing.Size(183, 383);
            this.dgvLichSuHoatDong.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(332, 19);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(123, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(719, 17);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Tạo";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // cbbQuyen
            // 
            this.cbbQuyen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbQuyen.FormattingEnabled = true;
            this.cbbQuyen.Location = new System.Drawing.Point(550, 19);
            this.cbbQuyen.Name = "cbbQuyen";
            this.cbbQuyen.Size = new System.Drawing.Size(121, 21);
            this.cbbQuyen.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(503, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Quyền:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormQuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.gbxThem);
            this.Name = "FormQuanLyTaiKhoan";
            this.ShowIcon = false;
            this.Text = "Quản lý tài khoản";
            this.gbxThem.ResumeLayout(false);
            this.gbxThem.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grbUsers.ResumeLayout(false);
            this.gbxLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuHoatDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxThem;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grbUsers;
        private System.Windows.Forms.GroupBox gbxLichSu;
        private System.Windows.Forms.DataGridView dgvDanhSachTaiKhoan;
        private System.Windows.Forms.DataGridView dgvLichSuHoatDong;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbQuyen;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}