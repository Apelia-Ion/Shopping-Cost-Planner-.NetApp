using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using SendGrid;
using ShoppingCostPlanner.Application.Interfaces.Service;
using ShoppingCostPlanner.Application.Options;
using ShoppingCostPlanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

namespace ShoppingCostPlanner.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly SendGridOptions _options;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<SendGridOptions> options, ILogger<EmailService> logger)
        {
            _options = options.Value;
            _logger = logger;
        }

        public async Task SendAsync(EmailSendModel email)
        {
            var apiKey = _options.ApiKey;
            _logger.LogInformation("ApiKeyEmptyyyyyyyyyyyyyyyyyyyyyyyyyyyyy");

            var sender = _options.SenderEmail;

            var client = new SendGridClient(apiKey);
            var message = new SendGridMessage
            {
                From = new EmailAddress(sender),
                Subject = email.Subject,
                HtmlContent = email.Content
            };
            message.AddTo(new EmailAddress(email.ToEmail));
            var response = await client.SendEmailAsync(message);
        }
    }
}
