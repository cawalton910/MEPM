using MEPM.Models;
using MEPM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        public IActionResult Email(string toEmailAddress, string sendersEmailAddress, string subject, string plainText, string htmlText, string name)
        {

            _email.Send(toEmailAddress, sendersEmailAddress, subject, plainText, htmlText, name).Wait();

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
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
