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
    public class DeviceRepository : IDeviceRepository
    {
        public void CreateDevice(Device device, DbContext dbContext)
        {
            dbContext.Set<Device>().Add(device);
        }

        public void DeleteDevice(Device device, DbContext dbContext)
        {
            dbContext.Entry(device).State = EntityState.Deleted;
        }        

        public IQueryable<Device> GetAllDevice(DbContext dbContext)
        {
            return dbContext.Set<Device>();
        }

        public void UpdateDevice(Device deviceExisting, Device device, DbContext dbContext)
        {
            dbContext.Entry(deviceExisting).CurrentValues.SetValues(device);
        }
    }
}
