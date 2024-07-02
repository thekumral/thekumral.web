using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thekumral.Service.Exceptions
{
    public class NotFoundException : Exception
    {
        /// <summary>
        /// NotFoundException sınıfının bir örneğini belirtilen hata iletisiyle oluşturur.
        /// </summary>
        /// <param name="message">Oluşturulan istisna için hata iletisi.</param>
        public NotFoundException(string message) : base(message)
        {

        }
    }
}
