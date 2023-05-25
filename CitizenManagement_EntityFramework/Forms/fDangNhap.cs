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

            string username = txtAccount.Text;
            string password = txtPassword.Text;
            int Role = rdoAutControler.Checked? 1 : 0;
            Cityzen citizen = AccountDAO.Instance.GetAut(username,password, Role);
            if (citizen != null)
            {
                MessageBox.Show("Đăng nhập thành công");
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
