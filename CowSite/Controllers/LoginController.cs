using CowSite.Base;
using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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