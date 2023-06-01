using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Data.SqlClient;
namespace CitizenManagement_EntityFramework
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtAccount.Text;
                string password = txtPassword.Text;
                int Role = rdoAutControler.Checked ? 1 : 0;
                bool isValid = AccountDAO.Instance.GetAut(username, password, Role);
                if (isValid)
                {
                    fNguoiDung nd = new fNguoiDung();
                    this.Hide();
                    nd.ShowDialog();
                    DBConnection.Instance.ChangeMode(Properties.Settings.Default.cnnCityzen);
                    this.Show();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!\n");
            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có thật sự muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
