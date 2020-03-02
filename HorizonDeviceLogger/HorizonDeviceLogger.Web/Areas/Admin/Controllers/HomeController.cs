using HorizonDeviceLogger.ActionInterfaces;
using HorizonDeviceLogger.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HorizonDeviceLogger.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDashbordAction _dashbordAction = null;
        private readonly IDeviceLogAction _deviceLogAction = null;
        public HomeController(IDashbordAction dashbordAction, IDeviceLogAction deviceLogAction)
        {
            this._dashbordAction = dashbordAction;
            this._deviceLogAction = deviceLogAction;
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            var result = _dashbordAction.GetDashboardData();
            return View(result );
        }
        public ActionResult Dashboard()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetLatestDeviceLog()
        {
            //var result = _deviceLogAction.GetTopFirstDeviceLog();
            DeviceLogDto result = _deviceLogAction.SpGetLatestDeviceLog();            
            if (result!=null)
            {
                if(result.ReceivedDateTime.Value!=null)
                {
                    result.ReceivedDateTimeStr = result.ReceivedDateTime.Value.ToString("dd/MMM/yyyy hh:mm:ss tt");
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}