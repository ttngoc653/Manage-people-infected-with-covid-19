namespace _1760081.Forms.admin
{
    partial class FormQuanLyNoiDieuTriCachLy
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
            this.components = new System.ComponentModel.Container ();
            this.label1 = new System.Windows.Forms.Label ();
            this.txtName = new System.Windows.Forms.TextBox ();
            this.groupBox1 = new System.Windows.Forms.GroupBox ();
            this.label2 = new System.Windows.Forms.Label ();
            this.btnAdd = new System.Windows.Forms.Button ();
            this.txtSucChua = new System.Windows.Forms.TextBox ();
            this.groupBox2 = new System.Windows.Forms.GroupBox ();
            this.dgvList = new System.Windows.Forms.DataGridView ();
            this.btnSave = new System.Windows.Forms.Button ();
            this.btnRefresh = new System.Windows.Forms.Button ();
            this.errorProviderGeneral = new System.Windows.Forms.ErrorProvider (this.components);
            this.label3 = new System.Windows.Forms.Label ();
            this.groupBox1.SuspendLayout ();
            this.groupBox2.SuspendLayout ();
            ((System.ComponentModel.ISupportInitialize) (this.dgvList)).BeginInit ();
            ((System.ComponentModel.ISupportInitialize) (this.errorProviderGeneral)).BeginInit ();
            this.SuspendLayout ();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point (6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size (118, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên nơi điều trị cách ly:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point (130, 21);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size (329, 20);
            this.txtName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add (this.txtSucChua);
            this.groupBox1.Controls.Add (this.btnAdd);
            this.groupBox1.Controls.Add (this.label2);
            this.groupBox1.Controls.Add (this.label1);
            this.groupBox1.Controls.Add (this.txtName);
            this.groupBox1.Location = new System.Drawing.Point (12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size (776, 51);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point (497, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size (56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sức chứa:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point (695, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size (75, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Áp dụng";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // txtSucChua
            // 
            this.txtSucChua.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSucChua.Location = new System.Drawing.Point (559, 21);
            this.txtSucChua.Name = "txtSucChua";
            this.txtSucChua.Size = new System.Drawing.Size (100, 20);
            this.txtSucChua.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add (this.label3);
            this.groupBox2.Controls.Add (this.btnRefresh);
            this.groupBox2.Controls.Add (this.btnSave);
            this.groupBox2.Controls.Add (this.dgvList);
            this.groupBox2.Location = new System.Drawing.Point (1, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size (799, 380);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point (6, 48);
            this.dgvList.Name = "dgvList";
            this.dgvList.Size = new System.Drawing.Size (787, 326);
            this.dgvList.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point (730, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size (51, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point (11, 19);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size (124, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Làm mới danh sách";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // errorProviderGeneral
            // 
            this.errorProviderGeneral.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point (141, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size (210, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Có thể cập nhật sức chứa ngay trong bảng";
            // 
            // FormQuanLyNoiDieuTriCachLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size (800, 450);
            this.Controls.Add (this.groupBox2);
            this.Controls.Add (this.groupBox1);
            this.MinimumSize = new System.Drawing.Size (400, 200);
            this.Name = "FormQuanLyNoiDieuTriCachLy";
            this.ShowIcon = false;
            this.Text = "Quản lý Nơi điều trị/cách ly";
            this.groupBox1.ResumeLayout (false);
            this.groupBox1.PerformLayout ();
            this.groupBox2.ResumeLayout (false);
            this.groupBox2.PerformLayout ();
            ((System.ComponentModel.ISupportInitialize) (this.dgvList)).EndInit ();
            ((System.ComponentModel.ISupportInitialize) (this.errorProviderGeneral)).EndInit ();
            this.ResumeLayout (false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSucChua;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ErrorProvider errorProviderGeneral;
        private System.Windows.Forms.Label label3;
    }
}