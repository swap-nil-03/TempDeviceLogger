using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HorizonDeviceLogger.DB.DB;
namespace HorizonDeviceLogger.RepositoryInterfaces
{
    public interface IDeviceRepository:IMasterRepository
    {
        //CRUD
        void CreateDevice(Device device, DbContext dbContext);
        IQueryable<Device> GetAllDevice(DbContext dbContext);
        void UpdateDevice(Device deviceExisting, Device device, DbContext dbContext);
        void DeleteDevice(Device device, DbContext dbContext);
    }
}
