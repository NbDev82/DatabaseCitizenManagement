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
        public Births BirthByID(string ID)
        {
            string sqlStr = string.Format("SELECT * FROM FN_DataBirthByID('{0}')", ID);
            DataTable dt = DBConnection.Instance.GetDataTable(sqlStr);
            return new Births(dt.Rows[0]);
        }
        public DataTable GetBirths() 
        {
            string sqlStr = string.Format("select * from V_GetBriths");
            DataTable dataTable=DBConnection.Instance.GetDataTable(sqlStr);
            return dataTable;
        }
        public DataTable GetUserDeleted()
        {
            string sqlStr = string.Format("select * from V_UserDeleted");
            DataTable dataTable = DBConnection.Instance.GetDataTable(sqlStr);
            return dataTable;
        }
        public DataTable getDataBirthInYear(int Year)
        {
            string sqlStr = string.Format("SELECT * from dbo.Fn_CountDeathInYear('{0}')",Year);
            DataTable dataTable = DBConnection.Instance.GetDataTable(sqlStr);
            return dataTable;
        }
        public DataTable getUserDeletedInYear(int Year) 
        {
            string sqlStr = string.Format("SELECT * from Fn_CountBirthsInYear('{0}')", Year);
            DataTable dataTable = DBConnection.Instance.GetDataTable(sqlStr);
            return dataTable;

        }
    }
}
