namespace _1760081.Forms.main
{
    partial class FormQuanTri
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
            this.btnTaiKhoan = new System.Windows.Forms.Button();
            this.btnNoiDieuTri = new System.Windows.Forms.Button();
            this.lblChaoMung = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTaiKhoan
            // 
            this.btnTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTaiKhoan.Location = new System.Drawing.Point(12, 77);
            this.btnTaiKhoan.Name = "btnTaiKhoan";
            this.btnTaiKhoan.Size = new System.Drawing.Size(197, 62);
            this.btnTaiKhoan.TabIndex = 0;
            this.btnTaiKhoan.Text = "Vào Quản lý\r\nTài khoản";
            this.btnTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // btnNoiDieuTri
            // 
            this.btnNoiDieuTri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoiDieuTri.Location = new System.Drawing.Point(215, 77);
            this.btnNoiDieuTri.Name = "btnNoiDieuTri";
            this.btnNoiDieuTri.Size = new System.Drawing.Size(221, 62);
            this.btnNoiDieuTri.TabIndex = 1;
            this.btnNoiDieuTri.Text = "Vào Quản lý \r\nNơi điều trị cách ly";
            this.btnNoiDieuTri.UseVisualStyleBackColor = true;
            // 
            // lblChaoMung
            // 
            this.lblChaoMung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChaoMung.Location = new System.Drawing.Point(12, 9);
            this.lblChaoMung.Name = "lblChaoMung";
            this.lblChaoMung.Size = new System.Drawing.Size(424, 65);
            this.lblChaoMung.TabIndex = 2;
            this.lblChaoMung.Text = ".......";
            this.lblChaoMung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormQuanTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 151);
            this.Controls.Add(this.lblChaoMung);
            this.Controls.Add(this.btnNoiDieuTri);
            this.Controls.Add(this.btnTaiKhoan);
            this.Name = "FormQuanTri";
            this.ShowIcon = false;
            this.Text = "QLTT Covid 19 - Trang chủ Quản trị";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTaiKhoan;
        private System.Windows.Forms.Button btnNoiDieuTri;
        private System.Windows.Forms.Label lblChaoMung;
    }
}