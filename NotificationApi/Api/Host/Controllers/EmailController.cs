using Contract.Request.EMail;
using DomainService.Interface;
using DomainService.Operations;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    [ApiController]
    [Route("notification-api/email")]
    public class EmailController : ControllerBase
    {
        private readonly IEMailOperations _emailOperations;

        public EmailController(IEMailOperations emailOperations)
        {
            _emailOperations = emailOperations;
        }

        [HttpPost]
        public async Task SendEmail([FromBody] SendEMailRequest request)
        {
            await _emailOperations.SendEmailAsync(request.To, request.Subject, request.Body);
        }
    }
}