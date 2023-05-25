using System;
using System.Collections.Generic;
using System.Data;
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
        public bool Add(Certificate cccd, byte[] img)
        {
            try
            {
                if (cccd == null)
                    return false;
                string strSQL = string.Format($"INSERT INTO Certificates (MaCD, QuocTich, QueQuan, NoiThuongTru, DacDiemNhanDang, Avatar) " +
                                              $"VALUES ('{cccd.MaCD}',N'{cccd.QuocTich}',N'{cccd.QueQuan}',N'{cccd.NoiThuongTru}',N'{cccd.DacDiemNhanDang}',{img})");
                return DBConnection.Instance.Execute(strSQL);
            }
            catch
            {
                return false;
            }
        }
        public DataTable GetDataTable()
        {
            string SQL = string.Format("SELECT * " +
                                       "FROM V_GetCertificates ");
            DataTable dt = DBConnection.Instance.GetDataTable(SQL);
            return dt;
        }
        public DataTable GetCertificateByID(string macd)
        {
            string SQL = string.Format("SELECT * " +
                                       "FROM V_GetCertificates " +
                                       $"WHERE MaCD = '{macd}'");
            DataTable dt = DBConnection.Instance.GetDataTable(SQL);
            return dt;
        }
    }
}
