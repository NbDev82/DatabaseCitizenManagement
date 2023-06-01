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
    }
}
