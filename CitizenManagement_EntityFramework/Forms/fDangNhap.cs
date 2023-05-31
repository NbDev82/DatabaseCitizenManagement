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
    }
}
