using HorizonDeviceLogger.DB.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.RepositoryInterfaces
{
    public interface IDeviceLogRepository : IMasterRepository
    {
        void CreateDeviceLog(DeviceLog deviceLog, DbContext dbContext);
        IQueryable<DeviceLog> GetAllDeviceLog(DbContext dbContext);
        void UpdateDeviceLog(DeviceLog deviceLogExisting, DeviceLog deviceLog, DbContext dbContext);
        void DeleteDeviceLog(DeviceLog deviceLog, DbContext dbContext);

        SpGetLatestDeviceLog_Result SpGetLatestDeviceLog(DbContext dbContext);       

    }
}
