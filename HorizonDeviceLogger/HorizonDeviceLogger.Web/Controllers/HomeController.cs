using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HorizonDeviceLogger.ActionInterfaces;
namespace HorizonDeviceLogger.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeviceAction _deviceAction = null;
        public HomeController(IDeviceAction deviceAction)
        {
            this._deviceAction = deviceAction;
        }

        public ActionResult Dashboard() 
        {

            return View();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
           // var res = _deviceAction.GetAllDevices();
            return View();
        }

    }
}
