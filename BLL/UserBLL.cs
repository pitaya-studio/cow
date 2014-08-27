using DairyCow.DAL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DairyCow.BLL
{
    public class UserBLL
    {
        private UserDAL dalUser = new UserDAL();
        private PastureDAL dalPasture = new PastureDAL();

        private static Dictionary<int, UserBLL> _instance;
        public static UserBLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Dictionary<int, UserBLL>();
                }
                HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies.Get("CurrentUserCookie");
                if (cookie == null)
                {
                    return new UserBLL();
                }
                int userID = Convert.ToInt32(cookie["UserID"]);
                if (_instance.ContainsKey(userID))
                {
                    return _instance[userID];
                }
                else
                {
                    return new UserBLL();
                }
            }
        }

        public List<Role> Roles { get; set; }
        public List<Pasture> Pastures { get; set; }

        public User CurrentUser { get; set; }

        public UserBLL()
        {
            Roles = GetRoles();
            PastureBLL pbl = new PastureBLL();
            Pastures = pbl.GetPastures();
        }
        public void GetCurrentUser(string account, string password)
        {
            DataTable dt = dalUser.GetCurrentUser(account, password);
            if (dt != null && dt.Rows.Count != 0)
            {
                CurrentUser = WrapUser(dt.Rows[0]);
                if (!_instance.ContainsKey(CurrentUser.ID))
                {
                    _instance.Add(CurrentUser.ID, this);
                }
                HttpCookie cookie = new HttpCookie("CurrentUserCookie");
                cookie["UserID"] = CurrentUser.ID.ToString();
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static void Logout()
        {
            System.Web.HttpContext.Current.Response.Cookies.Remove("CurrentUserCookie");
        }

        //获得一个兽医
        public User GetDefaultDoctor(int id)
        {
            User user = new User();
            DataTable userData = dalUser.GetDefaultDoctor(id);
            if (userData != null && userData.Rows.Count == 1)
            {
                user = WrapUser(userData.Rows[0]);
            }
            return user;
        }

        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            DataTable dt = dalUser.GetRoles();
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Role role = new Role
                    {
                        ID = Convert.ToInt32(row["ID"]),
                        Name = row["Name"].ToString(),
                        SupervisorID = Convert.ToInt32(row["SupervisorID"]),
                        CanBreed = Convert.ToBoolean(row["CanBreed"]),
                        CanFeed = Convert.ToBoolean(row["CanFeed"]),
                        CanMedical = Convert.ToBoolean(row["CanMedical"]),
                        CanMilk = Convert.ToBoolean(row["CanMilk"]),
                        IsAdmin = Convert.ToBoolean(row["IsAdmin"]),
                        IsDirector = Convert.ToBoolean(row["IsDirector"])
                    };
                    roles.Add(role);
                }
            }
            return roles;
        }

        /// <summary>
        /// 获得所有用户
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            //只取得本牧场的用户，如果为平台用户，pasture会是null
            DataTable dt = Instance.CurrentUser == null || Instance.CurrentUser.Pasture == null ?
                dalUser.GetUsers(null) :
                dalUser.GetUsers(Instance.CurrentUser.Pasture.ID.ToString());

            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    users.Add(WrapUser(row));
                }
            }
            return users;
        }

        /// <summary>
        /// 获得所有配种员
        /// </summary>
        /// <returns></returns>
        public List<User> GetInseminationOperatorList()
        {
            List<User> lstInseminationOperator = new List<User>();

            DataTable datInseminationOperator = this.dalUser.GetInseminationOperatorList();
            foreach (DataRow row in datInseminationOperator.Rows)
            {
                User user = WrapUser(row);
                lstInseminationOperator.Add(user);
            }

            return lstInseminationOperator;
        }
        /// <summary>
        /// 获得牧场配种员list
        /// </summary>
        /// <param name="pastureID"></param>
        /// <returns></returns>
        public List<User> GetInseminationOperatorList(int pastureID)
        {
            List<User> lstInseminationOperator = new List<User>();

            DataTable datInseminationOperator = this.dalUser.GetInseminationOperatorTable(pastureID);
            foreach (DataRow row in datInseminationOperator.Rows)
            {
                User user = WrapUser(row);
                lstInseminationOperator.Add(user);
            }

            return lstInseminationOperator;
        }
        /// <summary>
        /// 获取牧场饲养员list
        /// </summary>
        /// <param name="pastureID"></param>
        /// <returns></returns>
        public List<User> GetFeederList(int pastureID)
        {
            List<User> feederList = new List<User>();

            DataTable datInseminationOperator = this.dalUser.GetFeederTable(pastureID);
            foreach (DataRow row in datInseminationOperator.Rows)
            {
                User user = WrapUser(row);
                feederList.Add(user);
            }

            return feederList;
        }
        /// <summary>
        /// 获取牧场兽医list
        /// </summary>
        /// <param name="pastureID"></param>
        /// <returns></returns>
        public List<User> GetDoctorList(int pastureID)
        {
            List<User> doctorList = new List<User>();

            DataTable datInseminationOperator = this.dalUser.GetDoctorTable(pastureID);
            foreach (DataRow row in datInseminationOperator.Rows)
            {
                User user = WrapUser(row);
                doctorList.Add(user);
            }

            return doctorList;
        }

        public List<User> GetFeederList()
        {
            List<User> lstInseminationOperator = new List<User>();

            DataTable datInseminationOperator = this.dalUser.GetInseminationOperatorList();
            foreach (DataRow row in datInseminationOperator.Rows)
            {
                User user = WrapUser(row);
                lstInseminationOperator.Add(user);
            }

            return lstInseminationOperator;
        }


        public void InsertUser(string name, string account, string password, string roleID, string pastureID)
        {
            dalUser.InsertUser(name, account, password, roleID, pastureID);
        }

        public void DeleteUser(int id)
        {
            dalUser.DeleteUser(id);
        }

        public void ChangePassword(int userID, string password)
        {
            dalUser.ChangePassword(userID, password);
        }

        private User WrapUser(DataRow row)
        {
            User user = new User();
            if (row != null)
            {
                user.ID = Convert.ToInt32(row["ID"]);
                user.Name = row["Name"].ToString();
                user.Account = row["Account"].ToString();
                user.Password = row["Password"].ToString();
                user.Role = Roles.FirstOrDefault(r => r.ID == Convert.ToInt32(row["RoleID"]));
                user.Pasture = Pastures.FirstOrDefault(P => P.ID == Convert.ToInt32(row["PastureID"]));
            }
            return user;
        }
    }
}
