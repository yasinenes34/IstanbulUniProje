using IstanbulUni.BAL.Concrate;
using IstanbulUni.DAL.EntityFramewrok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IstanbulUni.WebUI.Controllers
{
    public class HomeController : Controller
    {
        UserManager um = new UserManager(new EfUserDl());
        WebMasterManager manager = new WebMasterManager(new EfWebMasterDl());
        public ActionResult Index()
        
        {
            DateTime time = DateTime.Today;
            var userData = um.getByLast(time);
            
           
            return View(userData);
        }
        [HttpPost]
        public ActionResult Read_Chart()
        {
            var userData = um.GetListBl();
            return Json(userData);
        }
        
    }
}