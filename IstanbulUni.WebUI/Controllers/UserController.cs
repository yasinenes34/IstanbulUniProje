using IstanbulUni.BAL.Concrate;
using IstanbulUni.DAL.EntityFramewrok;
using IstanbulUni.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IstanbulUni.WebUI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserManager um = new UserManager(new EfUserDl());
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Index(User user)
        {
            var userInfo = um.UserLogin(user);


            if (userInfo)
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                Session["Email"] = user.Email;


                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // ViewBag.durum = 0;

                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Logout()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "User");
        }


        #region Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Register(User user)
        {

            var userVarMi = um.UserLogin(user);

            if (userVarMi)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                um.UserAddBl(user);
                return Json(true, JsonRequestBehavior.AllowGet);

            }



        }



        #endregion


    }
}