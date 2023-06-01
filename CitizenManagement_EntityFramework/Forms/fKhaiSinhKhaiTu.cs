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
        }

        private void fKhaiSinhKhaiTu_Load(object sender, EventArgs e)
        {
            if (rdoKhaiSinh.Checked = false)
            {
                rdoKhaiTu.Checked = true;
                LoadDataGridKhaiSinh();
            }
            else
            {
                rdoKhaiTu.Checked = false;
                LoadDataGidKhaiTu();
            }
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
            //rdoKhaiTu.Checked = true;
            LoadDataGidKhaiTu();
        }

        private void rdoKhaiSinh_CheckedChanged(object sender, EventArgs e)
        {
            //rdoKhaiTu.Checked = false;
            LoadDataGridKhaiSinh();
        }

        private void dtgvKhaiSinhKhaiTu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dtgvKhaiSinhKhaiTu.CurrentRow.Index;
            if(rdoKhaiSinh.Checked==true)
            {
                births.MaCD = dtgvKhaiSinhKhaiTu.Rows[i].Cells[0].Value.ToString();
                births.NgaySinh = DateTime.Parse(dtgvKhaiSinhKhaiTu.Rows[i].Cells[1].Value.ToString());
                births.NoiSinh = dtgvKhaiSinhKhaiTu.Rows[i].Cells[2].Value.ToString();
                births.MaCD_Cha = dtgvKhaiSinhKhaiTu.Rows[i].Cells[3].Value.ToString();
                births.MaCD_Me = dtgvKhaiSinhKhaiTu.Rows[i].Cells[4].Value.ToString();
                births.NgayKhai = DateTime.Parse(dtgvKhaiSinhKhaiTu.Rows[i].Cells[5].Value.ToString());
                if (dtgvKhaiSinhKhaiTu.Rows[i].Cells[6].Value is DBNull) births.NgayDuyet = new DateTime();
                else births.NgayDuyet = DateTime.Parse(dtgvKhaiSinhKhaiTu.Rows[i].Cells[6].Value.ToString());
            }

            Father = citizenDAO.GetCitizenByMaCD(births.MaCD_Cha);
            Mom = citizenDAO.GetCitizenByMaCD(births.MaCD_Me);

            Cityzen = citizenDAO.GetCitizenByMaCD(births.MaCD);

            DataTable dt = certificatesDAO.GetCertificateByID(births.MaCD_Cha);
            txtMaCCCDCha.Text = (string)dt.Rows[0]["MaCCCD"];
            dt = certificatesDAO.GetCertificateByID(births.MaCD_Me);
            txtMaCCCDMe.Text = (string)dt.Rows[0]["MaCCCD"];

            txtHoTenCha.Text = Father.Hoten;
            txtHoTenMe.Text=Mom.Hoten;

            txtMaCD.Text = births.MaCD;
            txtHoTen.Text = Cityzen.Hoten;
            dtpkNgaySinh.Value = births.NgaySinh;
            cbxNoiSinh.Text = births.NoiSinh;
            cbxGioiTinh.Text = Cityzen.Gioitinh;
            cbxDanToc.Text = Cityzen.Dantoc;
        }

        private void pnTimKiem_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (rdoKhaiSinh.Checked==false && rdoKhaiTu.Checked==true) 
            {
                dtgvKhaiSinhKhaiTu.DataSource = birthDAO.getDataBirthInYear(int.Parse(cbYear.Text));
            }
            else
            if(rdoKhaiSinh.Checked==true && rdoKhaiTu.Checked==false)
            {
                dtgvKhaiSinhKhaiTu.DataSource = birthDAO.getUserDeletedInYear(int.Parse(cbYear.Text));
            }
        }
        
    }
}
