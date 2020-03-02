 using System.Web.Mvc;

namespace HorizonDeviceLogger.Web.Areas.Login
{
    public class LoginAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Login";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Login_default",
                "Login/{controller}/{action}/{id}",
                new { action = "LoginPage ", id = UrlParameter.Optional }
            );
        }
    }
}