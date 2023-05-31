using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CitizenManagement_EntityFramework.DAO
{
    public class MailDAO
    {
        public void AddMail(Mails newMail)
        {
            string sqlStr = string.Format("INSERT INTO Mails (MaMail,TieuDe, Ngay, NguoiGui, NguoiNhan, NoiDung) VALUES('{0}',N'{1}', '{2}', '{3}', '{4}', N'{5}')", newMail.Mamail, newMail.Tieude, newMail.Ngay, newMail.Nguoigui, newMail.Nguoinhan, newMail.Noidung);
            DBConnection.Instance.Execute(sqlStr);
        }

        public void DeleteMail(string maMail)
        {
            string sqlStr = string.Format("DELETE FROM Mails WHERE MaMail = '{0}' AND (NguoiGui = '{1}' or NguoiNhan = '{1}')", maMail, "CD0001");
            DBConnection.Instance.Execute(sqlStr);
        }

        public DataTable getAllMail()
        {
            string sqlStr = string.Format("SELECT * FROM MAILBOX ");
            return DBConnection.Instance.GetDataTable(sqlStr);
        }
        
        public DataTable getMailsByNameOfCitizen(string name, string function, string searchingPerson)
        {
            string sqlStr = string.Format("SELECT * FROM {2} ('{1}') WHERE {3} LIKE '%{0}%'", name, "CD0001", function, searchingPerson);
            return DBConnection.Instance.GetDataTable(sqlStr);
        }

        public DataTable getMailsByDayOfCitizen(string searchingDay, string function)
        {
            string sqlStr = string.Format("SELECT * FROM {2} ('{1}') WHERE Ngay like '%{0}%'", searchingDay, "CD0001", function);
            return DBConnection.Instance.GetDataTable(sqlStr);
        }

        public DataTable getMailsByIDOfCitizen(string ID, string function, string searchingIDPerson)
        {
            string sqlStr = string.Format("SELECT * FROM {2} ('{1}') WHERE {3} LIKE '%{0}%'", ID, "CD0001", function, searchingIDPerson);
            return DBConnection.Instance.GetDataTable(sqlStr);
        }

        public DataTable getSentMailsOfCitizen(Cityzen ctz)
        {
            string sqlStr = string.Format("SELECT * FROM fn_MailGuiTheoMaCongDan('{0}')", ctz.Macd);
            return DBConnection.Instance.GetDataTable(sqlStr);
        }

        public DataTable getInboxMailsOfCitizen(Cityzen ctz)
        {
            string sqlStr = string.Format("SELECT * FROM fn_MailNhanTheoMaCongDan('{0}')", ctz.Macd);
            return DBConnection.Instance.GetDataTable(sqlStr);
        }
    }
}
