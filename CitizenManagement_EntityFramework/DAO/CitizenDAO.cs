using System;
using System.Collections.Generic;
using System.Data;
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

        public bool Update(Cityzen cd)
        {
            string strSQL = string.Format(
                $"UPDATE Citizens " +
                $"SET HoTen = N'{cd.Hoten}', GioiTinh = N'{cd.Gioitinh}', NgheNghiep = N'{cd.Nghenghiep}', DanToc = N'{cd.Dantoc}', TonGiao = N'{cd.Tongiao}' " +
                $"WHERE MaCD = '{cd.Macd}'");
            return DBConnection.Instance.Execute(strSQL);
        }

        public Cityzen GetCitizenByMaCD(string id)
        {
            try
            {
                string strQuery = string.Format($"SELECT * FROM PERSONAL_INFORMATION pi WHERE pi.MaCD = '{id}'");
                DataTable dt = DBConnection.Instance.GetDataTable(strQuery);
                Cityzen cd = new Cityzen(dt.Rows[0]);
                return cd;
            }
            catch
            {
                return null;
            }
        }

        public List<Cityzen> getListAllCityzen()
        {
            List<Cityzen> cityzens = new List<Cityzen>();
            DataTable dt = getCitizen();
            foreach (DataRow dr in dt.Rows)
            {
                Cityzen ctz = new Cityzen(dr);
                cityzens.Add(ctz);
            }
            return cityzens;
        }

        public DataTable getCitizen()
        {
            string sqlStr = string.Format("SELECT MaCD, HoTen FROM PERSONAL_INFORMATION");
            return DBConnection.Instance.GetDataTable(sqlStr);
        }

        public DataTable getAllCitizen()
        {
            string sqlStr = string.Format("SELECT * FROM PERSONAL_INFORMATION");
            return DBConnection.Instance.GetDataTable(sqlStr);
        }

        public DataTable getCitizenTheoId(string id)
        {
            string sqlStr = string.Format("SELECT * FROM fn_TimCongDanTheoMaCd('{0}')", id);
            return DBConnection.Instance.GetDataTable(sqlStr) ;
        }

        public DataTable getCitizenTheoDanToc(string danToc)
        {
            string sqlStr = string.Format("SELECT * FROM fn_TimTheoDanToc('{0}')", danToc);
            return DBConnection.Instance.GetDataTable(sqlStr);
        }

        public DataTable getCitizenTheoTen(string ten)
        {
            string sqlStr = string.Format("SELECT * FROM fn_TimTheoTen('{0}')", ten);
            return DBConnection.Instance.GetDataTable(sqlStr);
        }

        public DataTable getCitizenTheoNgheNghiep(string ngheNghiep)
        {
            string sqlStr = string.Format("SELECT * FROM fn_TimTheoNgheNghiep('{0}')", ngheNghiep);
            return DBConnection.Instance.GetDataTable(sqlStr);
        }
    }
}
