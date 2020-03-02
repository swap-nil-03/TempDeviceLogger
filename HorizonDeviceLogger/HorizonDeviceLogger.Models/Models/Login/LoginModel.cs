using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorizonDeviceLogger.Models.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "username is required")]
        public string User_name { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Pass_word { get; set; }

        public bool IsValid { get; set; }
    }
}
