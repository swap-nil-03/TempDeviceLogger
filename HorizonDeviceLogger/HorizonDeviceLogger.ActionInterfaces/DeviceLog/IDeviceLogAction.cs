using HorizonDeviceLogger.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.ActionInterfaces
{
    public interface IDeviceLogAction:IMasterAction
    {
        int CreateDeviceLog(DeviceLogDto deviceLogDto);
        List<DeviceLogDto> GetAllDeviceLog();
        DeviceLogDto GetTopFirstDeviceLog();
        DeviceLogDto SpGetLatestDeviceLog();
        List<DeviceLogDto> SpGetAllDeviceLog();
    }
}
