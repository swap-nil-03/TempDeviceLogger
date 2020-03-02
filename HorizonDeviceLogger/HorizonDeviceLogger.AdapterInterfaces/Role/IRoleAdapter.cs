using HorizonDeviceLogger.Models.DTO.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.AdapterInterfaces.Role
{
    public interface IRoleAdapter : IMasterAdapter
    {
        List<RoleDto> GetAllRole();
        int CreateRole(RoleDto model);
        RoleDto GetRoleById(int Id);
        int UpdateRole(RoleDto model);
        int DeleteRole(RoleDto model);
    }
}
