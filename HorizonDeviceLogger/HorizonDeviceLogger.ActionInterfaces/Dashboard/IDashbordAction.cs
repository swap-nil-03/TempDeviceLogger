using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HorizonDeviceLogger.Models.DTO;
namespace HorizonDeviceLogger.ActionInterfaces
{
    public interface IDashbordAction:IMasterAction
    {
        DashboardDto GetDashboardData();
    }
}
