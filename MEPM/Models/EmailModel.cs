using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MEPM.Models
{
    public class EmailModel
    {

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        
        public string SendersEmailAddress { get; set; } = "Contact information was not provided :(";
        [Required]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Message can not be empty")]
        [DataType(DataType.MultilineText)]
        public string HtmlContent { get; set; }

    }
}
