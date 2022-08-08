using IstanbulUni.BAL.Concrate;
using IstanbulUni.BAL.Model;
using IstanbulUni.DAL.EntityFramewrok;
using IstanbulUni.DAL.Model;
using IstanbulUni.WebUI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IstanbulUni.WebUI.Controllers
{
    public class WebMasterController : Controller
    {
        WebMasterManager manager = new WebMasterManager(new EfWebMasterDl());
        WebMasterHistoryManager webMasterHistoryManager = new WebMasterHistoryManager(new EfWebMasterHistory());
       
        // GET: WebMaster
        [Authorize]
        public ActionResult Index()
        {
            var list = manager.GetAll();


            return View(list);
        }
        public ActionResult EditingInline_Read([DataSourceRequest] DataSourceRequest request)
        {

            var list=manager.GetAll();

            var list1 = list.Select(a => new WebMasterViewModel { Phone = a.Phone,Name=a.Name, Surname = a.Surname,DomainName=a.DomainName,Department=a.Department,Email=a.Email,webMasterID=a.webMasterID ,createTime=a.createTime });
            
            
            return Json(list1.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_Create([DataSourceRequest] DataSourceRequest request, WebMaster webMaster,WebMasterHistory webMasterHistory)
        {
            if (webMaster != null)
            {
                webMaster.userID = int.Parse(Session["ID"].ToString());
                manager.AddWebMaster(webMaster);
                
                webMasterHistoryManager.AddWebMaster(webMasterHistory,webMaster.webMasterID);
            }

            return Json(new[] { webMaster }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_Update([DataSourceRequest] DataSourceRequest request, WebMaster webMaster, WebMasterHistory webMasterHistory)
        {
            if (webMaster != null)
            {
                manager.UpdateWebMaster(webMaster);
                webMasterHistoryManager.AddWebMaster(webMasterHistory, webMaster.webMasterID);

            }

            return Json(new[] { webMaster }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditingInline_Destroy([DataSourceRequest] DataSourceRequest request, WebMaster webMaster,WebMasterHistory webMasterHistory)
        {
            if (webMaster != null)
            {
                manager.RemoveWebMaster(webMaster);
                webMasterHistoryManager.UpdateWebMaster(webMasterHistory,webMaster.webMasterID);
            }

            return Json(new[] { webMaster }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Deneme()
        {
            var list = manager.GetAll();
            return View(list);
        }
    }
}