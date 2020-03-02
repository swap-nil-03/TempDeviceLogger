﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HorizonDeviceLogger.AdapterInterfaces;
using HorizonDeviceLogger.Models.DTO;

namespace HorizonDeviceLogger.ActionInterfaces
{
    public interface IDeviceAction: IMasterAction
    {
        List<DeviceDto> GetAllDevices();
        DeviceDto GetDeviceById(int Id);
        int UpdateDevice(DeviceDto model);
        int CreateDevice(DeviceDto model);
        int DeleteDevice(DeviceDto model);
    }
}