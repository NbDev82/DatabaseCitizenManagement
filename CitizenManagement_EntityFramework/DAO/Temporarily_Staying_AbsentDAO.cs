using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework.DAO
{
    public class Temporarily_Staying_AbsentDAO
    {
        private static Temporarily_Staying_AbsentDAO instance;
        public static Temporarily_Staying_AbsentDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Temporarily_Staying_AbsentDAO();
                return instance;
            }
        }
        public DataRow GetPersonalData(string Macd)
        {
            try
            {
                string MaHo = HouseholdDAO.Instance.LayMaHo(Macd);
                string strSQL = string.Format($"SELECT Citizens.MaCD AS N'Mã CD', HoTen AS N'Họ tên', MaCCCD AS N'Mã CCCD', NgaySinh AS N'Ngày sinh', TinhThanh AS N'Tỉnh', QuanHuyen AS N'Huyện', PhuongXa AS N'Xã' " +
                                              $"FROM Citizens, Certificates, Births, Households " +
                                              $"WHERE Citizens.MaCD = Certificates.MaCD AND Citizens.MaCD = Births.MaCD AND Households.MaHo = '{MaHo}' AND Citizens.MaCD = '{Macd}'");
                DataTable dt = DBConnection.Instance.GetDataTable(strSQL);
                return dt.Rows[0];
            }
            catch
            {
                return null;
            }
        }
    }
}
