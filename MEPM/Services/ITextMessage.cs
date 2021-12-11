namespace MEPM.Services
{
    public interface ITextMessage
    {
        public string ToPhoneNumber { get; set; }
        public string FromPhoneNumber { get; set; }
        public string Message { get; set; }
        public string Send(string toPhone, string message);
    }
}
