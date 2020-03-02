using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace HorizonDeviceLogger.Models.Models
{
    public class DeviceTypeModel
    {        
        public int DeviceTypeId { get; set; }

        [Required(ErrorMessage ="RequiredField", AllowEmptyStrings =false)]
        [MinLength(2,ErrorMessage ="Minimum 2 Chars")]
        [MaxLength(100, ErrorMessage = "Maximum 100 Chars")]
        //[Remote(action: "isExistsDeviceTypeName", controller:"DeviceType",areaName:"DeviceType", HttpMethod = "POST", ErrorMessage = "Device Type  already exists in database.")]
        public string DeviceTypeName { get; set; }
        public string Comments { get; set; }
        public bool Active { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
