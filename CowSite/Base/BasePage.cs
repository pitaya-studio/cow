using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CowSite.Base
{
    public class BasePage
    {
        //public static User CurrentUser 
        //{
        //    get
        //    {
        //        HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies.Get("CurrentUserCookie");
        //        User currentUser = new User();                
        //        currentUser.ID = Convert.ToInt32(cookie["UserID"]);
        //        currentUser.Pasture = new Pasture();
        //        currentUser.Pasture.ID = Convert.ToInt32(cookie["PastureID"]);
        //        return currentUser;
        //    }
        //    set
        //    {
        //        HttpCookie cookie = new HttpCookie("CurrentUserCookie");
        //        cookie["UserID"] = value.ID.ToString();
        //        cookie["PastureID"] = value.Pasture.ID.ToString();
        //        System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        //    }
        //}
    }
}