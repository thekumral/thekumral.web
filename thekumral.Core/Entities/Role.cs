using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace thekumral.Core.Entities
{
    public enum RoleType
    {
        SuperAdmin,
        CompanyAdmin,
        CompanyAuthor,
        DefaultUser
    }

    public class Role : IdentityRole<Guid> { }
}
