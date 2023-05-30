using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework.DAO
{
    public class CitizenDAO
    {
        private static CitizenDAO instance;
        public static CitizenDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CitizenDAO();
                return instance;
            }
        }
        public Cityzen GetCongDanByMaCD(int id)
        {
            try
            {
                string strQuery = string.Format($"SELECT * FROM  WHERE  = {id}");
                DataTable dt = DBConnection.Instance.LayDanhSach(strQuery);
                CongDan cd = new CongDan(dt.Rows[0]);
                return cd;
            }
            catch
            {
                MessageBox.Show("Công dân không tồn tại");
            }
            return null;
        }
    }
}
