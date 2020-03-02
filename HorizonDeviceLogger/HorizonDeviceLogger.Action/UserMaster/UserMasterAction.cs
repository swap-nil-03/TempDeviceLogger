using AutoMapper;
using HorizonDeviceLogger.ActionInterfaces.UserMaster;
using HorizonDeviceLogger.AdapterInterfaces.UserMaster;
using HorizonDeviceLogger.Models.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Action.UserMaster
{
    public class UserMasterAction : IUserMasterAction
    {
        private readonly IUserMasterAdapter _userAdapter = null;
        public UserMasterAction(IUserMasterAdapter userAdapter)
        {
            this._userAdapter = userAdapter;
        }
        public long CreateUpdatedUser(AddUser model)
        {
            UserLoginMstDto userMasterDto = new UserLoginMstDto();
            try
            {
                Mapper.CreateMap<AddUser, UserLoginMstDto>();
                userMasterDto = Mapper.Map<AddUser, UserLoginMstDto>(model);
                return _userAdapter.CreateUser(userMasterDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsAlreadySigned(long UserId, string CheckStr)
        {
            bool flag = false;
            try
            {
               
                var temp = _userAdapter.GetAlluserDetail(0).Where(model=> model.UserId!= UserId && (model.EmailId== CheckStr || model.MobileNo == CheckStr || model.UserName == CheckStr)).FirstOrDefault();
                if(temp==null)
                {
                    flag = true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return flag;
        }

        public long DeleteUser(UserMasterDto model)
        {
            return _userAdapter.UpdateUserActiveStatus(model);
            // return _userAdapter.DeleteUser(model);
        }

        public List<UserLoginMstDto> GetAllUser(long UserId)
        {
            return _userAdapter.GetAlluserDetail(UserId);
        }

        public UserMasterDto GetUserById(long Id)
        {
            return _userAdapter.GetUserById(Id);
        }

        public long UpdateUser(AddUser model)
        {
            UserMasterDto userMasterDto = new UserMasterDto();
            try
            {
                if (model != null)
                {
                    userMasterDto.UserId = model.UserId;
                    userMasterDto.RoleId = model.RoleId;
                    userMasterDto.Name = model.Name;
                    userMasterDto.Address = model.Address;
                    userMasterDto.MobileNo = model.MobileNo;
                    userMasterDto.EmailId = model.EmailId;
                    userMasterDto.IsActive = true;
                    return _userAdapter.UpdateUser(userMasterDto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return -1;
        }
    }
}
