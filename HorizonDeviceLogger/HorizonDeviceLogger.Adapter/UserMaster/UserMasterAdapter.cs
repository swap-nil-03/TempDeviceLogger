using AutoMapper;
using HorizonDeviceLogger.AdapterInterfaces.UserMaster;
using HorizonDeviceLogger.DB.DB;
using HorizonDeviceLogger.Models.DTO;
using HorizonDeviceLogger.Models.DTO.User;
using HorizonDeviceLogger.RepositoryInterfaces.UserMaster;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Adapter.UserMaster
{
    public class UserMasterAdapter : MasterAdapter, IUserMasterAdapter, IDisposable
    {
        private readonly IUserMasterRepository _userMasterRepository = null;
        public UserMasterAdapter(IUserMasterRepository userMasterRepository) : base(new IOTLoggerEntities1())
        {
            this._userMasterRepository = userMasterRepository;
        }

        #region Dispose
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Get User Details 
        //public List<UserMasterDto> GetAlluserDetail()
        //{
        //    List<UserMasterDto> result = new List<UserMasterDto>();
        //    List<sp_GetUserDtls_Result> temp = new List<sp_GetUserDtls_Result>();
        //    //Mapper.AssertConfigurationIsValid();     
        //    temp = _IOTLoggerEntities.sp_GetUserDtls().ToList();
        //    Mapper.CreateMap<sp_GetUserDtls_Result, UserMasterDto>();
        //    result = Mapper.Map<List<sp_GetUserDtls_Result>, List<UserMasterDto>>(temp);
        //    return result;
        //}
        #endregion

        #region Create User

        //public long CreateUser(UserMasterDto model)
        //{
        //    Mapper.CreateMap<UserMasterDto, UserMst>();
        //    UserMst tbluser = Mapper.Map<UserMasterDto, UserMst>(model);
        //    _userMasterRepository.CreateUser(tbluser, _dbContext);
        //    return _dbContext.SaveChanges();
        //}
        #endregion

        #region Update User Details 
        public long UpdateUser(UserMasterDto model)
        {
            Mapper.CreateMap<UserMasterDto, UserMst>();
            UserMst tbluser = Mapper.Map<UserMasterDto, UserMst>(model);
            var existingUserData = _userMasterRepository.GetAllUserDetails(_dbContext)
                .Where(x => x.UserId == model.UserId)
                .FirstOrDefault();

            _userMasterRepository.UpdateUser(existingUserData, tbluser, _dbContext);

            return _dbContext.SaveChanges();
        }

        public long UpdateUserActiveStatus(UserMasterDto model)
        {
            Mapper.CreateMap<UserMasterDto, UserMst>();
            UserMst tbluser = Mapper.Map<UserMasterDto, UserMst>(model);
            var existingUserData = _userMasterRepository.GetAllUserDetails(_dbContext)
                .Where(x => x.UserId == model.UserId)
                .FirstOrDefault();

            return _userMasterRepository.UpdateUserActiveStatus(tbluser, _dbContext);

        }

        #endregion

        #region  Get User Details by User Id

        public UserMasterDto GetUserById(long Id)
        {
            UserMasterDto result = new UserMasterDto();
            var received = _userMasterRepository.GetAllUserDetails(_dbContext)
                .Where(x => x.UserId == Id)
                .FirstOrDefault();

            Mapper.CreateMap<UserMst, UserMasterDto>();
            result = Mapper.Map<UserMst, UserMasterDto>(received);

            return result;
        }

        #endregion

        #region delete User Details by User Id
        public long DeleteUser(UserMasterDto model)
        {
            Mapper.CreateMap<UserMasterDto, UserMst>();
            UserMst tbluser = Mapper.Map<UserMasterDto, UserMst>(model);
            _userMasterRepository.DeleteUserDetails(tbluser, _dbContext);
            return _dbContext.SaveChanges();
        }
        #endregion

        #region Get User Login Details
        public List<UserLoginMstDto> GetAlluserDetail(long UserId)
        {
            List<UserLoginMstDto> result = new List<UserLoginMstDto>();
            List<sp_GetUserLoginDetils_Result> temp = new List<sp_GetUserLoginDetils_Result>();
            //Mapper.AssertConfigurationIsValid();     
            temp = _IOTLoggerEntities.sp_GetUserLoginDetils(UserId).ToList();
            Mapper.CreateMap<sp_GetUserLoginDetils_Result, UserLoginMstDto>();
            result = Mapper.Map<List<sp_GetUserLoginDetils_Result>, List<UserLoginMstDto>>(temp);
            return result;
        }
        #endregion

        #region Add Update and Deactive User Details
        public long CreateUser(UserLoginMstDto model)
        {
            ObjectParameter obj = new ObjectParameter("resultId", typeof(Int32));
            long resultId = 0;
            _IOTLoggerEntities.sp_CreateUpdateUserLogin(model.UserId, model.RoleId, model.Name, model.Address,
                 model.EmailId, model.MobileNo, model.UserName, model.Password, model.EncryptPwd, model.IsActive, model.Status,
                 "LoginBy", obj);
            if(obj!=null)
            {
                resultId = Convert.ToInt32(obj.Value);
            }
            return resultId;
        }
        #endregion

    }
}
