using HorizonDeviceLogger.DB.DB;
using HorizonDeviceLogger.Models.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.AdapterInterfaces.UserMaster
{
    public interface IUserMasterAdapter : IMasterAdapter
    {
        List<UserLoginMstDto> GetAlluserDetail(long UserId);
        long CreateUser(UserLoginMstDto model);
        long UpdateUser(UserMasterDto model);
        UserMasterDto GetUserById(long Id);
        long DeleteUser(UserMasterDto model);
        long UpdateUserActiveStatus(UserMasterDto model);
    }
}
