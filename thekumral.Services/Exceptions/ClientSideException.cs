using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Service.Exceptions
{
    public class ClientSideException : Exception
    {
        /// <summary>
        /// Yeni bir ClientSideException örneği oluşturur.
        /// </summary>
        /// <param name="message">İstisna mesajı</param>
        public ClientSideException(string message) : base(message)
        {
        }
    }
}
