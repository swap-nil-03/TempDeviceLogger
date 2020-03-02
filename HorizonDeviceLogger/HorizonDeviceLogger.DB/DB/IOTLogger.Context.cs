﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IOTLoggerEntities1 : DbContext
    {
        public IOTLoggerEntities1()
            : base("name=IOTLoggerEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LoginMst> LoginMsts { get; set; }
        public virtual DbSet<RoleMst> RoleMsts { get; set; }
        public virtual DbSet<UserMst> UserMsts { get; set; }
        public virtual DbSet<AlertConfig> AlertConfigs { get; set; }
        public virtual DbSet<AlertType> AlertTypes { get; set; }
        public virtual DbSet<DeviceLog> DeviceLogs { get; set; }
        public virtual DbSet<DeviceLogs2> DeviceLogs2 { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
    
        public virtual int sp_CreateUpdateUserLogin(Nullable<long> userId, Nullable<int> roleId, string name, string address, string emailId, string mobileNo, string userName, string password, string encryptPwd, Nullable<bool> isactive, string status, string loginBy, ObjectParameter resultId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(long));
    
            var roleIdParameter = roleId.HasValue ?
                new ObjectParameter("roleId", roleId) :
                new ObjectParameter("roleId", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var emailIdParameter = emailId != null ?
                new ObjectParameter("EmailId", emailId) :
                new ObjectParameter("EmailId", typeof(string));
    
            var mobileNoParameter = mobileNo != null ?
                new ObjectParameter("MobileNo", mobileNo) :
                new ObjectParameter("MobileNo", typeof(string));
    
            var userNameParameter = userName != null ?
                new ObjectParameter("userName", userName) :
                new ObjectParameter("userName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            var encryptPwdParameter = encryptPwd != null ?
                new ObjectParameter("encryptPwd", encryptPwd) :
                new ObjectParameter("encryptPwd", typeof(string));
    
            var isactiveParameter = isactive.HasValue ?
                new ObjectParameter("Isactive", isactive) :
                new ObjectParameter("Isactive", typeof(bool));
    
            var statusParameter = status != null ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(string));
    
            var loginByParameter = loginBy != null ?
                new ObjectParameter("LoginBy", loginBy) :
                new ObjectParameter("LoginBy", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CreateUpdateUserLogin", userIdParameter, roleIdParameter, nameParameter, addressParameter, emailIdParameter, mobileNoParameter, userNameParameter, passwordParameter, encryptPwdParameter, isactiveParameter, statusParameter, loginByParameter, resultId);
        }
    
        public virtual ObjectResult<sp_GetUserLoginDetils_Result> sp_GetUserLoginDetils(Nullable<long> userId)
        {
            var userIdParameter = userId.HasValue ?
                new ObjectParameter("UserId", userId) :
                new ObjectParameter("UserId", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetUserLoginDetils_Result>("sp_GetUserLoginDetils", userIdParameter);
        }
    
        public virtual ObjectResult<SpGetLatestDeviceLog_Result> SpGetLatestDeviceLog()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SpGetLatestDeviceLog_Result>("SpGetLatestDeviceLog");
        }
    
        public virtual ObjectResult<sp_GetAllDeviceLogs_Result> sp_GetAllDeviceLogs()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_GetAllDeviceLogs_Result>("sp_GetAllDeviceLogs");
        }
    }
}
