using HorizonDeviceLogger.ActionInterfaces;
using HorizonDeviceLogger.AdapterInterfaces;
using HorizonDeviceLogger.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Action.DeviceLog
{
    public class DeviceLogAction : IDeviceLogAction
    {
        private readonly IDeviceLogAdapter _deviceLogAdapter = null;
        public DeviceLogAction(IDeviceLogAdapter deviceLogAdapter)
        {
            this._deviceLogAdapter = deviceLogAdapter;
        }
        public int CreateDeviceLog(DeviceLogDto deviceLogDto)
        {
            return _deviceLogAdapter.CreateDeviceLog(deviceLogDto);
        }

        public List<DeviceLogDto> GetAllDeviceLog()
        {
            return _deviceLogAdapter.GetAllDeviceLog();
        }

        public DeviceLogDto GetTopFirstDeviceLog()
        {
            return _deviceLogAdapter.GetTopFirstDeviceLog();
        }
        public DeviceLogDto SpGetLatestDeviceLog()
        {
            return _deviceLogAdapter.SpGetLatestDeviceLog();
        }

        public List<DeviceLogDto> SpGetAllDeviceLog()
        {
            return _deviceLogAdapter.SpGetAllDeviceLog();
        }
    }
}
