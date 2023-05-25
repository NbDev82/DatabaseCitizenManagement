using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    internal class Accounts
    {
        public string Macd { get; set; }
        public string Matkhau { get; set; }
        public int Phanquyen { get; set; }
        public Accounts() { }
        public Accounts(DataRow dt)
        {
            this.Macd = (string)dt["MaCD"];
            this.Matkhau = (string)dt["matkhau"];
            this.Phanquyen = (int)dt["phanquyen"];
        }
    }
}
