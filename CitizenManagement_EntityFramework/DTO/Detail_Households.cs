using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    internal class Detail_Households
    {
        private string maho;
        private string macd;
        private string tinhtrangcutru;
        private string quanhevoichuho;
        private DateTime ngaydangky;
        private string trangthai;
        public string Maho { get => maho; set => maho = value; }
        public string Macd { get => macd; set => macd = value; }
        public string Tinhtrangcutru { get => tinhtrangcutru; set => tinhtrangcutru = value; }
        public string Quanhevoichuho { get => quanhevoichuho; set => quanhevoichuho = value; }
        public DateTime Ngaydangky { get => ngaydangky; set => ngaydangky = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public Detail_Households() { }
        public Detail_Households(string maho, string macd, string tinhtrangcutru, string quanhevoichuho, DateTime ngaydangky, string trangthai)
        {
            this.maho = maho;
            this.macd = macd;
            this.tinhtrangcutru = tinhtrangcutru;
            this.quanhevoichuho = quanhevoichuho;
            this.ngaydangky = ngaydangky;
            this.trangthai = trangthai;
        }
    }
}
