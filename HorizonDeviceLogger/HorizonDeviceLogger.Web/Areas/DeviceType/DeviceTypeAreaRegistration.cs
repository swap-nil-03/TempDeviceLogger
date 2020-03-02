using System.Web.Mvc;

namespace HorizonDeviceLogger.Web.Areas.DeviceType
{
    public class DeviceTypeAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DeviceType";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DeviceType_default",
                "DeviceType/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}