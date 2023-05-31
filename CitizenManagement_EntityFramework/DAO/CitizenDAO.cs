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
