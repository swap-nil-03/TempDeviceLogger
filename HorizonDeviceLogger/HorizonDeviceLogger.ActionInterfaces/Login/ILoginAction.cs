using HorizonDeviceLogger.Models.DTO.Login;
using HorizonDeviceLogger.Models.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.ActionInterfaces.Login
{
    public interface ILoginAction : IMasterAction
    {
        UserLoginDto CheckUserAuthorization(LoginModel model);
    }
}
