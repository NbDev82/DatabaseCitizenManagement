namespace CitizenManagement_EntityFramework
{
    partial class fHomThu
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
            this.rbThuGui = new System.Windows.Forms.RadioButton();
            this.rbThuNhan = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNguoiGui = new System.Windows.Forms.TextBox();
            this.btXoa = new System.Windows.Forms.Button();
            this.btGui = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rtbNoiDung = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbTheoTenNguoi = new System.Windows.Forms.RadioButton();
            this.rbTheoNgay = new System.Windows.Forms.RadioButton();
            this.rbTheoMaNguoi = new System.Windows.Forms.RadioButton();
            this.btTimKiem = new System.Windows.Forms.Button();
            this.tbTimKiem = new System.Windows.Forms.TextBox();
            this.btXem = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpkNgay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMaMail = new System.Windows.Forms.TextBox();
            this.panel21 = new System.Windows.Forms.Panel();
            this.label32 = new System.Windows.Forms.Label();
            this.tbTieuDe = new System.Windows.Forms.TextBox();
            this.dtgvHomThu = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHomThu)).BeginInit();
            this.SuspendLayout();
            // 
            // rbThuGui
            // 
            this.rbThuGui.AutoSize = true;
            this.rbThuGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbThuGui.Location = new System.Drawing.Point(699, 22);
            this.rbThuGui.Margin = new System.Windows.Forms.Padding(4);
            this.rbThuGui.Name = "rbThuGui";
            this.rbThuGui.Size = new System.Drawing.Size(179, 33);
            this.rbThuGui.TabIndex = 30;
            this.rbThuGui.Text = "THƯ ĐÃ GỬI";
            this.rbThuGui.UseVisualStyleBackColor = true;
            this.rbThuGui.CheckedChanged += new System.EventHandler(this.rbThuGui_CheckedChanged);
            // 
            // rbThuNhan
            // 
            this.rbThuNhan.AutoSize = true;
            this.rbThuNhan.Checked = true;
            this.rbThuNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbThuNhan.Location = new System.Drawing.Point(467, 22);
            this.rbThuNhan.Margin = new System.Windows.Forms.Padding(4);
            this.rbThuNhan.Name = "rbThuNhan";
            this.rbThuNhan.Size = new System.Drawing.Size(166, 33);
            this.rbThuNhan.TabIndex = 31;
            this.rbThuNhan.TabStop = true;
            this.rbThuNhan.Text = "THƯ NHẬN";
            this.rbThuNhan.UseVisualStyleBackColor = true;
            this.rbThuNhan.CheckedChanged += new System.EventHandler(this.rbThuNhan_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbNguoiGui);
            this.panel1.Location = new System.Drawing.Point(25, 219);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 44);
            this.panel1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Người gửi:";
            // 
            // tbNguoiGui
            // 
            this.tbNguoiGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNguoiGui.Location = new System.Drawing.Point(179, 4);
            this.tbNguoiGui.Margin = new System.Windows.Forms.Padding(4);
            this.tbNguoiGui.Name = "tbNguoiGui";
            this.tbNguoiGui.ReadOnly = true;
            this.tbNguoiGui.Size = new System.Drawing.Size(237, 34);
            this.tbNguoiGui.TabIndex = 9;
            // 
            // btXoa
            // 
            this.btXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXoa.Location = new System.Drawing.Point(25, 544);
            this.btXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(137, 37);
            this.btXoa.TabIndex = 29;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = false;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btGui
            // 
            this.btGui.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGui.Location = new System.Drawing.Point(170, 544);
            this.btGui.Margin = new System.Windows.Forms.Padding(4);
            this.btGui.Name = "btGui";
            this.btGui.Size = new System.Drawing.Size(271, 37);
            this.btGui.TabIndex = 27;
            this.btGui.Text = "Gửi mail mới";
            this.btGui.UseVisualStyleBackColor = false;
            this.btGui.Click += new System.EventHandler(this.btGui_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel3.Controls.Add(this.rtbNoiDung);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(25, 271);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(430, 253);
            this.panel3.TabIndex = 26;
            // 
            // rtbNoiDung
            // 
            this.rtbNoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbNoiDung.Location = new System.Drawing.Point(4, 41);
            this.rtbNoiDung.Margin = new System.Windows.Forms.Padding(4);
            this.rtbNoiDung.Name = "rtbNoiDung";
            this.rtbNoiDung.ReadOnly = true;
            this.rtbNoiDung.Size = new System.Drawing.Size(412, 197);
            this.rtbNoiDung.TabIndex = 0;
            this.rtbNoiDung.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 7);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nội dung:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.rbTheoTenNguoi);
            this.panel5.Controls.Add(this.rbTheoNgay);
            this.panel5.Controls.Add(this.rbTheoMaNguoi);
            this.panel5.Controls.Add(this.btTimKiem);
            this.panel5.Controls.Add(this.tbTimKiem);
            this.panel5.Controls.Add(this.btXem);
            this.panel5.Location = new System.Drawing.Point(463, 64);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1071, 44);
            this.panel5.TabIndex = 25;
            // 
            // rbTheoTenNguoi
            // 
            this.rbTheoTenNguoi.AutoSize = true;
            this.rbTheoTenNguoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTheoTenNguoi.Location = new System.Drawing.Point(592, 15);
            this.rbTheoTenNguoi.Name = "rbTheoTenNguoi";
            this.rbTheoTenNguoi.Size = new System.Drawing.Size(156, 20);
            this.rbTheoTenNguoi.TabIndex = 20;
            this.rbTheoTenNguoi.TabStop = true;
            this.rbTheoTenNguoi.Text = "Theo tên người gửi";
            this.rbTheoTenNguoi.UseVisualStyleBackColor = true;
            // 
            // rbTheoNgay
            // 
            this.rbTheoNgay.AutoSize = true;
            this.rbTheoNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTheoNgay.Location = new System.Drawing.Point(481, 16);
            this.rbTheoNgay.Name = "rbTheoNgay";
            this.rbTheoNgay.Size = new System.Drawing.Size(105, 20);
            this.rbTheoNgay.TabIndex = 19;
            this.rbTheoNgay.TabStop = true;
            this.rbTheoNgay.Text = "Theo Ngày";
            this.rbTheoNgay.UseVisualStyleBackColor = true;
            // 
            // rbTheoMaNguoi
            // 
            this.rbTheoMaNguoi.AutoSize = true;
            this.rbTheoMaNguoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTheoMaNguoi.Location = new System.Drawing.Point(291, 15);
            this.rbTheoMaNguoi.Name = "rbTheoMaNguoi";
            this.rbTheoMaNguoi.Size = new System.Drawing.Size(156, 20);
            this.rbTheoMaNguoi.TabIndex = 18;
            this.rbTheoMaNguoi.TabStop = true;
            this.rbTheoMaNguoi.Text = "Theo mã người gửi";
            this.rbTheoMaNguoi.UseVisualStyleBackColor = true;
            // 
            // btTimKiem
            // 
            this.btTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTimKiem.Location = new System.Drawing.Point(775, 3);
            this.btTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btTimKiem.Name = "btTimKiem";
            this.btTimKiem.Size = new System.Drawing.Size(122, 37);
            this.btTimKiem.TabIndex = 1;
            this.btTimKiem.Text = "Tìm kiếm";
            this.btTimKiem.UseVisualStyleBackColor = true;
            this.btTimKiem.Click += new System.EventHandler(this.btTimKiem_Click);
            // 
            // tbTimKiem
            // 
            this.tbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTimKiem.Location = new System.Drawing.Point(4, 4);
            this.tbTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.tbTimKiem.Name = "tbTimKiem";
            this.tbTimKiem.Size = new System.Drawing.Size(280, 34);
            this.tbTimKiem.TabIndex = 0;
            // 
            // btXem
            // 
            this.btXem.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btXem.Location = new System.Drawing.Point(905, 3);
            this.btXem.Margin = new System.Windows.Forms.Padding(4);
            this.btXem.Name = "btXem";
            this.btXem.Size = new System.Drawing.Size(158, 37);
            this.btXem.TabIndex = 17;
            this.btXem.Text = "Xem tất cả";
            this.btXem.UseVisualStyleBackColor = true;
            this.btXem.Click += new System.EventHandler(this.btXem_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.dtpkNgay);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(25, 167);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(430, 44);
            this.panel4.TabIndex = 22;
            // 
            // dtpkNgay
            // 
            this.dtpkNgay.Enabled = false;
            this.dtpkNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpkNgay.Location = new System.Drawing.Point(179, 5);
            this.dtpkNgay.Margin = new System.Windows.Forms.Padding(4);
            this.dtpkNgay.Name = "dtpkNgay";
            this.dtpkNgay.Size = new System.Drawing.Size(237, 34);
            this.dtpkNgay.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 7);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 29);
            this.label4.TabIndex = 2;
            this.label4.Text = "Ngày:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.tbMaMail);
            this.panel6.Location = new System.Drawing.Point(25, 64);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(430, 44);
            this.panel6.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 7);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mã mail:";
            // 
            // tbMaMail
            // 
            this.tbMaMail.Enabled = false;
            this.tbMaMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMaMail.Location = new System.Drawing.Point(179, 4);
            this.tbMaMail.Margin = new System.Windows.Forms.Padding(4);
            this.tbMaMail.Name = "tbMaMail";
            this.tbMaMail.ReadOnly = true;
            this.tbMaMail.Size = new System.Drawing.Size(237, 34);
            this.tbMaMail.TabIndex = 0;
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel21.Controls.Add(this.label32);
            this.panel21.Controls.Add(this.tbTieuDe);
            this.panel21.Location = new System.Drawing.Point(25, 115);
            this.panel21.Margin = new System.Windows.Forms.Padding(4);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(430, 44);
            this.panel21.TabIndex = 21;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(4, 7);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(110, 29);
            this.label32.TabIndex = 2;
            this.label32.Text = "Tiêu đề:";
            // 
            // tbTieuDe
            // 
            this.tbTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTieuDe.Location = new System.Drawing.Point(179, 4);
            this.tbTieuDe.Margin = new System.Windows.Forms.Padding(4);
            this.tbTieuDe.Name = "tbTieuDe";
            this.tbTieuDe.ReadOnly = true;
            this.tbTieuDe.Size = new System.Drawing.Size(237, 34);
            this.tbTieuDe.TabIndex = 0;
            // 
            // dtgvHomThu
            // 
            this.dtgvHomThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvHomThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHomThu.Location = new System.Drawing.Point(463, 115);
            this.dtgvHomThu.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvHomThu.Name = "dtgvHomThu";
            this.dtgvHomThu.RowHeadersWidth = 51;
            this.dtgvHomThu.Size = new System.Drawing.Size(1071, 466);
            this.dtgvHomThu.TabIndex = 20;
            this.dtgvHomThu.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dtgvHomThu_DataBindingComplete);
            this.dtgvHomThu.SelectionChanged += new System.EventHandler(this.dtgvHomThu_SelectionChanged);
            // 
            // fHomThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1621, 598);
            this.Controls.Add(this.rbThuGui);
            this.Controls.Add(this.rbThuNhan);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btGui);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel21);
            this.Controls.Add(this.dtgvHomThu);
            this.Name = "fHomThu";
            this.Text = "fHomThu";
            this.Load += new System.EventHandler(this.fHomThu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHomThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbThuGui;
        private System.Windows.Forms.RadioButton rbThuNhan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNguoiGui;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btGui;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox rtbNoiDung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btTimKiem;
        private System.Windows.Forms.TextBox tbTimKiem;
        private System.Windows.Forms.Button btXem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpkNgay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMaMail;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox tbTieuDe;
        private System.Windows.Forms.DataGridView dtgvHomThu;
        private System.Windows.Forms.RadioButton rbTheoNgay;
        private System.Windows.Forms.RadioButton rbTheoMaNguoi;
        private System.Windows.Forms.RadioButton rbTheoTenNguoi;
    }
}