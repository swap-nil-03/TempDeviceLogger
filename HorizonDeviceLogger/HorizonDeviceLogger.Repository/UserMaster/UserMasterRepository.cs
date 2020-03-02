using HorizonDeviceLogger.DB.DB;
using HorizonDeviceLogger.RepositoryInterfaces.UserMaster;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Repository.UserMaster
{
    public class UserMasterRepository : IUserMasterRepository
    {

        public void CreateUser(UserMst user, DbContext dbContext)
        {
            dbContext.Set<UserMst>().Add(user);
        }

        public void UpdateUser(UserMst userExisting, UserMst user, DbContext dbContext)
        {
            dbContext.Entry(userExisting).CurrentValues.SetValues(user);
        }

        public long UpdateUserActiveStatus(UserMst user, DbContext dbContext)
        {
            try
            {
                using (var db = new IOTLoggerEntities1())
                {
                    db.UserMsts.Attach(user);
                    db.Entry(user).Property(x => x.UpdatedBy).IsModified = true;
                    db.Entry(user).Property(x => x.UpdatedDate).IsModified = true;
                    db.Entry(user).Property(x => x.IsActive).IsModified = true;
                    user.UpdatedBy = "testing";
                    user.UpdatedDate = DateTime.Now;
                   return db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<UserMst> GetAllUserDetails(DbContext dbContext)
        {
            return dbContext.Set<UserMst>();
        }
        //public IQueryable<sp_GetUserDtls_Result> GetAllUserDetailsBySp(DbContext dbContext)
        //{
        //    return dbContext.Set<sp_GetUserDtls_Result>();
        //}

        public void DeleteUserDetails(UserMst user, DbContext dbContext)
        {
            dbContext.Entry(user).State = EntityState.Deleted;
        }
    }
}
