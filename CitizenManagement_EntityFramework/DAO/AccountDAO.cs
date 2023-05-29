﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        enum Roles
        {
            Cityzen = 0,
            Manager = 1,
        }
        public Accounts GetAut(string username, string password, int Role)
        {
            try
            {
                if (Role == (int)Roles.Manager)
                {
                    string connstr = string.Format(Properties.Settings.Default.cnnManager, username, password);
                    using (SqlConnection connection = new SqlConnection(connstr))
                    {
                        connection.Open();
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            DBConnection.Instance.ChangeMode(connstr);
                        }
                        connection.Close();
                        bool role = Role == 1 ? true : false;
                        return new Accounts(role);
                    }
                }
                else if (Role == (int)Roles.Cityzen)
                {
                    string SQL = string.Format($"SELECT * FROM dbo.FN_CheckAuthentication('{username}','{password}');");
                    DataTable dt = DBConnection.Instance.GetDataTable(SQL);
                    Accounts acc = new Accounts(dt.Rows[0]);
                    return acc;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
