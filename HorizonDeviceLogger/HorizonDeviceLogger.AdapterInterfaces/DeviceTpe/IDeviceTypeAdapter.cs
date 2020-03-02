using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HorizonDeviceLogger.Models.DTO;
namespace HorizonDeviceLogger.AdapterInterfaces
{
    public interface IDeviceTypeAdapter:IMasterAdapter
    {
        List<DeviceTypeDto> GetAllDevicesType();
        DeviceTypeDto GetDeviceTypeById(int Id);
        int UpdateDeviceType(DeviceTypeDto model);
        int CreateDeviceType(DeviceTypeDto model);
        int DeleteDeviceType(DeviceTypeDto model);
        bool IsExistsDeviceTypeName(string DeviceTypeName);
    }
}
