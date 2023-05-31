using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    public class Households
    {
        private string maho;
        private string chuho;
        private string tinhthanh;
        private string quanhuyen;
        private string phuongxa;
        private string trangthai;
        private DateTime ngaydangky;
        public string Maho { get => maho; set => maho = value; }
        public string Chuho { get => chuho; set => chuho = value; }
        public string Tinhthanh { get => tinhthanh; set => tinhthanh = value; }
        public string Quanhuyen { get => quanhuyen; set => quanhuyen = value; }
        public string Phuongxa { get => phuongxa; set => phuongxa = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public DateTime Ngaydangky { get => ngaydangky; set => ngaydangky = value; }
        public Households() { }
        public Households(string maho, string chuho, string tinhthanh, string quanhuyen, string phuongxa, string trangthai, DateTime ngaydangky)
        {
            this.maho = maho;
            this.chuho = chuho;
            this.tinhthanh = tinhthanh;
            this.quanhuyen = quanhuyen;
            this.phuongxa = phuongxa;
            this.trangthai = trangthai;
            this.ngaydangky = ngaydangky;
        }
    }
}
