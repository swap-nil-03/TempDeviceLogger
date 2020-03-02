using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HorizonDeviceLogger.DB.DB;
namespace HorizonDeviceLogger.RepositoryInterfaces
{
    public interface IDeviceTypeRepository: IMasterRepository
    {
        void CreateDeviceType(DeviceType deviceType, DbContext dbContext);
        IQueryable<DeviceType> GetAllDeviceType(DbContext dbContext);
        void UpdateDeviceType(DeviceType deviceTypeExisting, DeviceType deviceType, DbContext dbContext);
        void DeleteDeviceType(DeviceType deviceType, DbContext dbContext);
    }
}
