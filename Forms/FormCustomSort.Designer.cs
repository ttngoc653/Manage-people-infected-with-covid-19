
namespace _1760081.Forms
{
    partial class FormCustomSort
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxQuery = new System.Windows.Forms.ListBox();
            this.lbxSort = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtAZ = new System.Windows.Forms.RadioButton();
            this.rbtZA = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxQuery
            // 
            this.lbxQuery.FormattingEnabled = true;
            this.lbxQuery.Location = new System.Drawing.Point(12, 44);
            this.lbxQuery.Name = "lbxQuery";
            this.lbxQuery.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxQuery.Size = new System.Drawing.Size(180, 186);
            this.lbxQuery.TabIndex = 0;
            // 
            // lbxSort
            // 
            this.lbxSort.FormattingEnabled = true;
            this.lbxSort.Location = new System.Drawing.Point(317, 44);
            this.lbxSort.Name = "lbxSort";
            this.lbxSort.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxSort.Size = new System.Drawing.Size(209, 186);
            this.lbxSort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Các cột không được sắp xếp:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(314, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 32);
            this.label2.TabIndex = 4;
            this.label2.Text = "Các cột được sắp xếp theo độ ưu tiên theo thứ tự từ trên xuống:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtZA);
            this.groupBox1.Controls.Add(this.rbtAZ);
            this.groupBox1.Location = new System.Drawing.Point(198, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(113, 68);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sắp xếp kiểu:";
            // 
            // rbtAZ
            // 
            this.rbtAZ.AutoSize = true;
            this.rbtAZ.Checked = true;
            this.rbtAZ.Location = new System.Drawing.Point(6, 19);
            this.rbtAZ.Name = "rbtAZ";
            this.rbtAZ.Size = new System.Drawing.Size(45, 17);
            this.rbtAZ.TabIndex = 0;
            this.rbtAZ.TabStop = true;
            this.rbtAZ.Text = "A..Z";
            this.rbtAZ.UseVisualStyleBackColor = true;
            // 
            // rbtZA
            // 
            this.rbtZA.AutoSize = true;
            this.rbtZA.Location = new System.Drawing.Point(6, 42);
            this.rbtZA.Name = "rbtZA";
            this.rbtZA.Size = new System.Drawing.Size(45, 17);
            this.rbtZA.TabIndex = 1;
            this.rbtZA.Text = "Z..A";
            this.rbtZA.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(198, 147);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(113, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(198, 176);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(113, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(451, 236);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 8;
            this.btnApply.Text = "Áp dụng";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnAddAll
            // 
            this.btnAddAll.Location = new System.Drawing.Point(198, 118);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(113, 23);
            this.btnAddAll.TabIndex = 9;
            this.btnAddAll.Text = ">>";
            this.btnAddAll.UseVisualStyleBackColor = true;
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Location = new System.Drawing.Point(198, 205);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(113, 23);
            this.btnRemoveAll.TabIndex = 10;
            this.btnRemoveAll.Text = "<<";
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            // 
            // FormCustomSort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 268);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnAddAll);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxSort);
            this.Controls.Add(this.lbxQuery);
            this.Name = "FormCustomSort";
            this.Text = "CustomSort";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxQuery;
        private System.Windows.Forms.ListBox lbxSort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtZA;
        private System.Windows.Forms.RadioButton rbtAZ;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnRemoveAll;
    }
}