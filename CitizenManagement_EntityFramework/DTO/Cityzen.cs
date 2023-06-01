using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    public class Cityzen
    {
        private string macd;
        private string hoten;
        private string gioitinh;
        private string nghenghiep;
        private string dantoc;
        private string tongiao;
        private string tinhtrang;
        private bool tinhTrangHonNhan;
        public string Macd { get => macd; set => macd = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Nghenghiep { get => nghenghiep; set => nghenghiep = value; }
        public string Dantoc { get => dantoc; set => dantoc = value; }
        public string Tongiao { get => tongiao; set => tongiao = value; }
        public string Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public bool TinhTrangHonNhan { get => tinhTrangHonNhan; set => tinhTrangHonNhan = value; }
        public Cityzen() { }
        public Cityzen(string HoTen, string GioiTinh, string DanToc)
        {
            this.hoten = HoTen;
            this.gioitinh = GioiTinh;
            this.dantoc = DanToc;
        }

        public Cityzen(string macd, string hoten, string gioitinh, string nghenghiep, string dantoc, string tongiao, string tinhtrang, bool TinhTrangHonNhan)
        {
            this.macd = macd;
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.nghenghiep = nghenghiep;
            this.dantoc = dantoc;
            this.tongiao = tongiao;
            this.tinhtrang = tinhtrang;
            this.tinhTrangHonNhan = TinhTrangHonNhan;
        }

        public Cityzen(DataRow row)
        {
            try
            {
                this.macd = (string)row["MaCD"];
                this.hoten = (string)row["HoTen"];
                this.gioitinh = (string)row["GioiTinh"];
                this.nghenghiep = (string)row["NgheNghiep"];
                this.dantoc = (string)row["DanToc"];
                this.tongiao = (string)row["TonGiao"];
                this.tinhtrang = (string)row["TinhTrang"];
                this.tinhTrangHonNhan = (bool)row["TinhTrangHonNhan"];
            }
            catch { }
        }

        public static List<string> getListDanToc()
        {
            return new List<string>
            {
                "Kinh",
                "Chăm",
                "Tày",
                "Tày Thanh",
                "Tày Trung",
                "Tày Bình",
                "Thái",
                "Thái Đen",
                "Thái Trắng",
                "Thái Hàng Tổng",
                "Mường",
                "Khơ Mú",
                "Mảng",
                "Mạ",
                "Cơ Ho",
                "Giáy",
                "La Hủ",
                "Lào",
                "Lự",
                "Lự Tán",
                "Lự Lở",
                "Phù Lá",
                "La Chí",
                "Xinh Mun",
                "Hà Nhì",
                "Chứt",
                "Cờ Lao",
                "La Ha",
                "Pà Thẻn",
                "Vàng Đỏ",
                "La Hu",
                "Lô Lô",
                "Chứt",
                "Pháp",
                "Ngái",
                "Sán Dìu",
                "Dao",
                "Sán Chay",
                "Gié-Triêng",
                "Cống",
                "Bố Y",
                "Brâu",
                "Rơ-măm",
                "Ơ Đu",
                "Bán Rồng",
                "Si La",
                "Pu Péo",
                "Rục",
                "Cống",
                "Ngải",
                "Ê-đê",
                "Xơ-đăng",
                "Hrê",
                "Cơ Tu",
                "Giẻ-Triêng",
                "Gia Rai",
                "Chơ-ro",
                "Mạ",
                "Xinh-mun",
                "Lào",
                "Lự",
                "Mương",
                "Tà Ôi"
            };
        }

        public static List<string> getListGioiTinh()
        {
            return new List<string>
            {
                "Nam",
                "Nữ"
            };
        }

        public static List<string> getListTinhTrangHonNhan()
        {
            return new List<string>
            {
                "Độc thân",
                "Đã kết hôn"
            };
        }

        public static List<string> getListTinhTrang()
        {
            return new List<string>
            {
                "Còn sống",
                "Đã chết"
            };
        }
    }
}
