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

namespace CitizenManagement_EntityFramework.Forms
{
    public partial class fNewMail : Form
    {
        private Mails mails = new Mails()
        {
            Nguoigui = "CD0001",
            Ngay = DateTime.Now,
        };

        private MailDAO mailDAO = new MailDAO();

        public fNewMail()
        {
            InitializeComponent();
        }

        private void fNewMail_Load(object sender, EventArgs e)
        {
            cbNguoiNhan.DataSource = new CitizenDAO().getListAllCityzen();
            cbNguoiNhan.ValueMember = "MaCD";
            cbNguoiNhan.DisplayMember = "Hoten";
            cbNguoiNhan_SelectionChangeCommitted(sender, e);
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            AutogenerateMailID();
            if (mails != null)
            {
                mailDAO.AddMail(mails);
                lblError.Text = string.Empty;
                this.Close();
            }
            else
                lblError.Text = "Khong duoc de trong cac o tren";
        }

        private void cbNguoiNhan_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Cityzen ctz = cbNguoiNhan.SelectedItem as Cityzen;
            if (ctz != null)
            {
                mails.Nguoinhan = ctz.Macd;
            }
        }

        private void txbTieuDe_TextChanged(object sender, EventArgs e)
        {
            mails.Tieude = txbTieuDe.Text;
        }

        private void rtbNoiDung_TextChanged(object sender, EventArgs e)
        {
            mails.Noidung = rtbNoiDung.Text;
        }
        private void AutogenerateMailID()
        {
            int index = mailDAO.getAllMail().Rows.Count;
            index++;
            mails.Mamail = $"Mail{index:0000}";
        }
    }
}
