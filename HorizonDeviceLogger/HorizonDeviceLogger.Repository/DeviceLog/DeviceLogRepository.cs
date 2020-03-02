using HorizonDeviceLogger.DB.DB;
using HorizonDeviceLogger.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Repository
{
    public class DeviceLogRepository: IDeviceLogRepository
    {
        public void CreateDeviceLog(DeviceLog DeviceLog, DbContext dbContext)
        {
            dbContext.Set<DeviceLog>().Add(DeviceLog);
        }

        public void DeleteDeviceLog(DeviceLog DeviceLog, DbContext dbContext)
        {
            dbContext.Entry(DeviceLog).State = EntityState.Deleted;
        }

        public IQueryable<DeviceLog> GetAllDeviceLog(DbContext dbContext)
        {
            return dbContext.Set<DeviceLog>();
        }

        public void UpdateDeviceLog(DeviceLog DeviceLogExisting, DeviceLog DeviceLog, DbContext dbContext)
        {
            dbContext.Entry(DeviceLogExisting).CurrentValues.SetValues(DeviceLog);
        }

        public SpGetLatestDeviceLog_Result SpGetLatestDeviceLog(DbContext dbContext)
        {
            return dbContext.Database.SqlQuery<SpGetLatestDeviceLog_Result>("exec SpGetLatestDeviceLog").FirstOrDefault();
        }       
    }
}
