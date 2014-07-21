﻿using DairyCow.BLL;
using DairyCow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CowSite.Controllers.Feed
{
    /// <summary>
    /// 牛舍维护
    /// </summary>
    public class CowHouseController : Controller
    {
        HouseBLL bllHouse = new HouseBLL();
        CowGroupBLL bllCowGroup = new CowGroupBLL();
        public JsonResult GetCowHouseInfo()
        {
            int pastureID = Convert.ToInt32(UserBLL.Instance.CurrentUser.Pasture.ID);
            List<House> lstHouse = bllHouse.GetHouseList(pastureID);
            var cowHouseData = new
            {
                Rows = lstHouse
            };
            return Json(cowHouseData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List()
        {
            return View("~/Views/Feed/CowHouse/List.cshtml");
        }

        //增加牛舍
        public JsonResult Add(string houseName, string groupID)
        {
            House house = new House();
            house.PastureID = UserBLL.Instance.CurrentUser.Pasture.ID;
            house.Name = houseName;
            if (Convert.ToInt32(groupID) != 0)
            {
                house.GroupID = Convert.ToInt32(groupID);
                //增加分配牛群的牛舍
                bllHouse.AddHouse(house);
            }
            else
            {
                //增加未分配牛群的牛舍
                bllHouse.AddUnusedHouse(house);
            }
            return Json(1, JsonRequestBehavior.AllowGet);
        }

        //删除牛舍（当此牛舍不存在牛时）
        public JsonResult Delete(string name, string groupID, string id)
        {
            House house = new House();
            house.ID = Convert.ToInt32(id);
            house.Name = name;
            house.GroupID = Convert.ToInt32(groupID);
            house.PastureID = UserBLL.Instance.CurrentUser.Pasture.ID;
            //删除牛群
            bllHouse.DeleteHouse(house);
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(string name, string groupID, string id)
        {
            bllHouse.UpdateHouseGroup(Convert.ToInt32(id), Convert.ToInt32(groupID));
            return Json(1, JsonRequestBehavior.AllowGet);
        }
    }
}