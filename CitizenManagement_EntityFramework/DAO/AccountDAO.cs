using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    internal class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
        }
        public Cityzen GetAut(string username, string password, int Role)
        {
            Cityzen cityzen = DBConnection.Instance.GetAut(username, password, Role);
            return cityzen;
        }
    }
}
