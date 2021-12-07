using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
