using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework.DAO
{
    public class People_MarriageDAO
    {
        public DataTable DataGridPeopleMarriage()
        {
            string sqlStr = string.Format("SELECT * FROM V_GetPeopleMarriage");
            return DBConnection.Instance.GetDataTable(sqlStr);
        }
        public int CountData
    }
}
