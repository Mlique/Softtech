using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Softtech.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.Run(() => { SendEmail(email, subject, message); });
        }

        public bool SendEmail(string email, string subject, string message)
        {
            try
            {
                MailMessage msz = new MailMessage
                {
                    From = new MailAddress("nhlakaniphosiboniso@gmail.com"),//Email which you are getting from contact us page 
                    Subject = subject,
                    Body = message,
                    IsBodyHtml = false
                };
                msz.To.Add(email);//Where mail will be sent  
                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    UseDefaultCredentials = true,
                    EnableSsl = true,
                    Credentials = new System.Net.NetworkCredential("nhlakaniphosiboniso@gmail.com", "NKW@kx4774"),
                };

                smtp.Send(msz);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
