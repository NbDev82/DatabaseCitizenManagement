using CitizenManagement_EntityFramework.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    public class PeopleMarriageDAO
    {
        // Lấy toàn bộ thông tin của hôn nhân
        public DataTable DataGrid()
        {
            DataTable dataTable = new DataTable();
            string conn = String.Format("select * from V_GetPeopleMarriage");
            dataTable = DBConnection.Instance.GetDataTable(conn);
            return dataTable;
        }
        public People_Marriage GetPeople_Marriage(string ID)
        {
            string conn = string.Format("Select * from V_GetPeopleMarriage WHERE MaHN='{0}'", ID);
            DataTable dt=DBConnection.Instance.GetDataTable(conn);
            return new People_Marriage(dt.Rows[0]);
        }
        // Dem so luong hon nhan
        public int NumberFaminly()
        {
            return DataGrid().Rows.Count;
        }
        // Hai vo chông dang ky ket hôn
        public bool UpdateMarriage(People_Marriage hn)
        {
            string conn = String.Format("EXEC PROC_UPDATEMarriage '{0}','{1}', '{2}'", hn.Mahn, hn.Xacnhanlan1, hn.Xacnhanlan2);
            return DBConnection.Instance.Execute(conn);
        }
        // Them 1 gia dinh moi
        public bool AddAFamily(People_Marriage hn)
        {
            string conn = String.Format("EXEC PROC_RegisterMarriage '{0}', '{1}', '{2}', N'{3}', '{4}', '{5}', '{6}', N'{7}'", hn.Mahn, hn.Macdchong, hn.Macdvo, hn.Loai, hn.Ngaydangky, hn.Xacnhanlan1, hn.Xacnhanlan2,hn.Trangthai);
            return DBConnection.Instance.Execute(conn);
        }
        // ly hôn - Xóa family ra khỏi database
        public bool DivorceMarriage(People_Marriage hn)
        {
            string conn = String.Format("EXEC PROC_DivorceMarriage '{0}'", hn.Mahn);
            return DBConnection.Instance.Execute(conn);
        }

        // family được  xác nhận 
        public bool BROWSEMarriage(People_Marriage hn)
        {
            string conn = String.Format("EXEC PROC_BROWSEMarriage '{0}',N'{1}'", hn.Mahn, hn.Trangthai);
            return DBConnection.Instance.Execute(conn);
        }
        // Danh sách các vợ chông chưa kí hôn nhân
        public DataTable DataFamilyNotConfirm()
        {
            DataTable dataTable = new DataTable();
            string conn = string.Format("SELECT * FROM dbo.FN_DataFmailyNotConfirm()");
            dataTable=DBConnection.Instance.GetDataTable(conn);
            return dataTable;
        }
        // DS cac family chua được xét duyệt
        public DataTable DataFamilyNotBrowse() 
        {
            DataTable dataTable = new DataTable();
            string conn = string.Format("SELECT * FROM dbo.FN_DataFmailyNotBrowse()");
            dataTable = DBConnection.Instance.GetDataTable(conn);
            return dataTable;
        }
        // Danh sach nhung family mới được tạo ra trong khoảng thời gian
        public DataTable DataFamilyInTime(int NumOfMonth)
        {
            DataTable dataTable = new DataTable();
            string conn = string.Format("SELECT * FROM dbo.FN_DataFmailyInTime('{0}')", NumOfMonth);
            dataTable = DBConnection.Instance.GetDataTable(conn);
            return dataTable;
        }
    }
}
