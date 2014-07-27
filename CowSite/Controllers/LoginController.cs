using DairyCow.BLL;
using System.Web.Mvc;

namespace CowSite.Controllers
{
    public class LoginController : Controller
    {
        public JsonResult Login(string user, string password)
        {            
#if DEBUG
            UserBLL.Instance.GetCurrentUser("farmadmin", "123");
            return Json(1, JsonRequestBehavior.AllowGet);
#else

            UserBLL.Instance.GetCurrentUser(user, password);
            if (UserBLL.Instance.CurrentUser == null)
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }            
#endif
        }
	}
}