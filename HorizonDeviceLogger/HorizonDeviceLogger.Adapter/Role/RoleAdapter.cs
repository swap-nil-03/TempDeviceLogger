using AutoMapper;
using HorizonDeviceLogger.AdapterInterfaces.Role;
using HorizonDeviceLogger.DB.DB;
using HorizonDeviceLogger.Models.DTO.Role;
using HorizonDeviceLogger.RepositoryInterfaces.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Adapter.Role
{
    public class RoleAdapter : MasterAdapter, IRoleAdapter, IDisposable
    {
        private readonly IRoleRepository _roleRepository = null;
        public RoleAdapter(IRoleRepository roleRepository) : base(new IOTLoggerEntities1())
        {
            this._roleRepository = roleRepository;
        }
        #region Dispose
        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Get Role Details 
        public List<RoleDto> GetAllRole()
        {
            List<RoleDto> result = new List<RoleDto>();
            //Mapper.AssertConfigurationIsValid();            
            var received2 = _roleRepository.GetAllRole(_dbContext).ToList();
            Mapper.CreateMap<RoleMst, RoleDto>();
            result = Mapper.Map<List<RoleMst>, List<RoleDto>>(received2);
            return result;
        }
        #endregion

        #region Create Role

        public int CreateRole(RoleDto model)
        {
            RoleMst tbluser = Mapper.Map<RoleDto, RoleMst>(model);
            _roleRepository.CreateRole(tbluser, _dbContext);
            return _dbContext.SaveChanges();
        }
        #endregion

        #region Update Role Details 
        public int UpdateRole(RoleDto model)
        {
            RoleMst tbluser = Mapper.Map<RoleDto, RoleMst>(model);
            var existingRoleData = _roleRepository.GetAllRole(_dbContext)
                .Where(x => x.RoleId == model.RoleId)
                .FirstOrDefault();

            _roleRepository.UpdateRole(existingRoleData, tbluser, _dbContext);

            return _dbContext.SaveChanges();
        }
        #endregion

        #region  Get Role Details by Role Id

        public RoleDto GetRoleById(int Id)
        {
            RoleDto result = new RoleDto();
            var received = _roleRepository.GetAllRole(_dbContext)
                .Where(x => x.RoleId == Id)
                .FirstOrDefault();

            Mapper.CreateMap<RoleMst, RoleDto>();
            result = Mapper.Map<RoleMst, RoleDto>(received);

            return result;
        }

        #endregion

        #region delete Role Details by Role Id
        public int DeleteRole(RoleDto model)
        {
            RoleMst tbluser = Mapper.Map<RoleDto, RoleMst>(model);
            _roleRepository.DeleteRole(tbluser, _dbContext);
            return _dbContext.SaveChanges();
        }
        #endregion
    }
}
