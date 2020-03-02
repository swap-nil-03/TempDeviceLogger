using HorizonDeviceLogger.Models.DTO.Login;
using HorizonDeviceLogger.Models.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.AdapterInterfaces.Login
{
    public interface ILoginAdapter: IMasterAdapter
    {
        UserLoginDto CheckUserAuthorization(LoginModel model);
    }
}
