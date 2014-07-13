using DairyCow.BLL;
using System.Web.Mvc;

namespace CowSite.Controllers
{
    public class LoginController : Controller
    {
        public JsonResult Login(string userID)
        {
            //BasePage.CurrentUser = new User()
            //{
            //    ID = 1,
            //    Pasture = new Pasture()
            //    {
            //        ID = 1
            //    }
            //};
            UserBLL.Instance.GetCurrentUser("farmadmin", "123");
            return Json(1, JsonRequestBehavior.AllowGet);
        }
	}
}