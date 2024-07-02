using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using thekumral.Core.DTOs.Posts;

namespace thekumral.Core.DTOs.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string RefreshToken { get; set; }
        public DateTimeOffset? RefreshTokenExpiryTime { get; set; }
        public List<PostDto> Posts { get; set; }

        public UserDto()
        {
            Posts = new List<PostDto>();
        }
    }
}
