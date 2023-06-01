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
            this.lblError = new System.Windows.Forms.Label();
            this.txbTieuDe = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbNguoiNhan = new System.Windows.Forms.ComboBox();
            this.btnGui = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rtbNoiDung = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(17, 486);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 29);
            this.lblError.TabIndex = 14;
            // 
            // txbTieuDe
            // 
            this.txbTieuDe.Location = new System.Drawing.Point(132, 48);
            this.txbTieuDe.Name = "txbTieuDe";
            this.txbTieuDe.Size = new System.Drawing.Size(836, 22);
            this.txbTieuDe.TabIndex = 13;
            this.txbTieuDe.TextChanged += new System.EventHandler(this.txbTieuDe_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tiêu đề:";
            // 
            // cbNguoiNhan
            // 
            this.cbNguoiNhan.FormattingEnabled = true;
            this.cbNguoiNhan.Location = new System.Drawing.Point(132, 9);
            this.cbNguoiNhan.Name = "cbNguoiNhan";
            this.cbNguoiNhan.Size = new System.Drawing.Size(836, 24);
            this.cbNguoiNhan.TabIndex = 11;
            this.cbNguoiNhan.SelectionChangeCommitted += new System.EventHandler(this.cbNguoiNhan_SelectionChangeCommitted);
            // 
            // btnGui
            // 
            this.btnGui.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnGui.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGui.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGui.Location = new System.Drawing.Point(739, 479);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(229, 43);
            this.btnGui.TabIndex = 10;
            this.btnGui.Text = "Gửi";
            this.btnGui.UseVisualStyleBackColor = false;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Người nhận:";
            // 
            // rtbNoiDung
            // 
            this.rtbNoiDung.Location = new System.Drawing.Point(17, 78);
            this.rtbNoiDung.Name = "rtbNoiDung";
            this.rtbNoiDung.Size = new System.Drawing.Size(951, 395);
            this.rtbNoiDung.TabIndex = 8;
            this.rtbNoiDung.Text = "";
            this.rtbNoiDung.TextChanged += new System.EventHandler(this.rtbNoiDung_TextChanged);
            // 
            // fNewMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 531);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.txbTieuDe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbNguoiNhan);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbNoiDung);
            this.Name = "fNewMail";
            this.Text = "fNewMail";
            this.Load += new System.EventHandler(this.fNewMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txbTieuDe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbNguoiNhan;
        private System.Windows.Forms.Button btnGui;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox rtbNoiDung;
    }
}