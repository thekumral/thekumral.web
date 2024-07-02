using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Core.DTOs.Users
{
    public class LoginDto
    {
        [DefaultValue("omer@kumral.com")]
        public string Email { get; set; }
        [DefaultValue("1")]
        public string Password { get; set; }
    }
}
