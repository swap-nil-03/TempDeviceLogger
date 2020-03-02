using System.Web.Mvc;

namespace HorizonDeviceLogger.Web.Areas.DataAnalytics
{
    public class DataAnalyticsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DataAnalytics";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DataAnalytics_default",
                "DataAnalytics/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}