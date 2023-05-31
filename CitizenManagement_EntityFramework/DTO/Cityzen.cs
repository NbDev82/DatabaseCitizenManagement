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
        private bool mahonnhan;
        public string Macd { get => macd; set => macd = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Nghenghiep { get => nghenghiep; set => nghenghiep = value; }
        public string Dantoc { get => dantoc; set => dantoc = value; }
        public string Tongiao { get => tongiao; set => tongiao = value; }
        public string Tinhtrang { get => tinhtrang; set => tinhtrang = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public bool Mahonnhan { get => mahonnhan; set => mahonnhan = value; }
        public Cityzen() { }
        public Cityzen(string HoTen, string GioiTinh, string DanToc)
        {
            this.hoten = HoTen;
            this.gioitinh = GioiTinh;
            this.dantoc = DanToc;
        }
        public Cityzen(string macd, string hoten, string gioitinh, string nghenghiep, string dantoc, string tongiao, string tinhtrang, bool mahonnhan)
        {
            this.macd = macd;
            this.hoten = hoten;
            this.gioitinh = gioitinh;
            this.nghenghiep = nghenghiep;
            this.dantoc = dantoc;
            this.tongiao = tongiao;
            this.tinhtrang = tinhtrang;
            this.mahonnhan = mahonnhan;
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
                this.mahonnhan = Convert.ToBoolean(row["MaHN"]);
            }
            catch { }
        }
    }
}
