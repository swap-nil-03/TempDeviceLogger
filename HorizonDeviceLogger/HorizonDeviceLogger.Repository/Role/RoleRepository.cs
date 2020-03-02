using HorizonDeviceLogger.DB.DB;
using HorizonDeviceLogger.RepositoryInterfaces.Role;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Repository.Role
{
    public class RoleRepository : IRoleRepository
    {
        public void CreateRole(RoleMst role, DbContext dbContext)
        {
            dbContext.Set<RoleMst>().Add(role);
        }

        public void DeleteRole(RoleMst role, DbContext dbContext)
        {
            dbContext.Entry(role).State = EntityState.Deleted;
        }

        public IQueryable<RoleMst> GetAllRole(DbContext dbContext)
        {
            return dbContext.Set<RoleMst>();
        }

        public void UpdateRole(RoleMst deviceExisting, RoleMst role, DbContext dbContext)
        {
            dbContext.Entry(deviceExisting).CurrentValues.SetValues(role);
        }
    }
}
