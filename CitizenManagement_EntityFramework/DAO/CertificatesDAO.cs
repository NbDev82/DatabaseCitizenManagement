using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    internal class CertificatesDAO
    {
        private static CertificatesDAO instance;
        public static CertificatesDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CertificatesDAO();
                return instance;
            }
        }
        public DataTable GetCertificateNearlyExpired()
        {
            try
            {
                string SQL = string.Format($"SELECT * FROM [dbo].[Fn_CongDanSapHetHanSuDung] () ");
                DataTable dt = DBConnection.Instance.GetDataTable(SQL);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetCertificateExpired()
        {
            try
            {
                string SQL = string.Format($"SELECT * FROM [dbo].[Fn_CongDanHetHanSuDung]() ");
                DataTable dt = DBConnection.Instance.GetDataTable(SQL);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataRow GetCurrentDataUser(string macd)
        {
            try
            {
                string SQL = string.Format($"SELECT * FROM FN_GetDataUser('{macd}') ");
                DataTable dt = DBConnection.Instance.GetDataTable(SQL);
                return dt.Rows[0];
            }
            catch
            {
                return null;
            }
        }
        public DataTable CitizenBelongProvince(string province)
        {
            try
            {
                string SQL = string.Format($"SELECT * FROM dbo.GetCitizensByProvince (N'{province}') ");
                DataTable dt = DBConnection.Instance.GetDataTable(SQL);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable CitizenWithoutCertificate()
        {
            try
            {
                string SQL = string.Format("SELECT * FROM Citizens_Without_Certificates ");
                DataTable dt = DBConnection.Instance.GetDataTable(SQL);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public bool Add(Certificate cccd, byte[] Img)
        {
            try
            {
                if (cccd == null)
                    return false;
                string strSQL = string.Format($"EXEC PROC_RegisterCertificate '{cccd.MaCD}',N'{cccd.QuocTich}',N'{cccd.QueQuan}',N'{cccd.NoiThuongTru}',N'{cccd.DacDiemNhanDang}',@image");
                return DBConnection.Instance.ExecuteWithParameter(strSQL,"image", Img);
            }
            catch
            {
                return false;
            }
        }
        public DataTable GetDataTable()
        {
            try
            {
                string SQL = string.Format("SELECT * " +
                                       "FROM V_GetCertificates ");
                DataTable dt = DBConnection.Instance.GetDataTable(SQL);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetCertificateByID(string macd)
        {
            try
            {
                string SQL = string.Format($"SELECT * FROM FN_GetCertificates('{macd}') ");
                DataTable dt = DBConnection.Instance.GetDataTable(SQL);
                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
