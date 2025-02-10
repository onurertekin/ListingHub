using DomainService.Interface;
using DomainService.Operations;
using ExchangeMessageLibrary.Commands;
using MassTransit;

namespace Host.Consumers
{
    public class EmailConsumer : IConsumer<EmailMessage>
    {
        private readonly IEMailOperations _emailOperations;

        public EmailConsumer(IEMailOperations emailOperations)
        {
            _emailOperations = emailOperations;
        }

        public async Task Consume(ConsumeContext<EmailMessage> context)
        {
            var message = context.Message;
            Console.WriteLine(message.To);
            await _emailOperations.SendEmailAsync(message.To, message.Subject, message.Body);
        }
    }
}
