using CitizenManagement_EntityFramework.DAO;
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
    public partial class fThongTinCaNhan : Form
    {
        private Cityzen currentCityzen = CurrentUser.Instance.CurrentCitizen;

        public fThongTinCaNhan()
        {
            InitializeComponent();
            cbxDanToc.DataSource = Cityzen.getListDanToc();
            cbxGioiTinh.DataSource = Cityzen.getListGioiTinh();
            cbxHonNhan.DataSource = Cityzen.getListTinhTrangHonNhan();
            cbxTinhTrang.DataSource =  Cityzen.getListTinhTrang();
        }

        private void rdoCongDan_CheckedChanged(object sender, EventArgs e)
        {
            dtgvThongTinCaNhan.Visible = false;
            picAvatar.Visible = true;
            pnThongTinCaNhan.Enabled = false;
            BindData(CurrentUser.Instance.CurrentCitizen);
        }

        private void rdoQuanLy_CheckedChanged(object sender, EventArgs e)
        {
            dtgvThongTinCaNhan.Visible = true;
            picAvatar.Visible = false;
            pnThongTinCaNhan.Enabled = true;
            dtgvThongTinCaNhan.DataSource = new CitizenDAO().getAllCitizen();
        }

        private void fThongTinCaNhan_Load(object sender, EventArgs e)
        {
            LoadAvatar();
            BindData(currentCityzen);
        }

        private void LoadAvatar()
        {
            picAvatar.Image = CertificatesDAO.Instance.GetImage(currentCityzen.Macd);
        }

        private void BindData(Cityzen ctz)
        {
            txtMaCD.Text = ctz.Macd;
            txtHoTen.Text = ctz.Hoten;
            cbxGioiTinh.Text = ctz.Gioitinh;
            txtNgheNghiep.Text = ctz.Nghenghiep;
            cbxDanToc.Text = ctz.Dantoc;
            txtTonGiao.Text = ctz.Tongiao;
            cbxHonNhan.Text = (!ctz.TinhTrangHonNhan) ? "Độc thân" : "Đã Kết hôn";
            cbxTinhTrang.Text = ctz.Tinhtrang;
        }

        private void dtgvThongTinCaNhan_SelectionChanged(object sender, EventArgs e)
        {
            if(dtgvThongTinCaNhan.SelectedRows.Count == 1)
            {
                DataGridViewRow dtr = dtgvThongTinCaNhan.SelectedRows[0];
                Cityzen ctz = new Cityzen
                {
                    Macd = dtr.Cells[0].Value.ToString(),
                    Hoten = dtr.Cells[1].Value.ToString(),
                    Gioitinh = dtr.Cells[2].Value.ToString(),
                    Nghenghiep = dtr.Cells[3].Value.ToString(),
                    Dantoc = dtr.Cells[4].Value.ToString(),
                    Tongiao = dtr.Cells[5].Value.ToString(),
                    Tinhtrang = dtr.Cells[6].Value.ToString(),
                    TinhTrangHonNhan = Convert.ToBoolean(dtr.Cells[7].Value),
                };

                BindData(ctz);
            }
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(!isNullTextBox())
            {
                Cityzen ctz = new Cityzen(txtMaCD.Text, txtHoTen.Text, cbxGioiTinh.Text, txtNgheNghiep.Text, cbxDanToc.Text, txtTonGiao.Text, cbxTinhTrang.Text, (cbxHonNhan.Text == "Độc thân") ? false : true);
                try
                { 
                    CitizenDAO.Instance.Update(ctz);
                    MessageBox.Show("Cap nhat thanh cong!!!");
                }
                catch
                {
                    MessageBox.Show("Cap nhat that bai!!!");
                }
                finally
                {
                    rdoQuanLy_CheckedChanged(sender, e);
                }
            }   
            
        }

        private bool isNullTextBox()
        {
            if (string.IsNullOrEmpty(txtHoTen.Text.Trim()) || string.IsNullOrEmpty(txtNgheNghiep.Text.Trim()) || string.IsNullOrEmpty(txtTonGiao.Text.Trim()) || string.IsNullOrEmpty(cbxGioiTinh.Text.Trim()) || string.IsNullOrEmpty(cbxDanToc.Text.Trim()))
                return true;
            return false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbTheoMaNguoi.Checked)
                    dtgvThongTinCaNhan.DataSource = CitizenDAO.Instance.getCitizenTheoId(txtTimKiem.Text);
                else if (rbTheoDanToc.Checked)
                    dtgvThongTinCaNhan.DataSource = CitizenDAO.Instance.getCitizenTheoDanToc(txtTimKiem.Text);
                else if (rbNgheNghiep.Checked)
                    dtgvThongTinCaNhan.DataSource = CitizenDAO.Instance.getCitizenTheoNgheNghiep(txtTimKiem.Text);
                else if (rbTheoTenNguoi.Checked)
                    dtgvThongTinCaNhan.DataSource = CitizenDAO.Instance.getCitizenTheoTen(txtTimKiem.Text);
                else
                    throw new Exception("Vui lòng chọn phương thức tìm kiếm!!!");
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            dtgvThongTinCaNhan.DataSource = new CitizenDAO().getAllCitizen();
        }
    }
}
