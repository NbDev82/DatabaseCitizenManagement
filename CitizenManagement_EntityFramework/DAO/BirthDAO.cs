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
        public Users_Deleted Users_DeletedByID(string ID)
        {
            string sqlStr = string.Format("select * from dbo.FN_UserDeletedByID('{0}')", ID);
            DataTable dt=DBConnection.Instance.GetDataTable(sqlStr);
            return new Users_Deleted(dt.Rows[0]);
        }
        public DataTable GetBirths() 
        {
            string sqlStr = string.Format("select * from V_GetBirths");
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
          
            string sqlStr = string.Format("SELECT * from Fn_CountBirthsInYear('{0}')", Year);
            DataTable dataTable = DBConnection.Instance.GetDataTable(sqlStr);
            return dataTable;

        }
        public DataTable getUserDeletedInYear(int Year) 
        {
            string sqlStr = string.Format("SELECT * from dbo.Fn_CountDeathInYear('{0}')", Year);
            DataTable dataTable = DBConnection.Instance.GetDataTable(sqlStr);
            return dataTable;
        }
        public void DuyetNgaySinh(string MaCD,DateTime NgayDuyet)
        {
            string sqlStr =string.Format("EXEC PROC_DuyetNgaySinh '{0}', '{1}'", MaCD,NgayDuyet.ToString());
            DBConnection.Instance.Execute(sqlStr);
        }
        public DataTable DataGridBirthChuaDuyet()
        {
            string sqlStr = string.Format("select * from V_GetBirthNotComfirm");
            DataTable dataTable = DBConnection.Instance.GetDataTable(sqlStr);
            return dataTable;
        }
        public DataTable DataGridUserDeletedChuaDuyet()
        {
            string sqlStr = string.Format("select * from V_GetUserDeletedNotComfirm");
            DataTable dataTable = DBConnection.Instance.GetDataTable(sqlStr);
            return dataTable;
        }
                // Lay danh sach nguoi co the them UserDelete
        public DataTable GetUserDeletedTrue()
        {
            DataTable result = new DataTable();
            string conn = string.Format("Select * from V_GetUserDeletedTrue");
            result = DBConnection.Instance.GetDataTable(conn);
            return result;
        }
        // Lay Ds nhung nguoi chua khai sinh
        public DataTable GetBirthsTrue()
        {
            DataTable result = new DataTable();
            string conn = string.Format("Select * from Citizens_Without_Births");
            result= DBConnection.Instance.GetDataTable(conn);
            return result;
         }
        public void ThemBirth(Births births)
        {
            string sqlStr = string.Format("INSERT INTO Births(MaCD,NgaySinh,NoiSinh,MaCD_Cha,MaCD_Me,NgayKhai) VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", births.MaCD, births.NgaySinh, births.NoiSinh, births.MaCD_Cha, births.MaCD_Me, births.NgayKhai);
            DBConnection.Instance.Execute(sqlStr);
        }
        public void XoaBirth(Births births) 
        {
            string sqlStr = string.Format("DELETE FROM Births WHERE MaCD='{0}'", births.MaCD);
            DBConnection.Instance.Execute(sqlStr);
        }
        public void DuyetNgayChet(string MaCD, DateTime NgayDuyet)
        {
            string sqlStr = string.Format("EXEC PROC_DuyetNgayChet '{0}','{1}'",MaCD, NgayDuyet.ToString());
            DBConnection.Instance.Execute(sqlStr);

        }
    }
}
