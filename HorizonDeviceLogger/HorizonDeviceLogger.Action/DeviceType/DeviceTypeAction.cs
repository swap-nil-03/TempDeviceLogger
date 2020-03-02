using HorizonDeviceLogger.ActionInterfaces;
using HorizonDeviceLogger.AdapterInterfaces;
using HorizonDeviceLogger.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Action
{
    public class DeviceTypeAction:IDeviceTypeAction     
    {
        private readonly IDeviceTypeAdapter _deviceTypeAdapter = null;
        public DeviceTypeAction(IDeviceTypeAdapter deviceTypeAdapter)
        {
            this._deviceTypeAdapter = deviceTypeAdapter;
        }
        public int CreateDeviceType(DeviceTypeDto model)
        {
            return _deviceTypeAdapter.CreateDeviceType(model);
        }

        public int DeleteDeviceType(DeviceTypeDto model)
        {
            return _deviceTypeAdapter.DeleteDeviceType(model);
        }

        public List<DeviceTypeDto> GetAllDevicesType()
        {
            return _deviceTypeAdapter.GetAllDevicesType();
        }

        public DeviceTypeDto GetDeviceTypeById(int Id)
        {
            return _deviceTypeAdapter.GetDeviceTypeById(Id);
        }

        public int UpdateDeviceType(DeviceTypeDto model)
        {
            return _deviceTypeAdapter.UpdateDeviceType(model);
        }

        public bool IsExistsDeviceTypeName(string DeviceTypeName)
        {
            return _deviceTypeAdapter.IsExistsDeviceTypeName(DeviceTypeName);
        }
    }

}
