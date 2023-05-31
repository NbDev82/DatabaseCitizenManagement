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
    public partial class fHoKhau : Form
    {

        public fHoKhau()
        {
            InitializeComponent();
        }

        private void fHoKhau_Load(object sender, EventArgs e)
        {
            HoKhauLoad();
            pnThongTin.Enabled = false;
            pnChinhSuaThongTinThanhVien.Enabled = false;
        }
        public void HoKhauLoad()
        {
            string macd = CurrentUser.Instance.CurrentCitizen.Macd;
            string MaHo = HouseholdDAO.Instance.LayMaHo(macd);
            List<Control> ltext = new List<Control>();
            ltext.Add(txtMaHo);
            ltext.Add(txtChuHo);
            ltext.Add(txtTinhThanh);
            ltext.Add(txtQuanHuyen);
            ltext.Add(txtPhuongXa);
            HouseholdDAO.Instance.Fill(MaHo, ltext);
            pnChucNang.Enabled = false;
            pnThongTinHoKhau.Enabled = false;
        }
        private void LoadList(string ID)
        {
            string sqlstr = string.Format("SELECT * FROM view_HouseholdMembersInfo WHERE MaHo = '{0}'", ID);
            dtgvChiTietHoKhau.DataSource = DBConnection.Instance.GetDataTable(sqlstr);
        }

        private void dtgvChiTietHoKhau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = this.dtgvChiTietHoKhau.CurrentCell.RowIndex;
            txtMaCD.DataBindings.Clear();
            txtMaCD.Text = dtgvChiTietHoKhau.Rows[r].Cells[1].Value.ToString();
            txtHoTen.DataBindings.Clear();
            txtHoTen.Text = dtgvChiTietHoKhau.Rows[r].Cells[2].Value.ToString();
            txtNgaySinh.DataBindings.Clear();
            txtNgaySinh.Text = dtgvChiTietHoKhau.Rows[r].Cells[3].Value.ToString();
            txtNoiSinh.DataBindings.Clear();
            txtNoiSinh.Text = dtgvChiTietHoKhau.Rows[r].Cells[4].Value.ToString();
            txtGioiTinh.DataBindings.Clear();
            txtGioiTinh.Text = dtgvChiTietHoKhau.Rows[r].Cells[5].Value.ToString();
            txtNgheNghiep.DataBindings.Clear();
            txtNgheNghiep.Text = dtgvChiTietHoKhau.Rows[r].Cells[6].Value.ToString();
            txtDanToc.DataBindings.Clear();
            txtDanToc.Text = dtgvChiTietHoKhau.Rows[r].Cells[7].Value.ToString();
            txtTonGiao.DataBindings.Clear();
            txtTonGiao.Text = dtgvChiTietHoKhau.Rows[r].Cells[8].Value.ToString();
            txtHonNhan.DataBindings.Clear();
            txtHonNhan.Text = dtgvChiTietHoKhau.Rows[r].Cells[9].Value.ToString();
            txtTinhTrang.DataBindings.Clear();
            txtTinhTrang.Text = dtgvChiTietHoKhau.Rows[r].Cells[10].Value.ToString();
            txtQuanHe.DataBindings.Clear();
            txtQuanHe.Text = dtgvChiTietHoKhau.Rows[r].Cells[11].Value.ToString();
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            fCCCD d = new fCCCD();
            d.ShowDialog();
        }
        public void BatChinhSua()
        {
            btnChinhSua.BackColor = Color.Green;
            pnCapNhatHoKhau.Enabled = true;
        }
        public void TatChinhSua()
        {
            btnChinhSua.BackColor = Color.Red;
            pnCapNhatHoKhau.Enabled = false;
        }

        private void btnChinhSua_Click_1(object sender, EventArgs e)
        {
            pnThongTin.Enabled = !pnThongTin.Enabled;
            if (pnThongTin.Enabled)
            {
                BatChinhSua();
            }
            else
            {
                TatChinhSua();
            }
        }
        public void LoadCongDan()
        {
            try
            {
                int index = dtgvChiTietHoKhau.CurrentRow.Index;
                DataTable CurrentRow = (DataTable)dtgvChiTietHoKhau.DataSource;
                if (CurrentRow != null)
                {
                    int maCd = (int)CurrentRow.Rows[index]["MaCD"];
                    DataTable dt = HouseholdDAO.Instance.LayThongTinThanhVien(maCd);
                    DataRow dtCD = dt.Rows[0];
                    if (dtCD == null)
                        throw new Exception();
                    Fill(dtCD);
                }
                else
                    throw new Exception();
            }
            catch
            {
                MessageBox.Show("Bị lỗi");
            }
        }

        private void btnLoadLaiCongDan_Click(object sender, EventArgs e)
        {
            LoadCongDan();
        }
        private void Fill(DataRow dtCD)
        {
            txtMaCD.Text = dtCD["MaCD"].ToString();
            txtHoTen.Text = dtCD["HoTen"].ToString();
            txtNgaySinh.Text = dtCD["NgaySinh"].ToString();
            txtNoiSinh.Text = dtCD["NoiSinh"].ToString();
            txtGioiTinh.Text = dtCD["GioiTinh"].ToString();
            txtNgheNghiep.Text = dtCD["NgheNghiep"].ToString();
            txtDanToc.Text = dtCD["DanToc"].ToString();
            txtTonGiao.Text = dtCD["TonGiao"].ToString();
            txtHonNhan.Text = dtCD["MaHN"].ToString();
            txtTinhTrang.Text = dtCD["TinhTrang"].ToString();
            txtQuanHe.Text = dtCD["QuanHeVoiChuHo"].ToString();
        }

        private void btnDien_Click(object sender, EventArgs e)
        {
            try
            {
                string Macd = txtMaCD.Text;
                Cityzen cdChild = CitizenDAO.Instance.GetCitizenByMaCD(Macd);
                Births khaiSinh = BirthDAO.Instance.GetKhaiSinhByID(Macd);
                txtHoTen.Text = cdChild.Hoten;
                txtNgaySinh.Text = khaiSinh.NgaySinh.ToString();
                txtNoiSinh.Text = khaiSinh.NoiSinh;
                txtGioiTinh.Text = cdChild.Gioitinh;
                txtNgheNghiep.Text = cdChild.Nghenghiep;
                txtDanToc.Text = cdChild.Dantoc;
                txtTonGiao.Text = cdChild.Tongiao;
                txtHonNhan.Text = cdChild.TinhTrangHonNhan? "Đã kết hôn" : "Chưa kết hôn";
                txtTinhTrang.Text = cdChild.Tinhtrang;
            }
            catch
            {
                MessageBox.Show("Mã công dân bị sai");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaCD = txtMaCD.Text;
                string MaHo = txtMaHo.Text;
                if (txtQuanHe.Text == "")
                {
                    MessageBox.Show("Quan hệ không được để trống");
                    return;
                }
                if (!HouseholdDAO.Instance.AddToChiTietHoKhau(MaCD, MaHo, txtQuanHe.Text))
                    throw new Exception();
                MessageBox.Show("Thêm thành công");
            }
            catch (Exception)
            {
                MessageBox.Show("Công dân đã có hộ khẩu hoặc sai mã công dân");
            }
            LoadList(txtMaHo.Text);
        }
        public void LayDanhSachChiTietHoKhau()
        {
            string macd = txtChuHo.Text;
            string MaHo = HouseholdDAO.Instance.LayMaHo(macd);
            DataTable dt = HouseholdDAO.Instance.LayDanhSach(MaHo, "Detail_Households");
            dtgvChiTietHoKhau.DataSource = dt;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string macd = txtMaCD.Text;
                if (IsExist(macd) && HouseholdDAO.Instance.Delete(macd))
                {
                    MessageBox.Show("Xóa thành công");
                    LoadList(txtMaHo.Text);
                }
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại" + ex);
            }
        }
        public bool IsExist(string macd)
        {
            try
            {
                foreach (DataGridViewRow row in dtgvChiTietHoKhau.Rows)
                {
                    string Ma = (string)row.Cells["MaCD"].Value;
                    string quanHe = row.Cells["QuanHeVoiChuHo"].Value.ToString();
                    if (Ma == macd && quanHe != "Chủ hộ")
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnThongTinHoKhau.Enabled)
                    throw new Exception();
                pnChiTietHoKhau.Enabled = true;
                LoadList(txtMaHo.Text);

            }
            catch
            {
                MessageBox.Show("Hiện đang trong chế độ đăng ký hộ khẩu");
            }
        }

        private void btnTaoHoKhau_Click(object sender, EventArgs e)
        {
            pnThongTinHoKhau.Enabled = true;
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            try
            {
                if (!pnThongTinHoKhau.Enabled)
                {
                    MessageBox.Show("Không trong chế độ đăng ký hộ khẩu");
                    return;
                }
                string MaCD = "CD0002";
                string maHo = HouseholdDAO.Instance.LayMaHo(MaCD);
                if (maHo != null)
                {
                    MessageBox.Show("Công dân đã có hộ khẩu");
                    return;
                }
                Cityzen chuHo = CitizenDAO.Instance.GetCitizenByMaCD(MaCD);
                string TinhThanh = txtTinhThanh.Text;
                string PhuongXa = txtPhuongXa.Text;
                string QuanHuyen = txtQuanHuyen.Text;
                Households hoKhauMoi = new Households("HO00010", MaCD, TinhThanh, QuanHuyen, PhuongXa, "Chưa duyệt", DateTime.Now);
                if (HouseholdDAO.Instance.AddToHoKhau(hoKhauMoi))
                    MessageBox.Show("Tạo hộ khẩu thành công");
                else
                    MessageBox.Show("Tạo hộ khẩu thất bại");
            }
            catch
            {
                MessageBox.Show("Không được để trống");
            }
        }

        private void btnLoadLaiHoKhau_Click(object sender, EventArgs e)
        {
            HoKhauLoad();
            pnThongTinHoKhau.Enabled = false;
            rdoCongDan.Checked = true;
        }

        private void rdoQuanLy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoQuanLy.Checked)
            {
                pnChinhSuaThongTinThanhVien.Enabled = true;
                pnChucNang.Enabled = true;
            }
            else
                pnChinhSuaThongTinThanhVien.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaHo = txtTimKiem.Text;
                DataTable dt = HouseholdDAO.Instance.GetHoKhauByID(MaHo);
                if (dt != null)
                    dtgvDanhSachHoKhau.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("Không được để trống");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = HouseholdDAO.Instance.GetHoKhau();
                dtgvDanhSachHoKhau.DataSource = dt;
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void dtgvDanhSachHoKhau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaCD.Clear();
            txtHoTen.Clear();
            txtNgaySinh.Clear();
            txtNoiSinh.Clear();
            txtGioiTinh.Clear();
            txtNgheNghiep.Clear();
            txtDanToc.Clear();
            txtTonGiao.Clear();
            txtHonNhan.Clear();
            txtTinhTrang.Clear();
            txtQuanHe.Clear();
            int r = this.dtgvDanhSachHoKhau.CurrentCell.RowIndex;
            txtMaHo.DataBindings.Clear();
            txtMaHo.Text = dtgvDanhSachHoKhau.Rows[r].Cells[0].Value.ToString();
            txtChuHo.DataBindings.Clear();
            txtChuHo.Text = dtgvDanhSachHoKhau.Rows[r].Cells[1].Value.ToString();
            txtTinhThanh.DataBindings.Clear();
            txtTinhThanh.Text = dtgvDanhSachHoKhau.Rows[r].Cells[2].Value.ToString();
            txtQuanHuyen.DataBindings.Clear();
            txtQuanHuyen.Text = dtgvDanhSachHoKhau.Rows[r].Cells[3].Value.ToString();
            txtPhuongXa.DataBindings.Clear();
            txtPhuongXa.Text = dtgvDanhSachHoKhau.Rows[r].Cells[4].Value.ToString();
            LoadList(txtMaHo.Text);
        }
    }
}
