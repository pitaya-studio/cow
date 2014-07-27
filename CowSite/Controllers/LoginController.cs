using DairyCow.BLL;
using System.Web.Mvc;

namespace CowSite.Controllers
{
    public class LoginController : Controller
    {
        public JsonResult Login(string userID)
        {            
#if DEBUG
            UserBLL.Instance.GetCurrentUser("farmadmin", "123");
            return Json(1, JsonRequestBehavior.AllowGet);
#else
            string name = Request.Form["name"];
            string password = Request.Form["password"];
            UserBLL.Instance.GetCurrentUser(name, password);
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