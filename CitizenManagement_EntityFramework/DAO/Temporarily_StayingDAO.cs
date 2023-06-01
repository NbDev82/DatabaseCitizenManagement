using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework.DAO
{
    public class Temporarily_StayingDAO
    {
        private static Temporarily_StayingDAO instance;
        public static Temporarily_StayingDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new Temporarily_StayingDAO();
                return instance;
            }
        }
        public bool Delete(Temporarily_Staying tt)
        {
            try
            {
                if (tt == null)
                    return false;
                string strSQL = string.Format($"EXEC proc_DeleteTemporarilyStayingData @ID = '{tt.ID}'");
                return DBConnection.Instance.Execute(strSQL);
            }
            catch
            {
                return false;
            }
        }
        public bool SetAccess(Temporarily_Staying tt)
        {
            try
            {
                if (tt == null)
                    return false;
                string strSQL = string.Format($"EXEC proc_UpdateTemporarilyStayingStatus @ID = '{tt.ID}'");
                return DBConnection.Instance.Execute(strSQL);
            }
            catch
            {
                return false;
            }
        }
        public bool Add(Temporarily_Staying tt)
        {
            try
            {
                if (tt == null)
                    return false;
                string strSQL = string.Format($"EXEC proc_InsertTemporarilyStaying \r\n\t@ID = '{tt.ID}',\r\n\t@MaCD = '{tt.MaCD}',\r\n\t@MaCCCD = '{tt.MaCCCD}',\r\n\t@Tinh = '{tt.Tinh}',\r\n\t@Huyen = '{tt.Huyen}',\r\n\t@Xa = '{tt.Xa}',\r\n\t@LyDo = '{tt.LyDo}',\r\n\t@thoi_gian_bat_dau = '{tt.thoi_gian_bat_dau}'");
                return DBConnection.Instance.Execute(strSQL);
            }
            catch
            {
                return false;
            }
        }
        public DataTable GetPartDataByMaCD(string Macd)
        {
            string strSQL = string.Format($"select * from view_TemporarilyStaying where view_TemporarilyStaying.[Mã CD] = '{Macd}'");
            DataTable dt = DBConnection.Instance.GetDataTable(strSQL);
            return dt;
        }
        public DataTable GetEntireData()
        {
            string strSQL = string.Format($"select * from view_TemporarilyStaying");
            DataTable dt = DBConnection.Instance.GetDataTable(strSQL);
            return dt;
        }
        public string NewMaTamTru()
        {
            string sqlStr = string.Format("DECLARE @NewMaTamTru VARCHAR(10); SET @NewMaTamTru = dbo.func_GenerateMaTamTru(); SELECT @NewMaTamTru as MaTamTru");
            DataTable dt = DBConnection.Instance.GetDataTable(sqlStr);
            string matamtru = (string)dt.Rows[0]["MaTamTru"];
            return matamtru;
        }
    }
}
