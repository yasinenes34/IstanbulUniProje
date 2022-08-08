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
      
        WebMasterManager manager = new WebMasterManager(new EfWebMasterDl());
        [Authorize]
        public ActionResult Index()
        
        {
            var webMasterData = manager.GetAll().Take(5) ;

            return View(webMasterData);
        }
        public ActionResult Chart()
        {
            
            return View(manager.ChartData());
        }
        public ActionResult ToplamChart()
        {
            return View(manager.ChartData());
        }
        
    }
}