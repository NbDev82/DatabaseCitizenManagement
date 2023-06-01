using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CitizenManagement_EntityFramework.DAO
{
    public class HouseholdDAO
    {
        private readonly string HOKHAU = "Households";
        private readonly string CHITIETHOKHAU = "Detail_Households";
        private readonly string MAHO = "MaHo";
        private readonly string MACD = "MaCD";
        private readonly string CONGDAN = "Citizens";
        private readonly string KHAISINH = "Births";
        private static HouseholdDAO instance;
        public static HouseholdDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new HouseholdDAO();
                return instance;
            }
        }
        public DataTable LayThongTinThanhVien(int macd)
        {
            string strSQL = string.Format($"" +
                $"SELECT * " +
                $"FROM {CONGDAN}, {CHITIETHOKHAU}, {KHAISINH} " +
                $"WHERE {CONGDAN}.{MACD} = {CHITIETHOKHAU}.{MACD} AND {CONGDAN}.{MACD} = {KHAISINH}.{MACD} AND {CONGDAN}.{MACD} = '{macd}'");
            DataTable dt = DBConnection.Instance.GetDataTable(strSQL);
            return dt;
        }
        public string LayMaHo(string Macd)
        {
            try
            {
                string strSQL = string.Format($"SELECT {MAHO} FROM {CHITIETHOKHAU} WHERE {MACD} = '{Macd}'");
                DataTable dt = DBConnection.Instance.GetDataTable(strSQL);
                string maHo = (string)dt.Rows[0][MAHO];
                return maHo;
            }
            catch
            {
                return null;
            }
        }
        public bool Fill(string MaHo, List<Control> ltext)
        {
            DataTable HoKhau = LayDanhSach(MaHo, HOKHAU);
            if (HoKhau.Rows.Count > 0)
            {
                int i = 0;
                foreach (Control c in ltext)
                {
                    c.Text = HoKhau.Rows[0][i++].ToString();
                }
                return true;
            }
            return false;
        }
        public DataTable LayDanhSach(string maHo, string Loai)
        {
            string strSQL = string.Format($"SELECT * FROM {Loai} WHERE {MAHO} = '{maHo}'");
            DataTable HoKhau = DBConnection.Instance.GetDataTable(strSQL);
            return HoKhau;
        }
        public DataTable GetHoKhauByID(string maHo)
        {
            try
            {
                string strSQL = string.Format($"SELECT * FROM View_HouseholdsByMaHo WHERE MaHo = '{maHo}'");
                DataTable HoKhau = DBConnection.Instance.GetDataTable(strSQL);
                if (HoKhau.Rows.Count <= 0)
                    throw new Exception("Không tồn tại hộ khẩu");
                return HoKhau;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        public DataTable GetHoKhau()
        {
            try
            {
                string strSQL = string.Format("SELECT * FROM View_HouseholdsByMaHo");
                DataTable HoKhau = DBConnection.Instance.GetDataTable(strSQL);
                if (HoKhau.Rows.Count <= 0)
                    throw new Exception();
                return HoKhau;
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            return null;
        }
        public bool AddToChiTietHoKhau(string macd, string MaHo, string quanhe)
        {
            try
            {
                string strSQL = string.Format($"EXEC proc_InsertDetailHousehold \r\n    @MaHo = '{MaHo}',\r\n    @MaCD = '{macd}',\r\n    @TinhTrangCuTru = N'Thường trú',\r\n    @QuanHeVoiChuHo = '{quanhe}',\r\n    @NgayDangKy = '{DateTime.Now}',\r\n    @TrangThai = N'Chưa duyệt'");
                if (DBConnection.Instance.Execute(strSQL))
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
        public string LayMaHoTuHoKhau(string Machuho)
        {
            try
            {
                string strSQL = string.Format($"SELECT * FROM {HOKHAU} WHERE ChuHo = '{Machuho}' ");
                DataTable dt = DBConnection.Instance.GetDataTable(strSQL);
                string maho = (string)dt.Rows[0]["MaHo"];
                return maho;
            }
            catch
            {
                return null;
            }
        }
        public bool AddToHoKhau(Households hk)
        {
            try
            {
                string trangThai = hk.Trangthai == "1" ? "Đã Duyệt" : "Chưa Duyệt";
                string strSQL = string.Format($"EXEC proc_InsertHousehold \r\n    @MaHo = '{hk.Maho}',\r\n    @ChuHo = '{hk.Chuho}',\r\n    @TinhThanh = N'{hk.Tinhthanh}',\r\n    @QuanHuyen = N'{hk.Quanhuyen}',\r\n    @PhuongXa = N'{hk.Phuongxa}',\r\n    @NgayDangKy = '{hk.Ngaydangky}',\r\n    @TrangThai = N'{trangThai}'");
                if (DBConnection.Instance.Execute(strSQL))
                {
                    string MaHo = LayMaHoTuHoKhau(hk.Chuho);
                    if (MaHo == null)
                        return false;
                    string addToDetailHouseholds = string.Format($"EXEC proc_InsertDetailHousehold\r\n    @MaHo = '{MaHo}',\r\n    @MaCD = '{hk.Chuho}',\r\n    @TinhTrangCuTru = N'Thường trú',\r\n    @QuanHeVoiChuHo = N'Chủ hộ',\r\n    @NgayDangKy = '{hk.Ngaydangky}',\r\n    @TrangThai = N'{trangThai}'");
                    DBConnection.Instance.Execute(addToDetailHouseholds);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public string NewMaHo()
        {
            string sqlStr = string.Format("DECLARE @NewMaHo VARCHAR(10); SET @NewMaHo = dbo.GenerateMaHo(); SELECT @NewMaHo as MaHo");
            DataTable dt = DBConnection.Instance.GetDataTable(sqlStr);
            string maho = (string)dt.Rows[0]["MaHo"];
            return maho;
        }
        public bool Delete(string macd)
        {
            string strSQL = string.Format($"EXEC proc_DeleteDetailHousehold @MaCD = '{macd}'");
            return DBConnection.Instance.Execute(strSQL);
        }
    }
}
