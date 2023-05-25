using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    internal class Mails
    {
        private string mamail;
        private string tieude;
        private DateTime ngay;
        private string nguoigui;
        private string nguoinhan;
        private string noidung;
        public string Mamail { get => mamail; set => mamail = value; }
        public string Tieude { get => tieude; set => tieude = value; }
        public DateTime Ngay { get => ngay; set => ngay = value; }
        public string Nguoigui { get => nguoigui; set => nguoigui = value; }
        public string Nguoinhan { get => nguoinhan; set => nguoinhan = value; }
        public string Noidung { get => noidung; set => noidung = value; }
        public Mails() { }
        public Mails(string mamail, string tieude, DateTime ngay, string nguoigui, string nguoinhan, string noidung)
        {
            this.mamail = mamail;
            this.tieude = tieude;
            this.ngay = ngay;
            this.nguoigui = nguoigui;
            this.nguoinhan = nguoinhan;
            this.noidung = noidung;
        }
        public Mails(string tieude, DateTime ngay, string nguoigui, string nguoinhan, string noidung)
        {
            this.tieude = tieude;
            this.ngay = ngay;
            this.nguoigui = nguoigui;
            this.nguoinhan = nguoinhan;
            this.noidung = noidung;
        }
    }
}
