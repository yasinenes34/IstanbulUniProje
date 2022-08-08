using IstanbulUni.BAL.Concrate;
using IstanbulUni.DAL.EntityFramewrok;
using IstanbulUni.DAL.Model;
using IstanbulUni.WebUI.Models;
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
        public ActionResult GetInfoUser(User user)
        {
            ResponseMessage res = new ResponseMessage();


            var userEmail = um.getUserMail(user.Email);
            var userPass = um.getUserPass(user.Password);
            if (userEmail)
            {
                if (userPass)
                {
                    res.IsTrue = true;
                    res.Message = "Bilgileriniz Doğru Yönlendiriliyorsunuz Lütfen Bekleyin";
                    FormsAuthentication.SetAuthCookie(user.userID.ToString(), false);//Arasındaki farkları araştır..
                    Session["ID"] = um.getUserId(user);//Arasındaki farkları araştır..
                    return Json(res, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    res.IsTrue = false;
                    res.Message = "Şifreniz Hatalı Lütfen Kontrol Ediniz...";
                  
                    return Json(res, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                res.IsTrue = false;
                res.Message = "Sistemde Kayıtlı Böyle Bir E-posta Adresi Bulunamadı Lütfen Bilgilerinizi Kontrol Ediniz";
               
                return Json(res, JsonRequestBehavior.AllowGet);
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