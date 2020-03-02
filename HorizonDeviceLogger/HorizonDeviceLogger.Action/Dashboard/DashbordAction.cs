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
    public class DashbordAction: IDashbordAction
    {
        private readonly IDeviceLogAdapter _deviceLogAdapter = null;
        public DashbordAction(IDeviceLogAdapter deviceLogAdapter)
        {
            this._deviceLogAdapter = deviceLogAdapter;
        }

        public DashboardDto GetDashboardData()
        {
            DashboardDto dashboardDto = new DashboardDto();
            dashboardDto.deviceLogDtoList = _deviceLogAdapter.GetAllDeviceLog();
            dashboardDto.deviceLogDto = _deviceLogAdapter.GetTopFirstDeviceLog();
            return dashboardDto;
        }
    }
}
