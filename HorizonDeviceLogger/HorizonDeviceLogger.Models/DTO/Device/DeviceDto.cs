using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Models.DTO
{
    public class DeviceDto
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
