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
    }
}
