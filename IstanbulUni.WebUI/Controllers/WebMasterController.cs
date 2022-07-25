using IstanbulUni.BAL.Concrate;
using IstanbulUni.DAL.EntityFramewrok;
using IstanbulUni.DAL.Model;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IstanbulUni.WebUI.Controllers
{
    public class WebMasterController : Controller
    {
        WebMasterManager manager = new WebMasterManager(new EfWebMasterDl());

        // GET: WebMaster
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EditingInline_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(manager.GetAll().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_Create([DataSourceRequest] DataSourceRequest request, WebMaster webMaster)
        {
           
            if (webMaster != null && ModelState.IsValid)
            {
                manager.AddWebMaster(webMaster);
            }

            return Json(new[] { webMaster }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_Update([DataSourceRequest] DataSourceRequest request, WebMaster webMaster)
        {
            if (webMaster != null && ModelState.IsValid)
            {
                manager.UpdateWebMaster(webMaster);
            }

            return Json(new[] { webMaster }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_Destroy([DataSourceRequest] DataSourceRequest request, WebMaster webMaster)
        {
            if (webMaster != null)
            {
                manager.RemoveWebMaster(webMaster);
            }

            return Json(new[] { webMaster }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }
    }
}