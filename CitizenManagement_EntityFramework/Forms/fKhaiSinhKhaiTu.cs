using CitizenManagement_EntityFramework.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitizenManagement_EntityFramework
{
    public partial class fKhaiSinhKhaiTu : Form
    {
        BirthDAO birthDAO = new BirthDAO(); 
        CitizenDAO citizenDAO = new CitizenDAO(); 

        CertificatesDAO certificatesDAO = new CertificatesDAO();
        Cityzen Cityzen=new Cityzen();
        Births births = new Births();  


        Users_Deleted  users_Deleted = new Users_Deleted();
        Cityzen Father = new Cityzen();
        Cityzen Mom = new Cityzen();

        public fKhaiSinhKhaiTu()
        {
            InitializeComponent();
            if (rdoKhaiSinh.Checked = true)
            {
                rdoKhaiTu.Checked = false;
                LoadDataGridKhaiSinh();
                List<string> lst = new List<string>();
                DataTable dataTable = birthDAO.GetBirthsTrue();
                foreach (DataRow row in dataTable.Rows)
                {
                    lst.Add(row[0].ToString());
                }
                cbMaCD.DataSource = lst;
            }
            else
            {
                rdoKhaiTu.Checked = true;
                LoadDataGidKhaiTu();
                List<string> list = new List<string>();
                DataTable dataTable = birthDAO.GetUserDeletedTrue();
                foreach (DataRow row in dataTable.Rows)
                {
                    list.Add(row[0].ToString());
                }
                cbMaCD.DataSource = list;
            }
            List<string> strings = new List<string>();
            DataTable dt = citizenDAO.GetCitizen();
            foreach (DataRow row in dt.Rows)
            {
                strings.Add(row[0].ToString());
            }
            cbMaCCCDCha.DataSource = strings;

            List<string> a = new List<string>();
            dt = citizenDAO.GetCitizen();
            foreach (DataRow row in dt.Rows)
            {
                a.Add(row[0].ToString());
            }
            cbMaCCCDMe.DataSource = a;
        }

        private void fKhaiSinhKhaiTu_Load(object sender, EventArgs e)
        {
            rdoKhaiSinh.Checked=true;
         
            List<int> ints = new List<int>();
            for(int  i = DateTime.Now.Year;i>=1950;i--)
            ints.Add(i);    
            cbYear.DataSource = ints;



        }
        public void LoadDataGridKhaiSinh()
        {
            dtgvKhaiSinhKhaiTu.DataSource = birthDAO.GetBirths();
        }
        public void LoadDataGidKhaiTu()
        {
            dtgvKhaiSinhKhaiTu.DataSource = birthDAO.GetUserDeleted();
        }

        private void rdoKhaiTu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoKhaiTu.Checked)
            {
                pnShowKhaiSinh.Visible = false;
                pnShowKhaiTu.Visible = true;
            }
            //rdoKhaiTu.Checked = true;
            LoadDataGidKhaiTu();
        }

        private void rdoKhaiSinh_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoKhaiSinh.Checked)
            {
                pnShowKhaiSinh.Visible = true;
                pnShowKhaiTu.Visible = false;
            }
            //rdoKhaiTu.Checked = false;
            LoadDataGridKhaiSinh();
        }

        private void dtgvKhaiSinhKhaiTu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dtgvKhaiSinhKhaiTu.CurrentRow.Index;
            if(rdoKhaiSinh.Checked==true)
            {
                births = birthDAO.BirthByID(dtgvKhaiSinhKhaiTu.Rows[i].Cells[0].Value.ToString());

                Father = citizenDAO.GetCitizenByMaCD(births.MaCD_Cha);
                Mom = citizenDAO.GetCitizenByMaCD(births.MaCD_Me);

                Cityzen = citizenDAO.GetCitizenByMaCD(births.MaCD);

                
                cbMaCCCDCha.Text = births.MaCD_Cha;
                cbMaCCCDMe.Text = births.MaCD_Me;

                txtHoTenCha.Text = Father.Hoten;
                txtHoTenMe.Text = Mom.Hoten;

                cbMaCD.Text = births.MaCD;
                txtHoTen.Text = Cityzen.Hoten;
                dtpkNgaySinh.Value = births.NgaySinh;
                txtNoiSinh.Text = births.NoiSinh;
                cbxGioiTinh.Text = Cityzen.Gioitinh;
                txtDanToc.Text = Cityzen.Dantoc;
                dtpkNgayDuyet.Value=births.NgayDuyet;

            }
            if(rdoKhaiTu.Checked == true)
            {
                users_Deleted = birthDAO.Users_DeletedByID(dtgvKhaiSinhKhaiTu.Rows[i].Cells[0].Value.ToString());

                births = birthDAO.BirthByID(dtgvKhaiSinhKhaiTu.Rows[i].Cells[0].Value.ToString());

                Cityzen = citizenDAO.GetCitizenByMaCD(users_Deleted.Macd);

                txtHoTen.Text = Cityzen.Macd;
                cbMaCD.Text=users_Deleted.Macd;
                dtpkNgaySinh.Value=births.NgaySinh;
                txtNoiSinh.Text=births.NoiSinh;
                cbxGioiTinh.Text = Cityzen.Gioitinh;
                txtDanToc.Text = Cityzen.Dantoc;
                
                Cityzen.Tinhtrang = "Đã chết" ;
                
                txtLyDo.Text = users_Deleted.Nguyennhan;
            }

        }

        private void pnTimKiem_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rdoKhaiSinh.Checked==true) 
            {
                dtgvKhaiSinhKhaiTu.DataSource = birthDAO.getDataBirthInYear(int.Parse(cbYear.Text));
            }
            else
            if(rdoKhaiTu.Checked==true)
            {
                dtgvKhaiSinhKhaiTu.DataSource = birthDAO.getUserDeletedInYear(int.Parse(cbYear.Text));
            }
        }
        private void btnKhai_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void btnDuyetNgaySinh_Click(object sender, EventArgs e)
        {
                if (rdoKhaiSinh.Checked == true && rdoKhaiTu.Checked == false)
                {
                    births.NgayDuyet = dtpkNgayDuyet.Value;
                    birthDAO.DuyetNgaySinh(births.MaCD, dtpkNgayDuyet.Value);
                    LoadDataGridKhaiSinh();
                }
                if (rdoKhaiSinh.Checked == false && rdoKhaiTu.Checked==true)
            {
                users_Deleted.NgayDuyet = dtpkNgayDuyet.Value;
                birthDAO.DuyetNgayChet(users_Deleted.Macd, dtpkNgayDuyet.Value);
                LoadDataGidKhaiTu();
            }
                
        }

        private void btnChuaDuyet_Click(object sender, EventArgs e)
        {
            if(rdoKhaiSinh.Checked == true && rdoKhaiTu.Checked == false)
            {
                dtgvKhaiSinhKhaiTu.DataSource = birthDAO.DataGridBirthChuaDuyet();
            }
            if(rdoKhaiTu.Checked==true && rdoKhaiSinh.Checked==false)
            {
                dtgvKhaiSinhKhaiTu.DataSource = birthDAO.DataGridUserDeletedChuaDuyet();
            }
        }

        private void btnDien_Click(object sender, EventArgs e)
        {
            if(rdoKhaiSinh.Checked==true)
            {
                Cityzen = citizenDAO.GetCitizenByMaCD(cbMaCD.Text);
              
                births.MaCD = Cityzen.Macd;

                births.NgaySinh = dtpkNgaySinh.Value;
                births.NoiSinh = txtNoiSinh.Text;

                txtHoTen.Text = Cityzen.Hoten;
                txtDanToc.Text = Cityzen.Dantoc;
                cbxGioiTinh.Text = Cityzen.Gioitinh;

                births.MaCD_Cha = cbMaCCCDCha.Text;
                births.MaCD_Me = cbMaCCCDMe.Text;

                Father = citizenDAO.GetCitizenByMaCD(births.MaCD_Cha);
                Mom = citizenDAO.GetCitizenByMaCD(births.MaCD_Me);

                txtHoTenCha.Text = Father.Hoten;
                txtHoTenMe.Text = Mom.Hoten;
                births.NgaySinh = dtpkNgaySinh.Value;
                births.NgayKhai = DateTime.Now;
                births.NoiSinh = txtNoiSinh.Text;
            }
         
            

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(rdoKhaiSinh.Checked==true)
            {
                birthDAO.ThemBirth(births);
                LoadDataGridKhaiSinh();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(rdoKhaiSinh.Checked == true)
            {
                birthDAO.XoaBirth(births);
                LoadDataGridKhaiSinh();
            }

        }
    }
}
