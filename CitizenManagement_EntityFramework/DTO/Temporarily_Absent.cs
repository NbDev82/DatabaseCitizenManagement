using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    public class Temporarily_Absent:Temporarily_Staying
    {
        public DateTime thoi_gian_ket_thuc { get; set; }
        public Temporarily_Absent() { }
        public Temporarily_Absent(string ID, string MaCD, string MaCCCD, string Tinh, string Huyen, string Xa, string LyDo, DateTime TgianBdau, DateTime TgianKthuc)
        {
            this.ID = ID;
            this.MaCD = MaCD;
            this.MaCCCD = MaCCCD;
            this.Tinh = Tinh;
            this.Huyen = Huyen;
            this.Xa = Xa;
            this.LyDo = LyDo;
            this.thoi_gian_bat_dau = TgianBdau;
            this.thoi_gian_ket_thuc = TgianKthuc;
        }
        public Temporarily_Absent(DataRow TamVang)
        {
            this.ID = (string)TamVang["ID"];
            this.MaCD = (string)TamVang["Mã CD"];
            this.MaCCCD = TamVang["Mã CCCD"].ToString();
            this.Tinh = TamVang["Tỉnh"].ToString();
            this.Xa = TamVang["Huyện"].ToString();
            this.LyDo = TamVang["Xã"].ToString();
            this.thoi_gian_bat_dau = (DateTime)TamVang["Thời gian bắt đầu"];
            this.thoi_gian_ket_thuc = (DateTime)TamVang["Thời gian kết thúc"];
            this.TrangThai = TamVang["Trạng thái"].ToString();
        }
    }
}
