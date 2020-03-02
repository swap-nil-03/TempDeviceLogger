using HorizonDeviceLogger.ActionInterfaces.Login;
using HorizonDeviceLogger.AdapterInterfaces.Login;
using HorizonDeviceLogger.Models.DTO.Login;
using HorizonDeviceLogger.Models.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Action.Login
{
    public class LoginAction : ILoginAction
    {
        private readonly ILoginAdapter _loginAdapter = null;
        public LoginAction(ILoginAdapter loginAdapter)
        {
            this._loginAdapter = loginAdapter;
        }

        public UserLoginDto CheckUserAuthorization(LoginModel model)
        {
            return _loginAdapter.CheckUserAuthorization(model);
        }

    }
}
