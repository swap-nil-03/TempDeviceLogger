using AutoMapper;
using HorizonDeviceLogger.AdapterInterfaces;
using HorizonDeviceLogger.AdapterInterfaces.Login;
using HorizonDeviceLogger.DB.DB;
using HorizonDeviceLogger.Models.DTO.Login;
using HorizonDeviceLogger.Models.Models.Login;
using HorizonDeviceLogger.RepositoryInterfaces.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Adapter.Login
{
    public class LoginAdapter : MasterAdapter, ILoginAdapter, IDisposable
    {
        private readonly ILoginRepository _loginRepository = null;
        public LoginAdapter(ILoginRepository loginRepository) : base(new IOTLoggerEntities1())
        {
            this._loginRepository = loginRepository;
        }

        #region Dispose
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion


        public UserLoginDto CheckUserAuthorization(LoginModel model)
        {
            UserLoginDto result = new UserLoginDto();
            var received = _loginRepository.GetAllLogin(_dbContext)
                .Where(x => x.UserName == model.User_name && x.Password == model.Pass_word)
                .FirstOrDefault();

            Mapper.CreateMap<LoginMst, UserLoginDto>();
            result = Mapper.Map<LoginMst, UserLoginDto>(received);

            return result;
        }

    }
}
