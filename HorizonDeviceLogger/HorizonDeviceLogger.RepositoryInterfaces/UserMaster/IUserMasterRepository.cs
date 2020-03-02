using HorizonDeviceLogger.DB.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.RepositoryInterfaces.UserMaster
{
    public interface IUserMasterRepository : IMasterRepository
    {
        void CreateUser(UserMst user, DbContext dbContext);
        void UpdateUser(UserMst userExisting, UserMst user, DbContext dbContext);
        IQueryable<UserMst> GetAllUserDetails(DbContext dbContext);
        //IQueryable<sp_GetUserDtls_Result> GetAllUserDetailsBySp(DbContext dbContext);
        void DeleteUserDetails(UserMst Login, DbContext dbContext);
        long UpdateUserActiveStatus(UserMst user, DbContext dbContext);
    }
}
