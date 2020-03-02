using HorizonDeviceLogger.Models.DTO.Role;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HorizonDeviceLogger.Models.DTO.User
{
    public class AddUser
    {
        public long UserId { get; set; }

        [Required(ErrorMessage = "Role  is required")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Remote("IsAlreadySignedEmailId", "User", AdditionalFields = "UserId", HttpMethod = "POST", ErrorMessage = "Email address  already exists in system.")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Not a valid phone number")]
        [Remote("IsAlreadySignedMobNo", "User", AdditionalFields = "UserId", HttpMethod = "POST", ErrorMessage = "phone number already exists in system.")]
        public string MobileNo { get; set; }
        public Nullable<bool> IsActive { get; set; }

        [Required(ErrorMessage = "User name is required")]
        [StringLength(150, ErrorMessage = "Must be between 5 and 150 characters", MinimumLength = 5)]
        [Remote("IsAlreadySigned", "User", AdditionalFields = "UserId", HttpMethod = "POST", ErrorMessage = "User name already exists in system.")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage = "Password and  Confirm Password is not Match")]
        public string ConfirmPassword { get; set; }
        public string Status { get; set; }
        public string EncryptPwd { get; set; }
        public Nullable<bool> LoginIsActive { get; set; }
        public List<RoleDto> roleList { get; set; } 
    }
    public class UserLoginMstDto
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
        public string Status { get; set; }
        public string EncryptPwd { get; set; }
        public Nullable<bool> LoginIsActive { get; set; }
    }

    public class UserMasterDto
    {
        public long UserId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string RoleName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
