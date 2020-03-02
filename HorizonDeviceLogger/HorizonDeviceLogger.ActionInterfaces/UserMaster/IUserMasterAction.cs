using HorizonDeviceLogger.Models.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.ActionInterfaces.UserMaster
{
    public interface IUserMasterAction : IMasterAction
    {
        long CreateUpdatedUser(AddUser model);
        long DeleteUser(UserMasterDto model);
        List<UserLoginMstDto> GetAllUser(long UserId);
        UserMasterDto GetUserById(long Id);
        long UpdateUser(AddUser model);
        bool IsAlreadySigned(long UserId, string CheckStr);
    }
}
