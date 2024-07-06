using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Service.Exceptions
{
    public class UserNotFoundException:Exception
    {
        public UserNotFoundException(string message) : base(message)
        {

        }
    }
}
