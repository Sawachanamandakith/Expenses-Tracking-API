using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebApplication1.Interfaces;
using WebApplication1.Models.RequestApiModels;

namespace WebApplication1.Controllers
{
    public class WishListController : Controller
    {
        private readonly IWishList _wishList;

        public WishListController(IWishList wishList)
        {
            _wishList = wishList;
        }

        [HttpPost]
        public ActionResult AddWish(WishListRequestAPI request)
        {
            var result = _wishList.AddWish(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult MarkWishCompleted(WishListRequestAPI request)
        {
            var result = _wishList.MarkWishCompleted(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAllWishes(int userId)
        {
            WishListRequestAPI request = new WishListRequestAPI { UserID = userId };
            var result = _wishList.GetAllWishes(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}