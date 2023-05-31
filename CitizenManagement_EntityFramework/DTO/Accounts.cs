using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    public class Accounts
    {
        public string Macd { get; set; }
        public string Matkhau { get; set; }
        public bool Phanquyen { get; set; }
        public Accounts() { }
        public Accounts(bool Phanquyen)
        {
            this.Phanquyen = Phanquyen;
        }
        public Accounts(DataRow dt)
        {
            this.Macd = (string)dt["MaCD"];
            this.Matkhau = (string)dt["matkhau"];
            this.Phanquyen = (bool)dt["phanquyen"];
        }
    }
}
