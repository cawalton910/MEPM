using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEPM.Services
{
    public class Email : IEmail
    {
        private string apiKey;

        public EmailAddress FromEmailAddress { get; set; }
        public string Subject { get; set; }
        public EmailAddress ToEmailAddress { get; set; }
        public string PlainTextContext { get; set; }
        public string HtmlContent { get; set; }
        public SendGridClient SendGridClient { get; init; }
        public Response Response { get; set; }

        public Email(IConfiguration configuration)
        {
            apiKey = configuration.GetSection("ApiKeys")["SendGrid"];

            FromEmailAddress = new EmailAddress(configuration.GetSection("SenderEmail")["EmailAddress"], configuration.GetSection("SenderEmail")["Name"]);

            SendGridClient = new SendGridClient(apiKey);
        }

        public async Task Send(string toEmailAddress, string subject, string plainText, string htmlContext, string name = null)
        {
            ToEmailAddress = new EmailAddress(toEmailAddress, name);
            PlainTextContext = plainText;
            HtmlContent = htmlContext;
            Subject = subject;
            
            var msg = MailHelper.CreateSingleEmail(FromEmailAddress, ToEmailAddress, Subject, PlainTextContext, HtmlContent);

            Response = await SendGridClient.SendEmailAsync(msg);

        }
    }
}
