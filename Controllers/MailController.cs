using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class MailController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]  // Disable request validation for form
        public ActionResult Index(string subject, string body)
        {

            try
            {
                MailMessage m = new MailMessage();
                m.To.Add(new MailAddress("srikanth@st.com"));
                m.From = new MailAddress("admin@st.com");
                m.Subject = subject;
                m.IsBodyHtml = true;  // body contains HTML
                m.Body = body;

                //Attachment a1 = new Attachment(Request.MapPath("web.config"));
                //m.Attachments.Add(a1);

                SmtpClient smtp = new SmtpClient("127.0.0.1", 25);

                // log on to mail server - Authenticate the sender 
                //smtp.UseDefaultCredentials = false;
                //smtp.EnableSsl = false;
                //smtp.Credentials =
                //   new System.Net.NetworkCredential("joe@aspnet.com", "joe");

                smtp.Send(m);
                ViewBag.Message = "Mail Sent Successfully!";

            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error --> " + ex.StackTrace;
            }

            return View();
        }
    }
}