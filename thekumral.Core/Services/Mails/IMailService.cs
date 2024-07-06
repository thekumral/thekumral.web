using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Core.Services.Mails
{
    public interface IMailService
    {
        bool Send(string recipient, string subject, string body, bool isBodyHTML);
    }
}
