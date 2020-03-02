using AutoMapper;
using HorizonDeviceLogger.ActionInterfaces.Role;
using HorizonDeviceLogger.ActionInterfaces.UserMaster;
using HorizonDeviceLogger.Models.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HorizonDeviceLogger.Web.Areas.User.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserMasterAction _userMasterAction = null;
        private readonly IRoleAction _roleAction = null;
        public UserController(IUserMasterAction userMasterAction, IRoleAction roleAction)
        {

            this._userMasterAction = userMasterAction;
            this._roleAction = roleAction;
        }
        //public UserController(IRoleAction roleAction)
        //{
        //    this._roleAction = roleAction;
        //}


        // GET: User/User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayUser()
        {
            List<UserLoginMstDto> model = new List<UserLoginMstDto>();

            try
            {
                model = _userMasterAction.GetAllUser(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            AddUser model = new AddUser();
            try
            {
                model.roleList = _roleAction.GetRoleList();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return View(model);
        }
        [HttpPost]
        public JsonResult IsAlreadySigned(long UserId, string UserName)
        {
            return Json(_userMasterAction.IsAlreadySigned(UserId, UserName));

        }
        [HttpPost]
        public JsonResult IsAlreadySignedMobNo(long UserId,  string MobileNo)
        {
            // string Chech
            return Json(_userMasterAction.IsAlreadySigned(UserId, MobileNo));

        }
        [HttpPost]
        public JsonResult IsAlreadySignedEmailId(long UserId, string EmailId)
        {
            // string Chech
            return Json(_userMasterAction.IsAlreadySigned(UserId, EmailId));

        }



        [HttpPost]
        public ActionResult AddUser(AddUser model)
        {
            long ResultId = 0;
            try
            {
                if (model.RoleId != 0)
                {
                    ResultId = _userMasterAction.CreateUpdatedUser(model);
                    if(ResultId>0)
                    {
                        TempData["AlertClass"] = "alert-success";
                        TempData["UserMassage"] = "user created successfully";
                        return RedirectToAction("DisplayUser", "User", new { Area = "User" });
                    }
                    TempData["AlertClass"] = "alert-danger";
                    TempData["UserMassage"] = "please fill the form properly";
                }
                model.roleList = _roleAction.GetRoleList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edituser(long UserId)
        {
            AddUser model = new AddUser();
            try
            {
                //TempData["UserId"] =
                var Temp= _userMasterAction.GetAllUser(UserId).FirstOrDefault();
                if(Temp!=null)
                {
                    Mapper.CreateMap<UserLoginMstDto, AddUser>();
                    model = Mapper.Map<UserLoginMstDto, AddUser>(Temp);
                    model.Password = Temp.Password;
                    model.ConfirmPassword = Temp.Password;
                    model.roleList = _roleAction.GetRoleList();
                }
                else
                {
                    TempData["AlertClass"] = "alert-danger";
                    TempData["UserMassage"] = "User Record not Found.";
                    return RedirectToAction("DisplayUser", "User", new { Area = "User" });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edituser(AddUser model)
        {
            long ResultId = 0;
            try
            {
                if (model.RoleId != 0)
                {
                    ResultId = _userMasterAction.CreateUpdatedUser(model);
                    if (ResultId > 0)
                    {
                        TempData["AlertClass"] = "alert-success";
                        TempData["UserMassage"] = "user Updated successfully";
                        return RedirectToAction("DisplayUser", "User", new { Area = "User" });
                    }
                    TempData["AlertClass"] = "alert-danger";
                    TempData["UserMassage"] = "please fill the form properly";
                }
                model.roleList = _roleAction.GetRoleList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult DeactiveUser(long UserId,bool Flag)
        {
            long ResultId = 0;
            AddUser model = new AddUser();
            try
            {
                if(UserId>0)
                {
                    model.UserId = UserId;
                    model.IsActive = Flag;
                    model.Status = "DeactiveStatus";

                    ResultId = _userMasterAction.CreateUpdatedUser(model);
                    if (ResultId > 0)
                    {
                        TempData["AlertClass"] = "alert-success";
                        TempData["UserMassage"] = "user Status Updated successfully";
                        return RedirectToAction("DisplayUser", "User", new { Area = "User" });
                    }
                }
               
                TempData["AlertClass"] = "alert-danger";
                TempData["UserMassage"] = "something went wrong please try again";
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("DisplayUser", "User", new { Area = "User" });
        }
    }
}