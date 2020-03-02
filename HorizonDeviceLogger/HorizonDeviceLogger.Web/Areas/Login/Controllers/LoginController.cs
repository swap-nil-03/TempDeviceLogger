using HorizonDeviceLogger.ActionInterfaces.Login;
using HorizonDeviceLogger.Models.DTO.Login;
using HorizonDeviceLogger.Models.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HorizonDeviceLogger.Web.Areas.Login.Controllers
{
    public class LoginController : Controller
    {

        private readonly ILoginAction _loginAction = null;

        public LoginController(ILoginAction loginAction)
        {
            //this._deviceLogAction = deviceLogAction;

            this._loginAction = loginAction;
        }
        // GET: Login/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginPage()
        {
            LoginModel model = new LoginModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult LoginPage(LoginModel model)
        {
            UserLoginDto userDtls = new UserLoginDto();
            try
            {
                if (model.User_name != "" && model.Pass_word != "")
                {
                    userDtls = _loginAction.CheckUserAuthorization(model);
                    if (userDtls != null)
                    {
                        // return RedirectToAction("Dashboard", "Home");
                        TempData["AlertClass"] = "alert-success";
                        TempData["UserMassage"] = "Username and password is correct";
                        return RedirectToAction("Dashboard", "Home", new { Area = "Admin" });
                    }
                }
                else
                {

                }
                TempData["AlertClass"] = "alert-danger";
                TempData["UserMassage"] = "Username and password is incorrect";
                model.IsValid = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(model);
        }
    }
}