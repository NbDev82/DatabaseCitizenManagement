namespace CitizenManagement_EntityFramework.Forms
{
    partial class fNewMail
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
            this.rtbNoiDung = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGui = new System.Windows.Forms.Button();
            this.cbNguoiNhan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbTieuDe = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbNoiDung
            // 
            this.rtbNoiDung.Location = new System.Drawing.Point(12, 87);
            this.rtbNoiDung.Name = "rtbNoiDung";
            this.rtbNoiDung.Size = new System.Drawing.Size(951, 395);
            this.rtbNoiDung.TabIndex = 1;
            this.rtbNoiDung.Text = "";
            this.rtbNoiDung.TextChanged += new System.EventHandler(this.rtbNoiDung_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Người nhận:";
            // 
            // btnGui
            // 
            this.btnGui.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGui.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGui.Location = new System.Drawing.Point(734, 488);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(229, 43);
            this.btnGui.TabIndex = 3;
            this.btnGui.Text = "Gửi";
            this.btnGui.UseVisualStyleBackColor = false;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // cbNguoiNhan
            // 
            this.cbNguoiNhan.FormattingEnabled = true;
            this.cbNguoiNhan.Location = new System.Drawing.Point(127, 18);
            this.cbNguoiNhan.Name = "cbNguoiNhan";
            this.cbNguoiNhan.Size = new System.Drawing.Size(836, 24);
            this.cbNguoiNhan.TabIndex = 4;
            this.cbNguoiNhan.SelectedIndexChanged += new System.EventHandler(this.cbNguoiNhan_SelectedIndexChanged);
            this.cbNguoiNhan.SelectionChangeCommitted += new System.EventHandler(this.cbNguoiNhan_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tiêu đề:";
            // 
            // txbTieuDe
            // 
            this.txbTieuDe.Location = new System.Drawing.Point(127, 57);
            this.txbTieuDe.Name = "txbTieuDe";
            this.txbTieuDe.Size = new System.Drawing.Size(836, 22);
            this.txbTieuDe.TabIndex = 6;
            this.txbTieuDe.TextChanged += new System.EventHandler(this.txbTieuDe_TextChanged);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(12, 495);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 29);
            this.lblError.TabIndex = 7;
            // 
            // fNewMail
            // 
            this.ClientSize = new System.Drawing.Size(984, 531);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txbTieuDe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbNguoiNhan);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbNoiDung);
            this.Name = "fNewMail";
            this.Load += new System.EventHandler(this.fNewMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox rtbNoiDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.ComboBox cbNguoiNhan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbTieuDe;
        private System.Windows.Forms.Label lblError;
    }
}