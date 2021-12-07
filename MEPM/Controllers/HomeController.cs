using MEPM.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEPM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmail _email;
        private readonly ITextMessage _text;


        public HomeController(IEmail email, ITextMessage text)
        {
            _email = email;
            _text = text;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Portfolio()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Email(string toEmailAddress, string subject, string plainText, string htmlText, string name)
        {
            _email.Send(toEmailAddress, subject, plainText, htmlText, name).Wait();

            return Content("Email sent");
        }

        [HttpPost]
        public IActionResult Text(string toPhone, string message)
        {
            string rst = _text.Send(toPhone, message);
            return Content("Text message sent");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

    }
}
