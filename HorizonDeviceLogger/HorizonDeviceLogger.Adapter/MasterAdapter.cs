using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HorizonDeviceLogger.AdapterInterfaces;
using HorizonDeviceLogger.DB.DB;

namespace HorizonDeviceLogger.Adapter
{
    public class MasterAdapter : IMasterAdapter
    {
        internal DbContext _dbContext = null;
        internal IOTLoggerEntities1 _IOTLoggerEntities = null;
        public MasterAdapter(DbContext dbContext)
        {

            _dbContext = dbContext;
            _dbContext.Database.CommandTimeout = int.MaxValue;
            _IOTLoggerEntities = (IOTLoggerEntities1)dbContext;
            _IOTLoggerEntities.Database.CommandTimeout = int.MaxValue;
        }
    }
}