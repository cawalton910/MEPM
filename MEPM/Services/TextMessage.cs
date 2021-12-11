using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;


namespace MEPM.Services
{
    public class TextMessage : ITextMessage
    {
        private string accountSid;
        private string authToken;
        public string ToPhoneNumber { get; set; }
        public string FromPhoneNumber { get; set; }
        public string Message { get; set; }

        public TextMessage(IConfiguration configuration)
        {
            accountSid = configuration.GetSection("Twilio")["AccountSid"];
            authToken = configuration.GetSection("Twilio")["AuthToken"];
            FromPhoneNumber = configuration.GetSection("Twilio")["FromPhoneNumber"];

            TwilioClient.Init(accountSid, authToken);
        }

        public string Send(string toPhone, string message)
        {
            Message = message;
            ToPhoneNumber = toPhone;

            var text = MessageResource.Create(
                to: new Twilio.Types.PhoneNumber(ToPhoneNumber),
                from: new Twilio.Types.PhoneNumber(FromPhoneNumber),
                body: $"{Message}"
                );

            return text.Sid;
        }
    }
}
