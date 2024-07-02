using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace thekumral.Core.Entities
{
    public class User : IdentityUser<Guid>
    {
        public User() { }

        public User(string firstName, string lastName, Guid companyId)
        {
            FirstName = firstName;
            LastName = lastName;
            CompanyId = companyId;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public virtual ICollection<Post>? Posts { get; set; }
        public string? FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}
