using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace MEPM.Services
{
    public class Email : IEmail
    {
        private string apiKey;

        public EmailAddress FromEmailAddress { get; set; }
        public string SendersEmailAddress { get; set; } = "Contact information was not provided :(";
        public string Subject { get; set; }
        public EmailAddress ToEmailAddress { get; set; } = new EmailAddress("cawalton910@gmail.com");
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

        public async Task Send(string toEmailAddress, string sendersEmailAddress, string subject, string plainText, string htmlContext, string name = null)
        {
            //ToEmailAddress = new EmailAddress(toEmailAddress, name);
            if (sendersEmailAddress != null)
            {
                SendersEmailAddress = sendersEmailAddress;
            }
            _ = name ?? throw new ArgumentNullException(nameof(name));
            _ = subject ?? throw new ArgumentNullException(nameof(subject));
            _ = htmlContext ?? throw new ArgumentNullException(nameof(htmlContext));

            PlainTextContext = plainText + " Message from: " + SendersEmailAddress;
            HtmlContent = htmlContext + " Message from: " + SendersEmailAddress;
            Subject = subject;

            var msg = MailHelper.CreateSingleEmail(FromEmailAddress, ToEmailAddress, Subject, PlainTextContext, HtmlContent);

            Response = await SendGridClient.SendEmailAsync(msg);

        }
    }
}
