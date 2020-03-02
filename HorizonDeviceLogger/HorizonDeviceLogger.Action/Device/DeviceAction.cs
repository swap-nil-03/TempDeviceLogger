using HorizonDeviceLogger.ActionInterfaces;
using HorizonDeviceLogger.AdapterInterfaces;
using HorizonDeviceLogger.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Action.Device
{
    public class DeviceAction : IDeviceAction
    {
        private readonly IDeviceAdapter _deviceAdapter = null;
        public DeviceAction(IDeviceAdapter deviceAdapter)
        {
            this._deviceAdapter = deviceAdapter;
        }
        public int CreateDevice(DeviceDto model)
        {
            return _deviceAdapter.CreateDevice(model);
        }

        public int DeleteDevice(DeviceDto model)
        {
            return _deviceAdapter.DeleteDevice(model);
        }

        public List<DeviceDto> GetAllDevices()
        {
            return _deviceAdapter.GetAllDevices();
        }

        public DeviceDto GetDeviceById(int Id)
        {
            return _deviceAdapter.GetDeviceById(Id);
        }

        public int UpdateDevice(DeviceDto model)
        {
            return _deviceAdapter.UpdateDevice(model);
        }
    }
}
