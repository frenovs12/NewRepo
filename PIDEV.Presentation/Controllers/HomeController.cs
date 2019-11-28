using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIDEV.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           /* var message = new MimeMessage();
            message.From.Add(new MailboxAddress(" test project", "ons.mokni@esprit.tn"));
            message.To.Add(new MailboxAddress(" ons", "moknions@gmail.com"));
            message.Subject = "u got a +";
            message.Body = new TextPart("plain") { Text = "u got & plus "};
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("ons.mokni@esprit.tn", "ibrahimamel");
                client.Send(message);
                client.Disconnect(true);
            }*/
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}