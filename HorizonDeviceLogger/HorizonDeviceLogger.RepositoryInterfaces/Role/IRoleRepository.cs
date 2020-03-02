using HorizonDeviceLogger.DB.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.RepositoryInterfaces.Role
{
    public interface IRoleRepository : IMasterRepository
    {
        void CreateRole(RoleMst role, DbContext dbContext);
        void DeleteRole(RoleMst role, DbContext dbContext);
        IQueryable<RoleMst> GetAllRole(DbContext dbContext);
        void UpdateRole(RoleMst deviceExisting, RoleMst role, DbContext dbContext);
    }
}
