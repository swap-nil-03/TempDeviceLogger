using HorizonDeviceLogger.DB.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.RepositoryInterfaces.Login
{
    public interface ILoginRepository:IMasterRepository
    {
        void CreateLogin(LoginMst userLogin, DbContext dbContext);
        void DeleteLogin(LoginMst Login, DbContext dbContext);
        IQueryable<LoginMst> GetAllLogin(DbContext dbContext);
    }
}
