using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework.DAO
{
    public class BirthDAO
    {
        private readonly string KHAISINH = "Births";
        private readonly string MACD = "MACD";
        private readonly string NGAYSINH = "NGAYSINH";
        private readonly string NOISINH = "NOISINH";
        private readonly string MACDCHA = "MACDCHA";
        private readonly string MACDME = "MACDME";
        private readonly string NGAYKHAI = "NGAYKHAI";
        private readonly string NGAYDUYET = "NGAYDUYET";
        private static BirthDAO instance;
        public static BirthDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BirthDAO();
                return instance;
            }
        }
        public Births GetKhaiSinhByID(string Macd)
        {
            try
            {
                string strSQL = string.Format($"SELECT * " +
                                              $"FROM Births " +
                                              $"WHERE MaCD = '{Macd}'");
                DataTable dt = DBConnection.Instance.GetDataTable(strSQL);
                if (dt == null)
                    return null;
                Births ks = new Births(dt.Rows[0]);
                return ks;
            }
            catch
            {
                return null;
            }
        }
    }
}
