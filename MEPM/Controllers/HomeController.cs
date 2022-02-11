using MEPM.Models;
using MEPM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MEPM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmail _email;


        public HomeController(IEmail email)
        {
            _email = email;
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
        public IActionResult Privacy()
        {
            return View();
        }

        //string toEmailAddress, string sendersEmailAddress, string subject, string plainText, string htmlText, string name
        [HttpPost]
        public IActionResult Email(EmailModel e)
        {
            if (ModelState.IsValid)
            {
                _email.Send(e.SendersEmailAddress, e.Subject, e.HtmlContent, e.name).Wait();
                return NoContent();
                
            }
            else
            {
                return View("Contact");
            }

            

        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
