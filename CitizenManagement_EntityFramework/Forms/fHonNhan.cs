using CitizenManagement_EntityFramework.DAO;
using CitizenManagement_EntityFramework.DTO;
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
    public partial class fHonNhan : Form
    {
        PeopleMarriageDAO peopleMarriageDAO=new PeopleMarriageDAO();
        CitizenDAO citizenDAO = new CitizenDAO();
        BirthDAO birthDAO = new BirthDAO(); 
        Cityzen Husband=new Cityzen();
        Cityzen Wife=new Cityzen();
        People_Marriage Family=new People_Marriage();
        public fHonNhan()
        {
            InitializeComponent();
           
        }

        private void fHonNhan_Load(object sender, EventArgs e)
        {
            
            LoadDataGrid();


            cbMaCDNam.DataSource = citizenDAO.IDMaleNotFamily();
            cbMaCDNu.DataSource = citizenDAO.IDFeMaleNotFamily();

            dtpkNgayDangKy.Value=DateTime.Now;

            tbGioiTinhNam.Text = "Nam";
            tbGioiTinhNu.Text = "Nữ";
            tbQuanHeNam.Text = "Chồng";
            tbQuanHeNu.Text = "Nữ";

            dtpkNgayDangKy.Value = DateTime.Now;


            cbNumMonth.DataSource=new List<int>() {0,1,2,3,4,5,6,7,8,9,10,11,12,24,48,60,120};

            AutoCode();
        }
        public void LoadDataGrid()
        {
            dtgvHonNhan.DataSource = peopleMarriageDAO.DataGrid();
        }
        public void AutoCode()
        {
            string temp = "";
            int num=peopleMarriageDAO.NumberFaminly();
            if (num < 9)
                temp = "HN000" + (num + 1).ToString();
            else if (num >= 10 && num < 99)
                temp = "HN00" + (num + 1).ToString();
            else if(num >=100 && num < 999)
                temp="HN0" + (num+1).ToString();
            else if (num>=1000 && num < 9999)
                temp="HN"+(num+1).ToString();
            else temp="HN" +(num+1).ToString();
            tbCode.Text = temp;
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            // Instal husband and wife
            Husband = citizenDAO.GetCitizenByMaCD(cbMaCDNam.Text);
            Wife = citizenDAO.GetCitizenByMaCD(cbMaCDNu.Text);

            tbHoTenNam.Text = Husband.Hoten;
            tbHoTenNu.Text = Wife.Hoten;
            
            dtpkNgaySinhNam.Value = birthDAO.BirthByID(Husband.Macd).NgaySinh;
            dtpkNgaySinhNu.Value = birthDAO.BirthByID(Wife.Macd).NgaySinh;

            tbNoiSinhNam.Text= birthDAO.BirthByID(Husband.Macd).NoiSinh;
            tbNoiSinhNu.Text = birthDAO.BirthByID(Wife.Macd).NoiSinh;

            tbNgheNghiepNam.Text = Husband.Nghenghiep;
            tbNgheNghiepNu.Text = Wife.Nghenghiep;

            tbDanTocNam.Text=Husband.Dantoc;
            tbDanTocNu.Text = Wife.Dantoc;

            tbTonGiaoNam.Text = Husband.Tongiao;
            tbTonGiaoNu.Text = Wife.Tongiao;

            tbXacNhanNam.Text = "";
            tbXacNhanNu.Text = "";

            tbTrangThai.Text = "Chưa duyệt";
            Family = new People_Marriage(tbCode.Text, cbMaCDNam.Text, cbMaCDNu.Text, cbLoai.Text, dtpkNgayDangKy.Value, tbXacNhanNam.Text, tbXacNhanNu.Text, tbTrangThai.Text);
            //btnXacNhan.Enabled=false;
        }
        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            tbXacNhanNam.Text = Husband.Macd;
            tbXacNhanNu.Text = Wife.Macd;
            Family.Xacnhanlan1=Husband.Macd;
            Family.Xacnhanlan2=Wife.Macd;
            peopleMarriageDAO.UpdateMarriage(Family);
            LoadDataGrid();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            peopleMarriageDAO.AddAFamily(Family);
            LoadDataGrid();
        }

        private void dtgvHonNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dtgvHonNhan.CurrentRow.Index;
            Family = peopleMarriageDAO.GetPeople_Marriage(dtgvHonNhan.Rows[i].Cells[0].Value.ToString());
            Husband = citizenDAO.GetCitizenByMaCD(dtgvHonNhan.Rows[i].Cells[1].Value.ToString());
            Wife = citizenDAO.GetCitizenByMaCD(dtgvHonNhan.Rows[i].Cells[2].Value.ToString());


            cbMaCDNam.Text = Husband.Macd; 
            cbMaCDNu.Text = Wife.Macd;

            tbHoTenNam.Text = Husband.Hoten;
            tbHoTenNu.Text = Wife.Hoten;

            dtpkNgaySinhNam.Value = birthDAO.BirthByID(Husband.Macd).NgaySinh;
            dtpkNgaySinhNu.Value = birthDAO.BirthByID(Wife.Macd).NgaySinh;

            tbNoiSinhNam.Text = birthDAO.BirthByID(Husband.Macd).NoiSinh;
            tbNoiSinhNu.Text = birthDAO.BirthByID(Wife.Macd).NoiSinh;

            tbNgheNghiepNam.Text = Husband.Nghenghiep;
            tbNgheNghiepNu.Text = Wife.Nghenghiep;

            tbDanTocNam.Text = Husband.Dantoc;
            tbDanTocNu.Text = Wife.Dantoc;

            tbTonGiaoNam.Text = Husband.Tongiao;
            tbTonGiaoNu.Text = Wife.Tongiao;

            tbXacNhanNam.Text = Family.Xacnhanlan1;
            tbXacNhanNu.Text = Family.Xacnhanlan2;

            tbTrangThai.Text = Family.Trangthai;
            cbLoai.Text = Family.Loai;
            tbCode.Text = Family.Mahn;
            dtpkNgayDangKy.Value = Family.Ngaydangky;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            peopleMarriageDAO.DivorceMarriage(Family);
            LoadDataGrid();
        }

        private void btnXacDuyet_Click(object sender, EventArgs e)
        {
            tbTrangThai.Text = "Duyệt";
            Family.Trangthai = "Duyệt";
            peopleMarriageDAO.BROWSEMarriage(Family);
            LoadDataGrid();
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            Husband = new Cityzen();
            Wife=new Cityzen();
            Family = new People_Marriage();

            cbMaCDNam.Text = "";
            cbMaCDNu.Text = "";
            tbHoTenNam.Text = "";
            tbHoTenNu.Text = "";

            dtpkNgaySinhNam.Value = DateTime.Now;
            dtpkNgaySinhNu.Value = DateTime.Now;

            tbNoiSinhNam.Text = "";
            tbNoiSinhNu.Text = "";

            tbNgheNghiepNam.Text = "";
            tbNgheNghiepNu.Text = "";

            tbDanTocNam.Text = "";
            tbDanTocNu.Text = "";

            tbTonGiaoNam.Text = "";
            tbTonGiaoNu.Text = "";

            tbXacNhanNam.Text = "";
            tbXacNhanNu.Text = "";
            tbTrangThai.Text = "Chưa duyệt";
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            dtgvHonNhan.DataSource = peopleMarriageDAO.DataFamilyInTime(int.Parse(cbNumMonth.Text));
        }

        private void btnDSchuaXacNhan_Click(object sender, EventArgs e)
        {
            dtgvHonNhan.DataSource = peopleMarriageDAO.DataFamilyNotConfirm();
        }

        private void btnChuaDuyet_Click(object sender, EventArgs e)
        {
            dtgvHonNhan.DataSource = peopleMarriageDAO.DataFamilyNotBrowse();
        }
    }
}
