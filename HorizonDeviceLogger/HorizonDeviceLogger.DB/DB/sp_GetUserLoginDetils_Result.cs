//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HorizonDeviceLogger.DB.DB
{
    using System;
    
    public partial class sp_GetUserLoginDetils_Result
    {
        public long UserId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string RoleName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EncryptPwd { get; set; }
        public Nullable<bool> LoginIsActive { get; set; }
    }
}