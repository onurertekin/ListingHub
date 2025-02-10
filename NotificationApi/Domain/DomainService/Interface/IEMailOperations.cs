using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Interface
{
    public interface IEMailOperations
    {
        Task SendEmailAsync(string to, string subject, string body);
    }
}
