using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework.DAO
{
    internal class Temporarily_AbsentDAO
    {
        private static Temporarily_AbsentDAO instance;
        public static Temporarily_AbsentDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Temporarily_AbsentDAO();
                return instance;
            }
        }
        public DataTable GetListExpiredPermission()
        {
            try
            {
                string SQL = string.Format($"select * from View_ListExpiredPermission");
                DataTable dt = DBConnection.Instance.GetDataTable(SQL);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetListExpired()
        {
            try
            {
                string SQL = string.Format($"select * from View_ListExpired");
                DataTable dt = DBConnection.Instance.GetDataTable(SQL);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public bool Delete(Temporarily_Absent tv)
        {
            try
            {
                if (tv == null)
                    return false;
                string strSQL = string.Format($"EXEC proc_DeleteTemporarilyAbsentData @ID = '{tv.ID}'");
                return DBConnection.Instance.Execute(strSQL);
            }
            catch
            {
                return false;
            }
        }
        public bool SetAccess(Temporarily_Absent tv)
        {
            try
            {
                if (tv == null)
                    return false;
                string strSQL = string.Format($"EXEC proc_UpdateTemporarilyAbsentStatus @ID = '{tv.ID}', @Status = N'Đã duyệt'; ");
                return DBConnection.Instance.Execute(strSQL);
            }
            catch
            {
                return false;
            }
        }
        public bool Add(Temporarily_Absent tv)
        {
            try
            {
                if (tv == null)
                    return false;
                string strSQL = string.Format($"EXEC proc_InsertTemporarilyAbsent\r\n    @ID = '{tv.ID}',\r\n    @MaCD = '{tv.MaCD}',\r\n    @MaCCCD = '{tv.MaCCCD}',\r\n    @Tinh = N'{tv.Tinh}',\r\n    @Huyen = N'{tv.Huyen}',\r\n    @Xa = N'{tv.Xa}',\r\n    @LyDo = N'{tv.LyDo}',\r\n    @thoi_gian_bat_dau = '{tv.thoi_gian_bat_dau}',\r\n    @thoi_gian_ket_thuc = '{tv.thoi_gian_ket_thuc}'");
                return DBConnection.Instance.Execute(strSQL);
            }
            catch
            {
                return false;
            }
        }
        public DataTable GetPartDataByMaCD(string Macd)
        {
            string strSQL = string.Format($"select * from View_Temporarily_Absent where  View_Temporarily_Absent.[Mã CD] = '{Macd}'");
            DataTable dt = DBConnection.Instance.GetDataTable(strSQL);
            return dt;
        }
        public DataTable GetEntireData()
        {
            string strSQL = string.Format($"select * from View_Temporarily_Absent");
            DataTable dt = DBConnection.Instance.GetDataTable(strSQL);
            return dt;
        }
        public string NewMaTamVang()
        {
            string sqlStr = string.Format("DECLARE @NewMaTamVang VARCHAR(10); SET @NewMaTamVang = dbo.func_GenerateMaTamVang(); SELECT @NewMaTamVang as MaTamVang");
            //string sqlStr = string.Format("EXEC dbo.func_GenerateMaTamVang()");
            DataTable dt = DBConnection.Instance.GetDataTable(sqlStr);
            string matamtru = (string)dt.Rows[0]["MaTamVang"];
            return matamtru;
        }
    }
}
