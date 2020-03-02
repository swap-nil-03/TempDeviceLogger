using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using HorizonDeviceLogger.ActionInterfaces;
using HorizonDeviceLogger.Models.DTO;
using HorizonDeviceLogger.Models.Models;
namespace HorizonDeviceLogger.Web.Areas.DeviceType.Controllers
{
    public class DeviceTypeController : Controller
    {
        private readonly IDeviceTypeAction _deviceTypeAction = null;
        public DeviceTypeController(IDeviceTypeAction deviceTypeAction)
        {
            this._deviceTypeAction = deviceTypeAction;
        }
        // GET: DeviceType/DeviceType
        public ActionResult Index()
        {
            var result = _deviceTypeAction.GetAllDevicesType();
            return View(result);
        }

        // GET: DeviceType/DeviceType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeviceType/DeviceType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceType/DeviceType/Create
        [HttpPost]
        public ActionResult Create(DeviceTypeModel model)
        {
            try
            {
                // TODO: Add insert logic here
                // TODO: Add update logic here
                DeviceTypeDto deviceTypedto = new DeviceTypeDto();
                //Mapper.AssertConfigurationIsValid();
                Mapper.CreateMap<DeviceTypeModel, DeviceTypeDto>();
                deviceTypedto = Mapper.Map<DeviceTypeModel, DeviceTypeDto>(model);

                var result = _deviceTypeAction.CreateDeviceType(deviceTypedto);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: DeviceType/DeviceType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DeviceType/DeviceType/Edit/5
        [HttpPost]
        public ActionResult Edit(DeviceTypeModel model)
        {
            try
            {
                // TODO: Add update logic here
                DeviceTypeDto deviceTypedto = new DeviceTypeDto();
                //Mapper.AssertConfigurationIsValid();
                Mapper.CreateMap<DeviceTypeDto, DeviceTypeModel>();
                deviceTypedto = Mapper.Map<DeviceTypeModel, DeviceTypeDto>(model);

                var result = _deviceTypeAction.UpdateDeviceType(deviceTypedto);
                if (result>0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }                
            }
            catch
            {
                return View();
            }
        }

        // GET: DeviceType/DeviceType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DeviceType/DeviceType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult isExistsDeviceTypeName(string DeviceTypeName)
        {
            return Json(_deviceTypeAction.IsExistsDeviceTypeName(DeviceTypeName));
        }
    }
}
