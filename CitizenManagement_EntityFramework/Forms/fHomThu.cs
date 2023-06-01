using CitizenManagement_EntityFramework.DAO;
using CitizenManagement_EntityFramework.Forms;
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
    public partial class fHomThu : Form
    {
        private MailDAO mailDAO = new MailDAO();
        private string function;
        private string searchingNamePerson;
        private string searchingIDPerson;

        public fHomThu()
        {
            InitializeComponent();
        }

        private void btXem_Click(object sender, EventArgs e)
        {
            if (rbThuGui.Checked)
                rbThuGui_CheckedChanged(sender, e);
            else if (rbThuNhan.Checked)
                rbThuNhan_CheckedChanged(sender, e);
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbTheoNgay.Checked)
                    dtgvHomThu.DataSource = mailDAO.getMailsByDayOfCitizen(tbTimKiem.Text, function);
                else if (rbTheoMaNguoi.Checked)
                    dtgvHomThu.DataSource = mailDAO.getMailsByIDOfCitizen(tbTimKiem.Text, function, searchingIDPerson);
                else if (rbTheoTenNguoi.Checked)
                    dtgvHomThu.DataSource = mailDAO.getMailsByNameOfCitizen(tbTimKiem.Text, function, searchingNamePerson);
                else
                    throw new Exception("Vui long chon phuong thuc tim kiem");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                fHomThu_Load(sender, e);
            }
        }

        private void fHomThu_Load(object sender, EventArgs e)
        {
            dtgvHomThu.DataSource = mailDAO.getInboxMailsOfCitizen(CurrentUser.Instance.CurrentCitizen);
            function = "fn_MailNhanTheoMaCongDan";
            searchingNamePerson = "TenNguoiGui";
            searchingIDPerson = "MaNguoiGui";
            rbTheoTenNguoi.Text = "Theo tên người gửi";
            rbTheoMaNguoi.Text = "Theo mã người gửi";
        }

        private void dtgvHomThu_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgvHomThu.SelectedRows.Count == 1)
                Binding_TextBox_Of_Mail(dtgvHomThu.SelectedRows[0]);
        }

        private void Binding_TextBox_Of_Mail(DataGridViewRow rows)
        {
            tbMaMail.Text = rows.Cells[0].Value.ToString();
            tbTieuDe.Text = rows.Cells[1].Value.ToString();
            dtpkNgay.Text = rows.Cells[2].Value.ToString();
            tbNguoiGui.Text = rows.Cells[3].Value.ToString();
            rtbNoiDung.Text = rows.Cells[7].Value.ToString();
        }

        private void btGui_Click(object sender, EventArgs e)
        {
            fNewMail newMail = new fNewMail();
            newMail.ShowDialog();
        }

        private void rbThuGui_CheckedChanged(object sender, EventArgs e)
        {
            dtgvHomThu.DataSource = mailDAO.getSentMailsOfCitizen(new Cityzen { Macd = CurrentUser.Instance.CurrentCitizen.Macd });
            function = "fn_MailGuiTheoMaCongDan";
            searchingNamePerson = "TenNguoiNhan";
            searchingIDPerson = "MaNguoiNhan";
            rbTheoTenNguoi.Text = "Theo tên người nhận";
            rbTheoMaNguoi.Text = "Theo mã người nhận";
        }

        private void dtgvHomThu_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgvHomThu.Columns["Ngay"].DefaultCellStyle.Format = "yyyy-MM-dd";
        }

        private void rbThuNhan_CheckedChanged(object sender, EventArgs e)
        {
            fHomThu_Load(sender, e);
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbMaMail.Text.Trim()))
                {

                    mailDAO.DeleteMail(tbMaMail.Text);
                    MessageBox.Show("Xóa thành công!!!");
                }
                else
                    throw new Exception("Vui lòng trọn mail cần xóa!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btXem_Click(sender, e);
            }
        }
    }
}
