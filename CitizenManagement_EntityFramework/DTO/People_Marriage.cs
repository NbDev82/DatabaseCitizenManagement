using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework.DTO
{
    internal class People_Marriage
    {
        private string mahn;
        private string macdchong;
        private string macdvo;
        private string loai;
        private DateTime ngaydangky;
        private string xacnhanlan1;
        private string xacnhanlan2;
        private string trangthai;
        public string Mahn { get => mahn; set => mahn = value; }
        public string Macdchong { get => macdchong; set => macdchong = value; }
        public string Macdvo { get => macdvo; set => macdvo = value; }
        public string Loai { get => loai; set => loai = value; }
        public DateTime Ngaydangky { get => ngaydangky; set => ngaydangky = value; }
        public string Xacnhanlan1 { get => xacnhanlan1; set => xacnhanlan1 = value; }
        public string Xacnhanlan2 { get => xacnhanlan2; set => xacnhanlan2 = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public People_Marriage() { }
        public People_Marriage(string mahn, string macdchong, string macdvo, string loai, DateTime ngaydangky, string xacnhanlan1, string xacnhanlan2, string trangthai)
        {
            this.mahn = mahn;
            this.macdchong = macdchong;
            this.macdvo = macdvo;
            this.loai = loai;
            this.ngaydangky = ngaydangky;
            this.xacnhanlan1 = xacnhanlan1;
            this.xacnhanlan2 = xacnhanlan2;
            this.trangthai = trangthai;
        }
        public People_Marriage(DataRow row)
        {
            try
            {
                this.mahn = (string)row["MaHN"];
                this.macdchong = (string)row["MaCDChong"];
                this.macdvo = (string)row["MaCDVo"];
                this.loai = (string)row["Loai"];
                this.ngaydangky = (DateTime)row["NgayDangKy"];
                this.trangthai = (string)row["TrangThai"];
                this.xacnhanlan1 = (string)row["XacNhanLan1"];
                this.xacnhanlan2 = (string)row["XacNhanLan2"];
            }
            catch
            {

            }
        }
    }
}
