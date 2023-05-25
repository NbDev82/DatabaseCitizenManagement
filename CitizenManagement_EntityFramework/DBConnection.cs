using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenManagement_EntityFramework
{
    internal class DBConnection
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnCityzen);
        private static DBConnection instance;
        enum Roles
        {
            Cityzen = 0,
            Manager = 1,
        }
        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnection();
                return instance;
            }
        }
        public Cityzen GetAut(string username, string password, int Role)
        {
            try
            {
                if (Role == (int)Roles.Manager)
                {
                    string connstr = string.Format(Properties.Settings.Default.cnnManager, username, password);
                    using (SqlConnection connection = new SqlConnection(connstr))
                    {
                        connection.Open();
                        bool isAccount = false;
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            conn = connection;
                            isAccount = true;
                        }
                        conn.Close();
                        return new Cityzen();
                    }
                }
                else if (Role == (int)Roles.Cityzen)
                {
                    string SQL = string.Format($"SELECT dbo.FN_CheckAuthentication({username},{password});");
                    DataTable dt = GetDataTable(SQL);
                    Cityzen ctz = new Cityzen(dt.Rows[0]);
                    return ctz;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public DataTable GetDataTable(string sqlStr)
        {
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool ExecuteWithParameter(string SQL, string variable, object parameter)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(SQL, conn);
                cmd.Parameters.AddWithValue($"@{variable}", parameter);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool Execute(string query)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public DataTable TimKiem(string sqlStr)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sqlStr, conn);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
}
