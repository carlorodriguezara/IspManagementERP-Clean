using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IspManagementERP.Shared.Identity
{
    public class UpdateUserModel
    {
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public string? PhoneNumber { get; set; }
    }
}
