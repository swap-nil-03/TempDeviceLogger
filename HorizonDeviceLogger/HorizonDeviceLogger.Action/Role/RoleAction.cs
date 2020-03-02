using HorizonDeviceLogger.ActionInterfaces.Role;
using HorizonDeviceLogger.AdapterInterfaces.Role;
using HorizonDeviceLogger.Models.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Action.Role
{
    public class RoleAction : IRoleAction
    {
        private readonly IRoleAdapter _roleAdapter = null;
        public RoleAction(IRoleAdapter roleAdapter)
        {
            this._roleAdapter = roleAdapter;
        }
        public List<RoleDto> GetRoleList()
        {
            return _roleAdapter.GetAllRole();
        }

    }
}
