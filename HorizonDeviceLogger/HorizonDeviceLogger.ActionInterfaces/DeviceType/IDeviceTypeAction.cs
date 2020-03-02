using HorizonDeviceLogger.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.ActionInterfaces
{
    public interface IDeviceTypeAction:IMasterAction
    {
        List<DeviceTypeDto> GetAllDevicesType();
        DeviceTypeDto GetDeviceTypeById(int Id);
        int UpdateDeviceType(DeviceTypeDto model);
        int CreateDeviceType(DeviceTypeDto model);
        int DeleteDeviceType(DeviceTypeDto model);
        bool IsExistsDeviceTypeName(string DeviceTypeName);
    }
}
