using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    internal class Temporarily_Staying
    {
        public string ID { get; set; }
        public string MaCD { get; set; }
        public string MaCCCD { get; set; }
        public string Tinh { get; set; }
        public string Huyen { get; set; }
        public string Xa { get; set; }
        public string LyDo { get; set; }
        public DateTime thoi_gian_bat_dau { get; set; }
        public string TrangThai { get; set; }
        public Temporarily_Staying() { }
        public Temporarily_Staying(string MaCD, string MaCCCD, string Tinh, string Huyen, string Xa, string LyDo, DateTime thoi_gian_bat_dau)
        {
            this.MaCD = MaCD;
            this.MaCCCD = MaCCCD;
            this.Tinh = Tinh;
            this.Huyen = Huyen;
            this.Xa = Xa;
            this.LyDo = LyDo;
            this.thoi_gian_bat_dau = thoi_gian_bat_dau;
        }
        public Temporarily_Staying(DataRow dt)
        {
            this.ID = (string)dt["ID"];
            this.MaCD = (string)dt["Mã CD"];
            this.MaCCCD = dt["Mã CCCD"].ToString();
            this.Tinh = dt["Tỉnh"].ToString();
            this.Huyen = dt["Huyện"].ToString();
            this.Xa = dt["Xã"].ToString();
            this.LyDo = dt["Lý do"].ToString();
            this.thoi_gian_bat_dau = (DateTime)dt["Thời gian bắt đầu"];
            this.TrangThai = dt["Trạng thái"].ToString();
        }
    }
}
