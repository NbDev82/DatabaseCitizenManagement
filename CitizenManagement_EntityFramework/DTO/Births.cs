using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    internal class Births
    {
        public string MaCD { get; set; }
        public DateTime NgaySinh { get; set; }
        public string NoiSinh { get; set; }
        public string MaCD_Cha { get; set; }
        public string MaCD_Me { get; set; }
        public DateTime NgayKhai { get; set; }
        public DateTime NgayDuyet { get; set; }
        public Births() { }
        public Births(string MaCD, DateTime NgaySinh, string NoiSinh, string MaCD_Cha, string MaCD_Me, DateTime NgayKhai)
        {
            this.MaCD = MaCD;
            this.NgaySinh = NgaySinh;
            this.MaCD_Cha = MaCD_Cha;
            this.MaCD_Me = MaCD_Me;
            this.NgayKhai = NgayKhai;
            this.NoiSinh = NoiSinh;
        }
        public Births(DateTime NgaySinh, string NoiSinh, string MaCD_Cha, string MaCD_Me, DateTime NgayKhai)
        {
            this.NgaySinh = NgaySinh;
            this.MaCD_Cha = MaCD_Cha;
            this.MaCD_Me = MaCD_Me;
            this.NgayKhai = NgayKhai;
            this.NoiSinh = NoiSinh;
        }
        public Births(DataRow dt)
        {
            this.MaCD = (string)dt["MaCD"];
            this.NgaySinh = (DateTime)dt["NgaySinh"];
            this.MaCD_Cha = (string)dt["MaCD_Cha"];
            this.MaCD_Me = (string)dt["MaCD_Me"];
            this.NgayKhai = (DateTime)dt["NgayKhai"];
            this.NgayDuyet = (DateTime)dt["NgayDuyet"];
            this.NoiSinh = dt["NoiSinh"].ToString();
        }
    }
}
