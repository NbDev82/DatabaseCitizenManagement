using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    public class CurrentUser
    {
        private static CurrentUser instance;
        private Cityzen currentCitizen;
        private Accounts currentAccount;

        public static CurrentUser Instance
        {
            get
            {
                if (instance == null)
                    instance = new CurrentUser();
                return instance;
            }
        }

        public Cityzen CurrentCitizen { get => currentCitizen; set => currentCitizen = value; }
        public Accounts CurrentAccount { get => currentAccount; set => currentAccount = value; }


    }
}
