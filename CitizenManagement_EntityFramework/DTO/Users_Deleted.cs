using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    public class Users_Deleted
    {
        public string Macd { get; set; }
        public string Nguoikhai { get; set; }
        public string Nguyennhan { get; set; }
        public DateTime Ngaytu { get; set; }
        public DateTime Ngaykhai { get; set; }
        public DateTime NgayDuyet { get; set; }
        public Users_Deleted() { }
        public Users_Deleted(string Macd, string Nguoikhai, string Nguyennhan, DateTime Ngaytu, DateTime Ngaykhai, DateTime NgayDuyet)
        {
            this.Macd = Macd;
            this.Nguoikhai = Nguoikhai;
            this.Nguyennhan = Nguyennhan;
            this.Ngaytu = Ngaytu;
            this.Ngaykhai = Ngaykhai;
            this.NgayDuyet = NgayDuyet;
        }
        public Users_Deleted(DataRow dt)
        {
            this.Macd = (string)dt["MaCD"];
            this.Nguoikhai = (string)dt["NguoiKhai"];
            this.Nguyennhan = (string)dt["NguyenNhan"];
            this.Ngaytu = (DateTime)dt["NgayTu"];
            this.Ngaykhai = (DateTime)dt["NgayKhai"];
            this.NgayDuyet = (DateTime)dt["NgayDuyet"];
        }
    }
}
