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
    public class DeviceTypeRepository: IDeviceTypeRepository
    {
        public void CreateDeviceType(DeviceType deviceType, DbContext dbContext)
        {
            dbContext.Set<DeviceType>().Add(deviceType);
        }

        public void DeleteDeviceType(DeviceType deviceType, DbContext dbContext)
        {
            dbContext.Entry(deviceType).State = EntityState.Deleted;
        }

        public IQueryable<DeviceType> GetAllDeviceType(DbContext dbContext)
        {
            return dbContext.Set<DeviceType>();
        }

        public void UpdateDeviceType(DeviceType deviceTypeExisting, DeviceType deviceType, DbContext dbContext)
        {
            dbContext.Entry(deviceTypeExisting).CurrentValues.SetValues(deviceType);
        }
    }
}
