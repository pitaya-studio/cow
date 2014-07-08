using DairyCow.DAL.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyCow.DAL
{
    public class UserDAL : BaseDAL
    {
        //获得所有配种员
        public DataTable GetInseminationOperatorList()
        {
            DataTable inseminationOperatorList = null;

            string sql = string.Format(@"select au.ID, au.Name, au.Account, au.Password, au.RoleID, au.PastureID
                                        from Auth_User au left join Auth_Role ar on aur.RoleID = ar.ID where ar.Name = '配种员'");

            inseminationOperatorList = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return inseminationOperatorList;
        }

        public DataTable GetCurrentUser(string account, string password)
        {
            DataTable dt = null;

            string sql = string.Format(@"select *
                        from auth_user
                        where account='{0}' and password='{1}'", account, password);

            dt = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return dt;
        }

        public DataTable GetRoles ()
        {
            DataTable dt = null;

            string sql = @"select *
                        from auth_role";

            dt = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return dt;
        }

        public DataTable GetUsers(string pastureID)
        {
            DataTable dt = null;
            string sql;

            if (string.IsNullOrEmpty(pastureID))
            {
                sql = @"select * from auth_user";
            }
            else
            {
                sql = string.Format(@"select *
                            from auth_user
                            where PastureID='{0}'", pastureID);
            }
            

            dt = dataProvider1mutong.FillDataTable(sql, CommandType.Text);
            return dt;
        }

        public void InsertUser(string name, string account, string password, string roleID, string pastureID)
        {
            string sql = string.Format(@"insert into auth_user(Name,Account,Password,RoleID,PastureID)
                                         values ('{0}','{1}','{2}','{3}','{4}')",
                                        name, account,password,roleID,pastureID) ;
            dataProvider1mutong.ExecuteNonQuery(sql,CommandType.Text);
        }

        public void DeleteUser(int id)
        {
            string sql = string.Format(@"delete from auth_user where ID='{0}'", id);
            dataProvider1mutong.ExecuteNonQuery(sql, CommandType.Text);
        }

        public void ChangePassword(int userID, string password)
        {
            string sql = string.Format(@"update auth_user set Password='{0}' where ID='{1}'", password, userID);
            dataProvider1mutong.ExecuteNonQuery(sql, CommandType.Text);
        }
    }
}
