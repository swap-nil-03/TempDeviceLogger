using HorizonDeviceLogger.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.AdapterInterfaces
{
    public interface IDeviceAdapter:IMasterAdapter
    {
        List<DeviceDto> GetAllDevices();
        DeviceDto GetDeviceById(int Id);
        int UpdateDevice(DeviceDto model);
        int CreateDevice(DeviceDto model);
        int DeleteDevice(DeviceDto model);
    }
}
