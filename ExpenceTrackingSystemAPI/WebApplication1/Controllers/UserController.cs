using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DataAccess;
using WebApplication1.Interfaces;
using WebApplication1.Models;
using WebApplication1.Models.RequestApiModels;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _User;


        public UserController(IUser user)
        {
            _User = user;
        }

        [HttpPost]
        public ActionResult Register(UserRequestAPI user)
        {
            var result = _User.Register(user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Login(UserLoginRequest user)
        {

            var result = _User.Login(user);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ForgotPassword(UserForgotPasswordRequest request)
        {
            var result = _User.ForgotPassword(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ResetPassword(UserResetPasswordRequest request)
        {
            var result = _User.ResetPassword(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
