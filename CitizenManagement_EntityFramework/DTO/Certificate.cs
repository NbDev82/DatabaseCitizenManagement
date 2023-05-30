using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    public class Certificate
    {
        public string MaCD { get; set; }
        public string MaCCCD { get; set; }
        public string HoVaTen { get; set; }
        public string NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string QuocTich { get; set; }
        public string QueQuan { get; set; }
        public string NoiThuongTru { get; set; }
        public string HanSuDung { get; set; }
        public string DacDiemNhanDang { get; set; }
        public Image Avatar { get; set; }
        public Certificate() { }
        public Certificate(string MaCD, string HoVaTen, string NgaySinh, string GioiTinh, string QuocTich, string QueQuan, string NoiThuongTru, string DacDiemNhanDang, Image Avatar)
        {
            this.MaCD = MaCD;
            this.HoVaTen = HoVaTen;
            this.NgaySinh = NgaySinh;
            this.GioiTinh = GioiTinh;
            this.QuocTich = QuocTich;
            this.QueQuan = QueQuan;
            this.NoiThuongTru = NoiThuongTru;
            this.DacDiemNhanDang = DacDiemNhanDang;
            this.Avatar = Avatar;
        }
        public Certificate(DataRow dt)
        {
            this.MaCD = (string)dt["Mã CD"];
            this.MaCCCD = dt["Số CCCD"].ToString();
            this.HoVaTen = dt["Họ và tên"].ToString();
            this.NgaySinh = dt["Ngày sinh"].ToString();
            this.GioiTinh = dt["Giới tính"].ToString();
            this.QuocTich = dt["Quốc tịch"].ToString();
            this.QueQuan = dt["Quê quán"].ToString();
            this.NoiThuongTru = dt["Nơi thường trú"].ToString();
            this.HanSuDung = dt["Hạn"].ToString();
            this.DacDiemNhanDang = dt["Đặc điểm nhận dạng"].ToString();
            if (dt["Hình"] != DBNull.Value)
            {
                byte[] imageBytes = (byte[])dt["Hình"];
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    this.Avatar = Image.FromStream(ms);
                }
            }
        }
    }
}
