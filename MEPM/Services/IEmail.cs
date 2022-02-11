using SendGrid;
using SendGrid.Helpers.Mail;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace MEPM.Services
{
    public interface IEmail
    {


        public string SendersEmailAddress { get; set; }
        public EmailAddress FromEmailAddress { get; set; }
        public string Subject { get; set; }
        public EmailAddress ToEmailAddress { get; set; }
        public string PlainTextContext { get; set; }
        public string HtmlContent { get; set; }
        public SendGridClient SendGridClient { get; init; }
        public Response Response { get; set; }
        public Task Send(string sendersEmailAddress, string subject, string htmlContext, string name);
    }
}
