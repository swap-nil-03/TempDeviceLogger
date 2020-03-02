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
    using System.Collections.Generic;
    
    public partial class Device
    {
        public int DeviceId { get; set; }
        public string SerialNumber { get; set; }
        public string DeviceName { get; set; }
        public string Location { get; set; }
        public string DeviceType { get; set; }
        public string DeviceConfiguredToIPPort { get; set; }
        public string DeviceConfiguredAPIUrl { get; set; }
        public string DeviceGSMNumber { get; set; }
        public string NumberOfParameters { get; set; }
        public System.DateTime DeviceStartedDate { get; set; }
        public string MaintenanceBySupportNumber { get; set; }
        public string Comments { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
