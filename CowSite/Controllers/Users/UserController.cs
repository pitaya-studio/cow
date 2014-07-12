using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Users
{
    public class UserController : Controller
    {
        UserBLL bllUser = new UserBLL();
        //
        // GET: /User/
        public ActionResult List()
        {
            return View("~/Views/Users/List.cshtml");
        }

        public JsonResult GetUserList()
        {
            List<User> userList = bllUser.GetUsers();
            var userData = new
            {
                Rows = userList
            };
            return Json(userData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Save()
        {
            //ViewBag.UserID = Request.QueryString["UserID"];
            //User user = new User();
            //UpdateModel<User>(user);
            //bllUser.InsertUser(user.Name, user.Account, user.Password, user.Role.ID.ToString(), user.Pasture.ID.ToString());
            return View("~/Views/Users/AddUser.cshtml");
        }

        [HttpPost]
        public ActionResult SaveAddedUser()
        {
            User user = new User();
            UpdateModel<User>(user);
            bllUser.InsertUser(user.Name, user.Account, user.Password, user.Role.ID.ToString(), user.Pasture.ID.ToString());
            return RedirectToAction("../User/List");
        }

        public ActionResult Delete(int id)
        {
            //删除用户
            int userID = Convert.ToInt32(Request["userID"]);
            bllUser.DeleteUser(userID);
            return RedirectToAction("../User/List");
        }

        public ActionResult UpdatePassword()
        {
            ViewBag.UserName = UserBLL.Instance.CurrentUser.Name;
            ViewBag.UserAccount = UserBLL.Instance.CurrentUser.Account;
            return View("~/Views/Users/UpdatePassword.cshtml");
        }
        [HttpPost]
        public ActionResult UpdateUserPassword()
        {
            User user = new User();
            user.ID = UserBLL.Instance.CurrentUser.ID;
            UpdateModel<User>(user);
            bllUser.ChangePassword(user.ID, user.Password);
            return RedirectToAction("../User/List");
        }
    }
}