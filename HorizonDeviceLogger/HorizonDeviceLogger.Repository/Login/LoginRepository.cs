using HorizonDeviceLogger.DB.DB;
using HorizonDeviceLogger.RepositoryInterfaces.Login;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Repository.Login
{
   public class LoginRepository : ILoginRepository
    {
        public void CreateLogin(LoginMst userLogin, DbContext dbContext)
        {
            dbContext.Set<LoginMst>().Add(userLogin);
        }

        public void DeleteLogin(LoginMst Login, DbContext dbContext)
        {
            dbContext.Entry(Login).State = EntityState.Deleted;
        }

        public IQueryable<LoginMst> GetAllLogin(DbContext dbContext)
        {
            return dbContext.Set<LoginMst>();
        }

        public void UpdateLogin(LoginMst LoginExisting, LoginMst Login, DbContext dbContext)
        {
            dbContext.Entry(LoginExisting).CurrentValues.SetValues(Login);
        }
    }
}
