using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitizenManagement_EntityFramework
{
    public partial class fNguoiDung : Form
    {
        private Form CurrentFormChild;
        public fNguoiDung()
        {
            InitializeComponent();
        }

        private void fNguoiDung_Load(object sender, EventArgs e)
        {

        }
        public void OpenChildForm(Form FormChild)
        {
            if (CurrentFormChild != null)
                CurrentFormChild.Close();
            CurrentFormChild = FormChild;
            FormChild.TopLevel = false;
            FormChild.FormBorderStyle = FormBorderStyle.None;
            FormChild.Dock = DockStyle.Fill;
            pnBody.Controls.Add(FormChild);
            pnBody.Tag = FormChild;
            FormChild.BringToFront();
            FormChild.Show();
        }
        private void btnHomThu_Click(object sender, EventArgs e)
        {
            lbBody.Text = "          " + btnHomThu.Text.ToUpper();
            pnTitle.BackColor = btnHomThu.BackColor;
            OpenChildForm(new fHomThu());
        }

        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            lbBody.Text = btnThongTinCaNhan.Text.ToUpper();
            pnTitle.BackColor = btnThongTinCaNhan.BackColor;
            OpenChildForm(new fThongTinCaNhan());
        }

        private void btnHoKhau_Click(object sender, EventArgs e)
        {
            lbBody.Text = "          " + btnHoKhau.Text.ToUpper();
            pnTitle.BackColor = btnHoKhau.BackColor;
            OpenChildForm(new fHoKhau());
        }

        private void btnHonNhan_Click(object sender, EventArgs e)
        {
            lbBody.Text = "          " + btnHonNhan.Text.ToUpper();
            pnTitle.BackColor = btnHonNhan.BackColor;
            OpenChildForm(new fHonNhan());
        }

        private void btnKhaiSinhKhaiTu_Click(object sender, EventArgs e)
        {
            lbBody.Text = btnKhaiSinhKhaiTu.Text.ToUpper();
            pnTitle.BackColor = btnKhaiSinhKhaiTu.BackColor;
            OpenChildForm(new fKhaiSinhKhaiTu());
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            lbBody.Text = "          " + btnTaiKhoan.Text.ToUpper();
            pnTitle.BackColor = btnHonNhan.BackColor;
            OpenChildForm(new fTaiKhoan());
        }

        private void btnThue_Click(object sender, EventArgs e)
        {
            lbBody.Text = "          " + btnThue.Text.ToUpper();
            pnTitle.BackColor = btnThue.BackColor;
            OpenChildForm(new fThue());
        }

        private void btnTamTruTamVang_Click(object sender, EventArgs e)
        {
            lbBody.Text = "          " + btnTamTruTamVang.Text.ToUpper();
            pnTitle.BackColor = btnTamTruTamVang.BackColor;
            OpenChildForm(new fTamTruTamVang());
        }

        private void btnCCCD_Click(object sender, EventArgs e)
        {
            lbBody.Text = "          " + btnCCCD.Text.ToUpper();
            pnTitle.BackColor = btnCCCD.BackColor;
            OpenChildForm(new fCCCD());
        }
    }
}
