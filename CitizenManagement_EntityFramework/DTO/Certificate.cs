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
            this.MaCD = (string)dt["MaCD"];
            this.MaCCCD = dt["MaCCCD"].ToString();
            this.QuocTich = dt["QuocTich"].ToString();
            this.QueQuan = dt["QueQuan"].ToString();
            this.NoiThuongTru = dt["NoiThuongTru"].ToString();
            this.HanSuDung = dt["HanSuDung"].ToString();
            this.DacDiemNhanDang = dt["DacDiemNhanDang"].ToString();
            if (dt["Avatar"] != DBNull.Value)
            {
                byte[] imageBytes = (byte[])dt["Avatar"];
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    this.Avatar = Image.FromStream(ms);
                }
            }
        }
    }
}
