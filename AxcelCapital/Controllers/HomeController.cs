using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using AxcelCapital.Models;

namespace AxcelCapital.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitQuery(Query query)
        {

            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            var response = Request["g-recaptcha-response"];
            //string secretKey = "6LfV1HkUAAAAAPUeSeHOzVvqQvbdPrl0J8f87qwE";
            var client = new WebClient();

            string encodedResponse = Request["g-recaptcha-response"];
            bool isCaptchaValid = (Recaptcha.Validate(encodedResponse) == "true" ? true : false);
            if (!isCaptchaValid)
            {
                TempData["recaptcha"] = "Please verify that you are not a robot";
                return View("Index");
            }
            else
            {
                //subjectTitle
                string subjectTitle = "You have a query from " + query.firstName + " " + query.lastName;

                //emailBody
                string emailBody = "Name: " + query.firstName + " " + query.lastName + "<br />" +
                                     "Email: " + query.email + "<br />" +
                                     "Mobile: " + query.mobile + "<br />" +
                                     "Company Name: " + query.companyName + "<br />" +
                                     "Company Turnover: " + query.turnOver + "<br />" +
                                     "Message: " + query.message;


                sendMail(subjectTitle, emailBody);

                //send success msg to Action
                TempData["successMsg"] = "Your query has been received. We will contact you soon.";
                return RedirectToAction("Index", "Home");
            }


        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Faq()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Careers()
        {
            ViewBag.Message = "Careers Page";
            return View();
        }

        public static void sendMail(string subjectTitle, string emailBody)
        {
            int tryAgain = 5;
            bool failed = true;

            while (failed && tryAgain > 0)
            {
                failed = false;
                try
                {
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new System.Net.NetworkCredential("joelfongtest@gmail.com", "P@ssword123!");
                    smtpClient.EnableSsl = true;

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("joelfongtest@gmail.com");
                    mail.To.Add("joelfong@gmail.com");
                    mail.Subject = subjectTitle;
                    mail.IsBodyHtml = true;
                    mail.Body = emailBody;

                    smtpClient.Send(mail);
                }
                catch (Exception ex)
                {
                    failed = true;
                    tryAgain--;
                }
            }

        }
    }

}
