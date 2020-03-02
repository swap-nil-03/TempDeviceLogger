using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Models.DTO
{
    public class DeviceTypeDto
    {
        public int DeviceTypeId { get; set; }
        public string DeviceTypeName { get; set; }
        public string Comments { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
