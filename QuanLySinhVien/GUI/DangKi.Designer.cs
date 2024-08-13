namespace ToDoList
{
    partial class fDangKi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDangKi));
            this.txbDK_TaiKhoan = new System.Windows.Forms.TextBox();
            this.txbDK_MatKhau = new System.Windows.Forms.TextBox();
            this.txbDK_XnMatKhau = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDangKi = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txbDK_TaiKhoan
            // 
            this.txbDK_TaiKhoan.Location = new System.Drawing.Point(193, 179);
            this.txbDK_TaiKhoan.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txbDK_TaiKhoan.Name = "txbDK_TaiKhoan";
            this.txbDK_TaiKhoan.Size = new System.Drawing.Size(237, 29);
            this.txbDK_TaiKhoan.TabIndex = 2;
            // 
            // txbDK_MatKhau
            // 
            this.txbDK_MatKhau.Location = new System.Drawing.Point(193, 228);
            this.txbDK_MatKhau.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txbDK_MatKhau.Name = "txbDK_MatKhau";
            this.txbDK_MatKhau.Size = new System.Drawing.Size(237, 29);
            this.txbDK_MatKhau.TabIndex = 4;
            this.txbDK_MatKhau.UseSystemPasswordChar = true;
            // 
            // txbDK_XnMatKhau
            // 
            this.txbDK_XnMatKhau.Location = new System.Drawing.Point(193, 275);
            this.txbDK_XnMatKhau.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txbDK_XnMatKhau.Name = "txbDK_XnMatKhau";
            this.txbDK_XnMatKhau.Size = new System.Drawing.Size(237, 29);
            this.txbDK_XnMatKhau.TabIndex = 6;
            this.txbDK_XnMatKhau.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(17, 184);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(17, 234);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mật khẩu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(17, 278);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Xác nhận mật khẩu:";
            // 
            // btnDangKi
            // 
            this.btnDangKi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDangKi.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKi.Location = new System.Drawing.Point(246, 329);
            this.btnDangKi.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnDangKi.Name = "btnDangKi";
            this.btnDangKi.Size = new System.Drawing.Size(125, 37);
            this.btnDangKi.TabIndex = 10;
            this.btnDangKi.Text = "Đăng kí";
            this.btnDangKi.UseVisualStyleBackColor = false;
            this.btnDangKi.Click += new System.EventHandler(this.btnDangKi_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ToDoList.Properties.Resources.person;
            this.pictureBox1.Location = new System.Drawing.Point(231, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(160, 137);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // fDangKi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 407);
            this.Controls.Add(this.btnDangKi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbDK_XnMatKhau);
            this.Controls.Add(this.txbDK_MatKhau);
            this.Controls.Add(this.txbDK_TaiKhoan);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "fDangKi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng Kí ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txbDK_TaiKhoan;
        private System.Windows.Forms.TextBox txbDK_MatKhau;
        private System.Windows.Forms.TextBox txbDK_XnMatKhau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDangKi;
    }
}