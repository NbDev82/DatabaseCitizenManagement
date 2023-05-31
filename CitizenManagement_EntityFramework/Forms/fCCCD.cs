using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitizenManagement_EntityFramework
{
    public partial class fCCCD : Form
    {
        private Accounts tk;
        private DataRow currentDataUser;

        public fCCCD()
        {
            InitializeComponent();
        }
        public void LoadListCertificate(DataTable user)
        {
            dtgvDanhSachCCCD.DataSource = user;
        }
        public bool LoadDataCurrentUser(DataRow currentDataUser)
        {
            try
            {
                txtSoCCCD.Text = currentDataUser["MaCCCD"].ToString();
                txtHoVaTen.Text = currentDataUser["HoTen"].ToString();
                txtDacDiemNhanDang.Text = currentDataUser["DacDiemNhanDang"].ToString();
                txtNoiThuongTru.Text = currentDataUser["NoiThuongTru"].ToString();
                txtQueQuan.Text = currentDataUser["QueQuan"].ToString();
                txtQuocTich.Text = currentDataUser["QuocTich"].ToString();
                dtpkNgaySinh.Text = currentDataUser["NgaySinh"].ToString();
                dtpkThoiHan.Text = currentDataUser["HanSuDung"].ToString();
                txtGioiTinh.Text = currentDataUser["GioiTinh"].ToString();
                if (currentDataUser["Avatar"] != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])currentDataUser["Avatar"];
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        picFace.Image = Image.FromStream(ms);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void fCCCD_Load(object sender, EventArgs e)
        {
            try
            {
                currentDataUser = CertificatesDAO.Instance.GetCurrentDataUser(CurrentUser.Instance.CurrentCitizen.Macd);

                if (!LoadDataCurrentUser(currentDataUser))
                    throw new Exception();
                pnThongTin.Enabled = false;
                pnThongTin_3.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Tải thông tin CCCD thất bại");
                pnCaNhan.Enabled = true;
                pnThongTin.Enabled = true;
                pnThongTin_3.Enabled = true;
            }
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                string MaCD = CurrentUser.Instance.CurrentCitizen.Macd;
                string HoVaTen = txtHoVaTen.Text;
                string NgaySinh = dtpkNgaySinh.Value.ToString();
                string GioiTinh = txtGioiTinh.Text;
                string QuocTich = txtQuocTich.Text;
                string QueQuan = txtQueQuan.Text;
                string NoiThuongTru = txtNoiThuongTru.Text;
                string DacDiemNhanDang = txtDacDiemNhanDang.Text;
                Image Avatar = picFace.Image;
                byte[] image = ConvertImageToByteArray(Avatar);
                Certificate cccd = new Certificate(MaCD, HoVaTen, NgaySinh, GioiTinh, QuocTich, QueQuan, NoiThuongTru, DacDiemNhanDang, Avatar);
                if (CertificatesDAO.Instance.Add(cccd, image))
                    MessageBox.Show("Đăng ký thành công");
                else
                    MessageBox.Show("Đăng ký thất bại");
            }
            catch
            {
                MessageBox.Show("Đăng ký thất bại");
            }
        }
        public byte[] ConvertImageToByteArray(Image img)
        {
            byte[] arr;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, ImageFormat.Jpeg);
                arr = ms.ToArray();
            }
            return arr;
        }
        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            WireEvents(this);
        }
        public void WireEvents(Control Controls)
        {
            foreach (Control control in Controls.Controls)
            {
                if (control is FlowLayoutPanel flowPanel)
                {
                    WireEvents(flowPanel);
                }
                if (control is Panel Panel)
                {
                    WireEvents(Panel);
                }
                if (control is TextBox textBox)
                {
                    textBox.Text = null;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.Text = null;
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Now;
                }
                else if (control is PictureBox pictureBox)
                {
                    pictureBox.Image = pictureBox.InitialImage;
                }
            }
        }

        private void btnTaiHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.Title = "Select an Image File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picFace.Load(openFileDialog1.FileName);
            }
        }

        private void brnXem_Click(object sender, EventArgs e)
        {
            DataTable ListDataUser = CertificatesDAO.Instance.GetDataTable();
            LoadListCertificate(ListDataUser);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string MaCD = txtTimKiem.Text;
            dtgvDanhSachCCCD.DataSource = CertificatesDAO.Instance.GetCertificateByID(MaCD);
        }

        private void btnCitizenWithoutCertificate_Click(object sender, EventArgs e)
        {
            dtgvDanhSachCCCD.DataSource = CertificatesDAO.Instance.CitizenWithoutCertificate();
        }
        private void btnShowCDProvince_Click(object sender, EventArgs e)
        {
            string province = txtTimKiem.Text;
            dtgvDanhSachCCCD.DataSource = CertificatesDAO.Instance.CitizenBelongProvince(province);
        }

        private void btnCCCDExpired_Click(object sender, EventArgs e)
        {
            dtgvDanhSachCCCD.DataSource = CertificatesDAO.Instance.GetCertificateExpired();
        }

        private void btnCCCDNearlyExpired_Click(object sender, EventArgs e)
        {
            dtgvDanhSachCCCD.DataSource = CertificatesDAO.Instance.GetCertificateNearlyExpired();
        }
    }
}
