using IstanbulUni.BAL.Concrate;
using IstanbulUni.DAL.EntityFramewrok;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IstanbulUni.WebUI.Controllers
{
    public class WebMasterLogController : Controller
    {
        WebMasterHistoryManager webMasterHistoryManager=new WebMasterHistoryManager(new EfWebMasterHistory());
        // GET: WebMasterLog
        public ActionResult Index()
        {
            
            return View(webMasterHistoryManager.GetAll());
        }

        public ActionResult EditingInline_Read([DataSourceRequest] DataSourceRequest request)
        {

            var model = webMasterHistoryManager.GetAll();
            return Json(model.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}