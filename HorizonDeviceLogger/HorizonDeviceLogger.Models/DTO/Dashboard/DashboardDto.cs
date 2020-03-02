using HorizonDeviceLogger.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Models.DTO
{
    public class DashboardDto
    {
        public List<DeviceLogDto> deviceLogDtoList{ get; set; }
        public DeviceLogDto deviceLogDto { get; set; }

        public DashboardDto()
        {
            this.deviceLogDtoList = new List<DeviceLogDto>();
            this.deviceLogDto = new DeviceLogDto();
        }
    }
}
