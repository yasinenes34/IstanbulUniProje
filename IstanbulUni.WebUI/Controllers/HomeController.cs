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
        [Authorize]
        public ActionResult Index()
        
        {
            DateTime time = DateTime.Today;
            var userData = um.getByLast(time);
            return View(userData);
        }
        public ActionResult Chart()
        {
            
            return View(manager.GetAll());
        }
        
    }
}