using HorizonDeviceLogger.Models.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.ActionInterfaces.Role
{
    public interface IRoleAction : IMasterAction
    {
        List<RoleDto> GetRoleList();
    }
}
