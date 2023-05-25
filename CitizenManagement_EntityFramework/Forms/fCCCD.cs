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
        private DataTable currentDataUser;

        public fCCCD()
        {
            InitializeComponent();
        }
        public void LoadData(DataTable user)
        {
            dtgvDanhSachCCCD.DataSource = user;
        }
        private void fCCCD_Load(object sender, EventArgs e)
        {
            
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                int MaCD = (int)currentDataUser.Rows[0]["MaCD"];
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
            currentDataUser = CertificatesDAO.Instance.GetDataTable();
            LoadData(currentDataUser);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dtgvDanhSachCCCD.DataSource = CertificatesDAO.Instance.GetCertificateByID("");
        }
    }
}
