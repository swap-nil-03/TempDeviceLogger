using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HorizonDeviceLogger.Models.DTO;
namespace HorizonDeviceLogger.AdapterInterfaces
{
    public interface IDeviceLogAdapter:IMasterAdapter
    {
        int CreateDeviceLog(DeviceLogDto deviceLogDto);
        List<DeviceLogDto> GetAllDeviceLog();
        DeviceLogDto GetTopFirstDeviceLog();
        DeviceLogDto SpGetLatestDeviceLog();
        List<DeviceLogDto> SpGetAllDeviceLog();
    }
}
