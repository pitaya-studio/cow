using DairyCow.BLL;
using DairyCow.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CowSite.Controllers
{
    public class LoginController : Controller
    {
        public JsonResult Login(string user, string password)
        {            
#if DEBUG
            UserBLL.Instance.GetCurrentUser("farmadmin", "123");            
#else

            UserBLL.Instance.GetCurrentUser(user, password);           
#endif
            if (UserBLL.Instance.CurrentUser == null)
            {
                return Json(new { Login = 0 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<string> menus = new List<string>();
                Role role = UserBLL.Instance.CurrentUser.Role;
                if (role.IsAdmin)
                {
                    menus.Add("Platform");
                }
                else
                {
                    menus.Add("Home");
                    menus.Add("Task");
                }
                if (role.CanBreed)
                {
                    menus.Add("Breed");
                }
                if (role.CanFeed)
                {
                    menus.Add("Feed");
                }
                if (role.CanMilk)
                {
                    menus.Add("Milk");
                }
                if (role.CanMedical)
                {
                    menus.Add("Medical");
                }
                if (role.IsDirector)
                {
                    menus.Add("FarmAdmin");
                }
                role.Menus = menus;
                return Json(new { login = 1, menu = menus }, JsonRequestBehavior.AllowGet);
            }            
        }
	}
}